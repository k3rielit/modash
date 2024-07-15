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
            if(!account.User.LoggedIn) {
                Console.WriteLine("Authentication failed. Please check the account.json configuration file.\nPress any key to exit.");
                Console.ReadKey();
                return;
            }
            // Interactive
            var scraper = new ApiScraper(account);
            scraper.Start();
            scraper.Menu();
        }

    }

}
