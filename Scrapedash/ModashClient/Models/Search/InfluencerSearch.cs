using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Search {

    public class InfluencerSearch {

        [JsonProperty("page")]
        public long Page { get; set; } = 0;

        [JsonProperty("filters")]
        public InfluencerFilter Filters { get; set; } = new();

    }

}
