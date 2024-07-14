using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Influencer {

    public class InfluencerProfileData {

        [JsonProperty("userId")]
        public string UserId { get; set; } = string.Empty;

        [JsonProperty("profile")]
        public InfluencerPlatformData Profile { get; set; } = new();

    }

}
