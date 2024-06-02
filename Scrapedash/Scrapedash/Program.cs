using ModashClient.Scrape;

namespace Scrapedash {

    internal class Program {

        static void Main(string[] args) {
            Task.Run(GetSession).GetAwaiter().GetResult();
        }

        public static async Task GetSession() {
            var scraper = new ModashScraper();
            await scraper.InitAsync();
            var cookie = await scraper.LoginAsync("", "");
            Console.WriteLine(cookie);
            scraper.Dispose();
        }

    }

}
