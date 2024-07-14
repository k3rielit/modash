using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Search {

    public class InfluencerSearchOptions {

        [JsonProperty("showSavedProfiles")]
        public bool ShowSavedProfiles { get; set; } = true;

    }

}
