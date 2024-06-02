using ModashClient.Configuration;
using Newtonsoft.Json;
using System;

namespace ModashClient.API {

    public class ApiClient : IDisposable {

        public HttpClient Client { get; private set; }

        public ApiClient() {
            Client = new HttpClient();
        }

        public async Task<T?> Request<T>(HttpMethod method, string uri, string cookies, string? body = null) {
            T? result = default;
            var request = body == null ? new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri(uri),
                Headers = {
                    { "Cookies", cookies },
                },
            } : new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri(uri),
                Headers = {
                    { "Cookies", cookies },
                },
                Content = new StringContent(body),
            };
            try {
                using var response = await Client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var str = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(str, JsonSettings.DefaultSettings) ?? result;
            }
            catch(Exception) {
                return result;
            }
        }

        public void Dispose() {
            Client.Dispose();
            GC.SuppressFinalize(this);
        }

    }

}
