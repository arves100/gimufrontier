using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record GeneralUserInfo
    {
        [JsonPropertyName("h7eY3sAK")]
        public string UserId = "";

        [JsonPropertyName("B5JQyV8j")]
        public string Username = "";

        [JsonPropertyName("LZ2PfNm4")]
        public string AccountId = "";

        [JsonPropertyName("4WSu1irc")]
        public string Password = "";

        [JsonPropertyName("nrg19RGe")]
        public string Unknown = ""; // ModelChangeUserInfo::setModelChangeCnt(v7, v25);

        [JsonPropertyName("iyJH5k6p")]
        public string ExpireMigrationCode = "";

        [JsonPropertyName("98WfKiyA")]
        public string FriendId = "";

        [JsonPropertyName("90LWtVUN")]
        public string Unknown2 = ""; // UserInfo::setContactId

        [JsonPropertyName("DFY3k6qp")]
        [JsonConverter(typeof(JsonEnumStringIntConverter))]
        public OSValue OS = OSValue.Android;

        [JsonPropertyName("iN7buP0j")]
        public string DeviceName = "";

#if false // this parameters doesn't seem to get parsed by BF Global, perhaps they were used in EU?
        [JsonPropertyName("Ma5GnU0H")]
        public string VersionGUID = "";

        [JsonPropertyName("dzhBs92A")]
        public string Unknown4 = "";

        [JsonPropertyName("hceYTcAK")]
        public string Unknown5  = ""; // I think this is the real phone language

        [JsonPropertyName("h7LYasNK")]
        public string Language  = "";
#endif

        [JsonPropertyName("9sQM2XcN")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint TutorialChapter; // 12 = last chapter

        [JsonPropertyName("sv6BEI8X")]
        [JsonConverter(typeof(JsonStringBoolConverter))]
        public bool FinishedTutorial; // 1 = finished, 0 = not finished

#if false // this is not present in the game code anymore, I belive this is an old version behavour
        [JsonPropertyName("6W5Jbrse")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown6; // my value for this was 0

        [JsonPropertyName("iN7cCN9i")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown7; // my value for this was 1421476427
#endif

        /*
         * Looking at game code, this is logged as "P_EARLYBIND_END",
         * searching online this might be related to the Guild early bird end
         * (which I have no idea about)
         */
        [JsonPropertyName("iN7cYU9i")]
        public uint Unknown8;

#if false // this is not present in the game code anymore
        [JsonPropertyName("iN7cTP9i")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown9; // my value for this was 0
#endif

        [JsonPropertyName("N4XVE1uA")]
        public string Unknown10 = ""; // UserScenarioInfoList::parse

        [JsonPropertyName("9yVsu21R")]
        public string Unknown11 = ""; // UserSpecialScenarioInfoList::parse

        [JsonPropertyName("7oV00FeR")]
        public string Unknown12 = ""; // I think this is the friend description add

        [JsonPropertyName("y2v7Sd01")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint FriendInvitationFlag; // TODO: discover the flag values

        /*
         * I don't get the existance of this parameter, if BF cryptation are done in
         * AES ECB, then there is no need for an IV, perhaps it's an old/unused option
         */
        [JsonPropertyName("8kN1tgYU")]
        public string EncryptIV = "";

        // TODO: encrypted for/with what?
        [JsonPropertyName("PA0QwZs1")]
        public string EncryptedFriendId = "";

        // hehe I wonder what this does :)
        [JsonPropertyName("5MPcr0sp")]
        [JsonConverter(typeof(JsonIntBoolConverter))]
        public bool DebugMode;

        // See GumiLiveToken
        [JsonPropertyName("iN7buP2h")]
        public string GumiLiveUserId = "";

        /*
         * I remember older version of BF had a Gumi Live endpoint (like live.gumi.sg/api/1.1)
         * So perhaps this is the token used to connect it with the Gumi Live API
         * Therefore this seems to be an old parameter not used anymore
         */
        [JsonPropertyName("iN7buP1i")]
        public string GumiLiveToken = "";

        [JsonPropertyName("K29dp2Q")]
        public uint GumiLiveFacebookId;

#if false // not present in game code anymore
        [JsonProperty("k29akH2I")]
        public string Unknown13 = "";
#endif

#if false // not parsed anymore
        [JsonProperty("j2lk52Be")]
        public uint BuildId;

        [JsonProperty("37d2Hi5p")]
        public uint SkipTutorial;
#endif

        [JsonPropertyName("236dItKo")]
        public string GumiLiveUnknown = ""; // Referenced as mInfo in game code

#if false // not parsed anymore
        [JsonPropertyName("fKSzGDFb")]
        public string Unknown14 = ""; // Referenced as pointer name in game code
#endif

        [JsonPropertyName("a37D29iJ")]
        public uint Unknown15; // FeatureGatingHandler::setFeatureGate

        [JsonPropertyName("32k0ahkD")]
        public string Unknown16 = "";
    }

}
