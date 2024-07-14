using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Influencer {

    public class InfluencerSearchResult {

        [JsonProperty("error")]
        public bool Error { get; set; } = true;

        [JsonProperty("total")]
        public long Total { get; set; } = 0;

        [JsonProperty("lookalikes")]
        public List<InfluencerLookalike> Lookalikes { get; set; } = new();

        //[JsonProperty("directs")]
        //public List<object> Directs { get; set; }

        //[JsonProperty("notFoundDirects")]
        //public List<object> NotFoundDirects { get; set; }

        //[JsonProperty("metadatas")]
        //public List<object> Metadatas { get; set; }

        //[JsonProperty("nextPageEnabled")]
        //public bool NextPageEnabled { get; set; }

        //[JsonProperty("isDefaultSearch")]
        //public bool IsDefaultSearch { get; set; }

        [JsonProperty("currentPage")]
        public long CurrentPage { get; set; } = 0;

        //[JsonProperty("couldSearch")]
        //public bool CouldSearch { get; set; }

        [JsonProperty("pages")]
        public long Pages { get; set; } = 0;

        //[JsonProperty("hasChargedUser")]
        //public bool HasChargedUser { get; set; }

    }

}
