using ModashClient.Configuration;
using Newtonsoft.Json;
using System;
using System.Text;

namespace ModashClient.API {

    public class ApiClient : IDisposable {

        public HttpClient Client { get; private set; }

        public ApiClient() {
            Client = new HttpClient();
        }

        public async Task<T?> Get<T>(string uri, string cookies, string? body = null) {
            return await Request<T>(HttpMethod.Get, uri, cookies, body);
        }

        public async Task<T?> Post<T>(string uri, string cookies, string? body = null) {
            return await Request<T>(HttpMethod.Post, uri, cookies, body);
        }

        public async Task<T?> Request<T>(HttpMethod method, string uri, string cookies, string? body = null) {
            T? result = default;
            var request = body == null ? new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri(uri),
                Headers = {
                    { "Accept", "application/json" },
                    { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36" },
                },
            } : new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri(uri),
                Headers = {
                    { "Accept", "application/json" },
                    { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36" },
                },
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };
            if(cookies.Length > 0) {
                request.Headers.Add("Cookie", cookies);
            }
            try {
                using var response = await Client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var str = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(str, JsonSettings.DefaultSettings) ?? result;
            }
            catch(Exception ex) {
                var previousColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"[ApiClient.Request] Failed:\n{ex.Message}");
                Console.ForegroundColor = previousColor;
                return result;
            }
        }

        public void Dispose() {
            Client.Dispose();
            GC.SuppressFinalize(this);
        }

    }

}
