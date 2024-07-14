using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Influencer {

    public class InfluencerPlatformData {

        [JsonProperty("engagementRate")]
        public double EngagementRate { get; set; } = 0.0;

        [JsonProperty("engagements")]
        public long Engagements { get; set; } = 0;

        [JsonProperty("followers")]
        public long Followers { get; set; } = 0;

        [JsonProperty("fullname")]
        public string Fullname { get; set; } = string.Empty;

        [JsonProperty("picture")]
        public string Picture { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; } = false;

        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; } = false;

    }

}
