using Microsoft.Playwright;
using ModashClient.API;
using ModashClient.Configuration;
using ModashClient.Models.Search;
using ModashClient.Scrape;
using Newtonsoft.Json;

namespace Scrapedash {

    internal class Program {

        static void Main(string[] args) {
            // Initialize account
            var account = ModashAccount.Load();
            if(account.User.LoggedIn) {
                Console.WriteLine($"{account.User.Id} {account.User.Name} ({account.User.Email})");
            }
            else {
                Console.WriteLine("Authentication failed. Please check the account.json configuration file.");
                return;
            }
            // Download a page
            var search = new InfluencerSearch();
            search.Filters.Influencer.Followers.Min = "0";
            search.Filters.Influencer.Followers.Max = "1k";
            var api = new ModashApi(account);
            var searchResult = api.Discover(search);
            api.Dispose();
            if(!searchResult.Error) {
                Console.WriteLine(JsonConvert.SerializeObject(searchResult, Formatting.Indented));
            }
            else {
                Console.WriteLine($"[Api.Discover] Search failed with body:\n{JsonConvert.SerializeObject(search, Formatting.Indented)}");
            }
        }

    }

}
