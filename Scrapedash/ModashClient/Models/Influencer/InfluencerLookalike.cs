using Newtonsoft.Json;

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

        public CompactInfluencerProfile Compact() {
            return new CompactInfluencerProfile {

                Id = Id,
                ProfileType = ProfileType,
                ProfileId = ProfileId,

                UserId = ProfileData.UserId,

                EngagementRate = ProfileData.Profile.EngagementRate,
                Engagements = ProfileData.Profile.Engagements,
                Followers = ProfileData.Profile.Followers,
                Fullname = ProfileData.Profile.Fullname,
                Picture = ProfileData.Profile.Picture,
                Url = ProfileData.Profile.Url,
                Username = ProfileData.Profile.Username,
                IsVerified = ProfileData.Profile.IsVerified,
                IsPrivate = ProfileData.Profile.IsPrivate,

            };
        }

    }

}
