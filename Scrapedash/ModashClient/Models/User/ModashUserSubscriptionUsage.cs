using Newtonsoft.Json;

namespace ModashClient.Models.User {

    public class ModashUserSubscriptionUsage {

        [JsonProperty("productIds")]
        public List<string> ProductIds { get; set; } = new();

        [JsonProperty("planVersion")]
        public long PlanVersion { get; set; } = 0;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("intervalCount")]
        public long IntervalCount { get; set; } = 0;

        [JsonProperty("lastUsageReset")]
        public DateTime LastUsageReset { get; set; } = DateTime.Now;

        [JsonProperty("maxBulkSave")]
        public long MaxBulkSave { get; set; } = 0;

        [JsonProperty("searches")]
        public long Searches { get; set; } = 0;

        [JsonProperty("exports")]
        public long Exports { get; set; } = 0;

        [JsonProperty("profiles")]
        public long Profiles { get; set; } = 0;

        [JsonProperty("notableProfiles")]
        public long NotableProfiles { get; set; } = 0;

        [JsonProperty("notableProfilesLinkedAccounts")]
        public long NotableProfilesLinkedAccounts { get; set; } = 0;

        [JsonProperty("monitoringInfluencers")]
        public long MonitoringInfluencers { get; set; } = 0;

        [JsonProperty("monitoringAlerts")]
        public bool MonitoringAlerts { get; set; } = false;

        [JsonProperty("monitoringExport")]
        public bool MonitoringExport { get; set; } = false;

        [JsonProperty("hasBulkSave")]
        public bool HasBulkSave { get; set; } = false;

        [JsonProperty("teamSeats")]
        public long TeamSeats { get; set; } = 0;

        [JsonProperty("hasCreatorTransactions")]
        public bool HasCreatorTransactions { get; set; } = false;

        [JsonProperty("hasEmailIntegration")]
        public bool HasEmailIntegration { get; set; } = false;

        [JsonProperty("contact")]
        public bool Contact { get; set; } = false;

        [JsonProperty("hasAudienceOverlap")]
        public bool HasAudienceOverlap { get; set; } = false;

        [JsonProperty("creditsTopupAmount")]
        public long CreditsTopupAmount { get; set; } = 0;

        [JsonProperty("hasRawApiInstagram")]
        public bool HasRawApiInstagram { get; set; } = false;

        [JsonProperty("hasRawApiTiktok")]
        public bool HasRawApiTiktok { get; set; } = false;

        [JsonProperty("hasRawApiYoutube")]
        public bool HasRawApiYoutube { get; set; } = false;

        [JsonProperty("hasDiscoveryApi")]
        public bool HasDiscoveryApi { get; set; } = false;

        [JsonProperty("rawRequests")]
        public long RawRequests { get; set; } = 0;

        [JsonProperty("rawRatelimit")]
        public long RawRatelimit { get; set; } = 0;

        [JsonProperty("discoveryRatelimit")]
        public long DiscoveryRatelimit { get; set; } = 0;

        [JsonProperty("shopifyOnly")]
        public bool ShopifyOnly { get; set; } = false;

        [JsonProperty("$isMongooseDocumentPrototype")]
        public bool IsMongooseDocumentPrototype { get; set; } = false;

        [JsonProperty("$isNew")]
        public bool IsNew { get; set; } = false;

    }

}
