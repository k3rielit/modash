using Microsoft.Playwright;
using ModashClient.API;
using ModashClient.Configuration;
using ModashClient.Scrape;

namespace Scrapedash {

    internal class Program {

        static void Main(string[] args) {
            var account = ModashAccount.Load();
            if(account.User.LoggedIn) {
                Console.WriteLine($"{account.User.Id} {account.User.Name} ({account.User.Email})");
            }
            else {
                Console.WriteLine("Authentication failed. Please check the account.json configuration file.");
            }
        }

    }

}
