using ModashClient.Configuration;
using ModashClient.Models.User;

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

        public void Dispose() {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }

    }

}
