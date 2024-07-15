using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.Models.Influencer {

    public class CompactInfluencerProfile {

        public string Id { get; set; } = string.Empty;
        public string ProfileType { get; set; } = string.Empty;
        public string ProfileId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public double EngagementRate { get; set; } = 0.0;
        public long Engagements { get; set; } = 0;
        public long Followers { get; set; } = 0;
        public string Fullname { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool IsVerified { get; set; } = false;
        public bool IsPrivate { get; set; } = false;

    }

}
