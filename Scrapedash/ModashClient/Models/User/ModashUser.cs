using Newtonsoft.Json;

namespace ModashClient.Models.User {

    public class ModashUser {

        [JsonProperty("loggedIn")]
        public bool LoggedIn { get; set; } = false;

        [JsonProperty("isEmailVerified")]
        public bool IsEmailVerified { get; set; } = false;

        [JsonProperty("isCreditBasedUser")]
        public bool IsCreditBasedUser { get; set; } = false;

        [JsonProperty("subscriptionUsage")]
        public ModashUserSubscriptionUsage SubscriptionUsage { get; set; } = new();

        [JsonProperty("error")]
        public bool Error { get; set; } = true;

        [JsonProperty("_id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("teamId")]
        public string TeamId { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonProperty("settings")]
        public ModashUserSettings Settings { get; set; } = new();

        [JsonProperty("businessInEU")]
        public bool BusinessInEu { get; set; } = false;

        [JsonProperty("monitoring")]
        public ModashUserMonitoring Monitoring { get; set; } = new();

        [JsonProperty("isDomainGoogleOnly")]
        public bool IsDomainGoogleOnly { get; set; } = false;

    }

}
