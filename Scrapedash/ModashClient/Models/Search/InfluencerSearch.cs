using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Search {

    public class InfluencerSearch {

        [JsonProperty("page")]
        public ulong Page { get; set; } = 0;

        [JsonProperty("filters")]
        public InfluencerFilter Filters { get; set; } = new();

        public void Range(ulong min, ulong max) {
            // The min and max values can only be "0" or "...k".
            // 3 million is 3000k.
            // Any invalid range will return the sample result.
            Filters.Influencer.Followers.Min = min == 0 ? "0" : $"{min}k";
            Filters.Influencer.Followers.Max = max == 0 ? "0" : $"{max}k";
        }

    }

}
