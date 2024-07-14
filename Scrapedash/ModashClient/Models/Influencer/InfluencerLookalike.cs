using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Influencer {

    public class InfluencerLookalike {


        [JsonProperty("_id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("profileType")]
        public string ProfileType { get; set; } = string.Empty;

        [JsonProperty("profileData")]
        public InfluencerProfileData ProfileData { get; set; } = new();

        [JsonProperty("profileId")]
        public string ProfileId { get; set; } = string.Empty;

    }

}
