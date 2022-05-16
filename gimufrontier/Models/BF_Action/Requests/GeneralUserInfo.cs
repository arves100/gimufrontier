using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Requests
{
    public record GeneralUserInfo
    {
        [JsonPropertyName("B5JQyV8j")]
        public string Username = "";

        [JsonPropertyName("iN7buP0j")]
        public string DeviceName = "";

        [JsonPropertyName("h7LYasNK")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LanguageValue Language = LanguageValue.en;

        /*
         * I remember older version of BF had a Gumi Live endpoint (like live.gumi.sg/api/1.1)
         * So perhaps this is the token used to connect it with the Gumi Live API
         * Therefore this seems to be an old parameter not used anymore
         */
        [JsonPropertyName("iN7buP1i")]
        public string GumiLiveToken = "";

        // See GumiLiveToken
        [JsonPropertyName("iN7buP2h")]
        public string GumiLiveUserId = "";

        [JsonPropertyName("K29dp2Q")]
        public string GumiLiveFacebookId = "";

        [JsonPropertyName("nrg19RGe")]
        public string Unknown4 = ""; //  SaveData::getModeChangeCnt

        [JsonPropertyName("90LWtVUN")]
        public string Unknown5 = ""; // SaveData::getContactID

        [JsonPropertyName("Ma5GnU0H")]
        public string VersionGUID = "";

        [JsonPropertyName("DFY3k6qp")]
        [JsonConverter(typeof(JsonEnumStringIntConverter))]
        public OSValue OS = OSValue.Android;

        [JsonPropertyName("6K7LToCD")]
        public string DeviceAdsGUID = "";
    }
}
