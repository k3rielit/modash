using Newtonsoft.Json;

namespace ModashClient.Models.User {

    public class ModashUserSettings {

        [JsonProperty("confirmRemoveInfluencer")]
        public bool ConfirmRemoveInfluencer { get; set; } = true;

        [JsonProperty("isSubscribedToNewsletter")]
        public bool IsSubscribedToNewsletter { get; set; } = false;

    }

}
