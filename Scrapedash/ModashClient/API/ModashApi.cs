using ModashClient.Configuration;
using ModashClient.Models.Influencer;
using ModashClient.Models.Search;
using ModashClient.Models.User;
using Newtonsoft.Json;

namespace ModashClient.API {

    public class ModashApi(ModashAccount account) : IDisposable {

        public ApiClient Api { get; private set; } = new ApiClient();
        public ModashAccount Account { get; private set; } = account;
        public string BaseUri { get; private set; } = "https://marketer.modash.io";

        public async Task<ModashUser> GetUserAsync() {
            return await Api.Get<ModashUser>($"{BaseUri}/api/user", Account.Cookies) ?? new();
        }

        public ModashUser GetUser() {
            return Task.Run(GetUserAsync).GetAwaiter().GetResult();
        }

        public async Task<InfluencerSearchResult> DiscoverAsync(InfluencerSearch search, string platform = "instagram") {
            return await Api.Post<InfluencerSearchResult>($"{BaseUri}/api/discovery/search/{platform}", Account.Cookies, JsonConvert.SerializeObject(search)) ?? new();
        }

        public InfluencerSearchResult Discover(InfluencerSearch search, string platform = "instagram") {
            return Task.Run(() => DiscoverAsync(search, platform)).GetAwaiter().GetResult();
        }

        public void Dispose() {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }

    }

}
