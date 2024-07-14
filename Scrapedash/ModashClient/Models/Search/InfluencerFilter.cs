using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Search {

    public class InfluencerFilter {

        [JsonProperty("influencer")]
        public InfluencerFilterInfluencer Influencer { get; set; } = new();

        [JsonProperty("options")]
        public InfluencerSearchOptions Options { get; set; } = new();

    }

}
