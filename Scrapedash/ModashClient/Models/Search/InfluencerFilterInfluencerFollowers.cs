using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Search {

    public class InfluencerFilterInfluencerFollowers {


        [JsonProperty("min")]
        public string Min { get; set; }

        [JsonProperty("max")]
        public string Max { get; set; }

    }

}
