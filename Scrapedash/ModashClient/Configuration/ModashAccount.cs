using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Configuration {

    public class ModashAccount {

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Cookies { get; set; } = string.Empty;

        public static bool ConfigurationExists() {
            return File.Exists("account.json");
        }

        public static bool ConfigurationWritable() {
            if(!ConfigurationExists()) {
                return false;
            }
            try {
                using var stream = File.Open("account.json", FileMode.Open, FileAccess.Read);
                return true;
            }
            catch(Exception) {
                return false;
            }
        }

        public static bool ConfigurationReadable() {
            if(!ConfigurationExists()) {
                return false;
            }
            try {
                using var stream = File.Open("account.json", FileMode.Open, FileAccess.Write);
                return true;
            }
            catch(Exception) {
                return false;
            }
        }

        public static ModashAccount Load() {
            var defaultConfig = new ModashAccount();
            if(ConfigurationExists() && ConfigurationWritable()) {
                return JsonConvert.DeserializeObject<ModashAccount>(File.ReadAllText("account.json")) ?? defaultConfig;
            }
            return defaultConfig;
        }

        public void Save() {
            if(!ConfigurationExists() || ConfigurationWritable()) {
                File.WriteAllText("account.json", JsonConvert.SerializeObject(this, JsonSettings.DefaultSettings));
            }
        }

    }

}
