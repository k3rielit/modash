using Newtonsoft.Json;

namespace ModashClient.Models.User {

    public class ModashUserMonitoring {

        [JsonProperty("trackedInfluencers")]
        public long TrackedInfluencers { get; set; } = 0;

    }

}
