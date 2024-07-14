using ModashClient.API;
using ModashClient.Models.User;
using ModashClient.Scrape;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Configuration {

    public class ModashAccount {

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Cookies { get; set; } = string.Empty;
        [JsonIgnore]
        public ModashUser User { get; set; } = new();

        public static bool ConfigurationExists() {
            return File.Exists("account.json");
        }

        public static ModashAccount Load() {
            var config = new ModashAccount();
            try {
                config = JsonConvert.DeserializeObject<ModashAccount>(File.ReadAllText("account.json")) ?? config;
                config.Login();
            }
            catch(FileNotFoundException ex) {
                Console.WriteLine($"[ModashAccount.Load] Configuration file not found, creating a default one.\nException: {ex.Message}");
            }
            catch(Exception ex) {
                Console.WriteLine($"[ModashAccount.Load] Unexpected exception: {ex.Message}");
            }
            config.Save();
            return config;
        }

        public bool Save() {
            try {
                File.WriteAllText("account.json", JsonConvert.SerializeObject(this, JsonSettings.DefaultSettings));
                return true;
            }
            catch(Exception ex) {
                Console.WriteLine($"[ModashAccount.Save] Failed: {ex.Message}");
                return false;
            }
        }

        public async Task LoginAsync() {
            // Try requesting user information, if it fails, the cookies aren't edible.
            var api = new ModashApi(this);
            var user = await api.GetUserAsync();
            api.Dispose();
            if(user.LoggedIn) {
                User = user;
                return;
            }
            // If the cookies aren't edible, try baking new ones.
            var scraper = new ModashScraper();
            await scraper.InitAsync();
            Cookies = await scraper.LoginAsync(Email, Password) ?? string.Empty;
            api = new ModashApi(this);
            user = await api.GetUserAsync();
            api.Dispose();
            User = user;
        }

        public void Login() {
            Task.Run(LoginAsync).GetAwaiter().GetResult();
        }

    }

}
