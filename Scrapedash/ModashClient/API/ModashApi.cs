namespace ModashClient.API {

    public class ModashApi : IDisposable {

        public ApiClient Api { get; private set; }

        public ModashApi() {
            Api = new ApiClient();
        }

        public void Dispose() {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }

    }

}
