using ModashClient.API;
using ModashClient.Configuration;
using ModashClient.Models.Influencer;
using ModashClient.Models.Search;
using System.Collections.Concurrent;

namespace ModashClient.Scrape {

    public class ApiScraper : IDisposable {

        public ModashAccount Account { get; private set; }
        public ModashApi Api { get; private set; }
        public CancellationTokenSource TokenSource { get; private set; } = new();
        public ConcurrentQueue<InfluencerSearch> Searches { get; private set; } = new();
        public ConcurrentQueue<InfluencerLookalike> Lookalikes { get; private set; } = new();
        public ulong RangeMin { get; private set; } = 0;
        public ulong RangeMax { get; private set; } = 1;
        public ulong SearchPage { get; private set; } = 0;

        public ApiScraper(ModashAccount account) {
            Account = account;
            Api = new ModashApi(Account);
        }

        public void Start() {
            TokenSource = new();
            Task.Run(GenerateSearchesThread);
            Task.Run(ExecuteSearchesThread);
            Task.Run(SaveLookalikesThread);
        }

        public void Stop() {
            TokenSource.Cancel();
        }

        private async Task GenerateSearchesThread() {
            var token = TokenSource.Token;
            while(!token.IsCancellationRequested) {
                // Wait for threads processing the searches to catch up
                if(Searches.Count > 1000) {
                    Thread.Sleep(100);
                    continue;
                }
                // Add generated search to the queue
                for(; SearchPage <= 665; SearchPage++) {
                    var search = new InfluencerSearch();
                    search.Range(RangeMin, RangeMax);
                    search.Page = SearchPage;
                    Searches.Enqueue(search);
                }
                // Increment search range, reset page
                // There are 665 pages maximum on each range
                SearchPage = 0;
                RangeMin++;
                RangeMax++;
            }
        }

        private async Task ExecuteSearchesThread() {
            var token = TokenSource.Token;
            while(!token.IsCancellationRequested) {
                // Wait for threads processing lookalikes to catch up
                if(Lookalikes.Count > 1000) {
                    Thread.Sleep(100);
                    continue;
                }
                // Trye retrieving and executing a search on all platforms
                Searches.TryDequeue(out InfluencerSearch? search);
                if(search == null) {
                    Thread.Sleep(100);
                    continue;
                }
                var discoveredInstagram = await Api.DiscoverAsync(search, "instagram");
                var discoveredYoutube = await Api.DiscoverAsync(search, "youtube");
                var discoveredTiktok = await Api.DiscoverAsync(search, "tiktok");
                // Add the resulting lookalikes to the queue
                foreach(var lookalike in discoveredInstagram.Lookalikes) {
                    Lookalikes.Enqueue(lookalike);
                }
                foreach(var lookalike in discoveredYoutube.Lookalikes) {
                    Lookalikes.Enqueue(lookalike);
                }
                foreach(var lookalike in discoveredTiktok.Lookalikes) {
                    Lookalikes.Enqueue(lookalike);
                }
            }
        }

        private async Task SaveLookalikesThread() {
            var token = TokenSource.Token;
            using var writer = new StreamWriter("lookalikes.txt");
            while(!token.IsCancellationRequested) {
                // Try retrieving a lookalike from the queue
                Lookalikes.TryDequeue(out InfluencerLookalike? lookalike);
                if(lookalike == null) {
                    Thread.Sleep(100);
                    continue;
                }
                var compact = lookalike.Compact();
                // Save the lookalike
                writer.WriteLine($"[{compact.ProfileType}] {compact.Username} {compact.Fullname}: {compact.Followers} followers, {compact.Engagements} engagements ({compact.EngagementRate} rate)");
            }
            writer.Close();
        }

        public void Menu() {
            Task.Run(Display);
            var key = ConsoleKey.Execute;
            while(key != ConsoleKey.Escape) {
                key = Console.ReadKey().Key;
            }
            Stop();
        }

        private async Task Display() {
            var token = TokenSource.Token;
            while(!token.IsCancellationRequested) {
                ConsoleFastClear();
                Console.WriteLine($"{Account.User.Id} {Account.User.Name} ({Account.User.Email})");
                Console.WriteLine($"Queued Searches: {Searches.Count}");
                Console.WriteLine($"Queued Lookalikes: {Lookalikes.Count}");
                Console.WriteLine("[Esc] Exit");
                Thread.Sleep(250);
            }
        }

        private static void ConsoleFastClear() {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            for(int top = 0; top < Console.WindowHeight; top++) {
                Console.SetCursorPosition(0, top);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, 0);
        }

        public void Dispose() {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }

    }

}
