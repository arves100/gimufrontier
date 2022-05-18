using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record DailyBPInfo
    {
        [JsonPropertyName("k3bD738b")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint DailyAccumulatedBravePoints;
    }

    public record LoginCampaignInfo
    {
        [JsonPropertyName("H1Dkq93v")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Id;

        [JsonPropertyName("qA7M9EjP")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint StartDate; // TODO: Add DateTime to UnixTime Epoch string converter

        [JsonPropertyName("1adb38d5")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint DuringDays;

        [JsonPropertyName("b38adb8i")]
        public string BannerPath = "";
    }

    public record LoginCampaignData
    {
        [JsonPropertyName("H1Dkq93v")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint MstId;

        [JsonPropertyName("n0He37p1")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Day;

        [JsonPropertyName("b38adb8i")]
        public string RewardImage = "";
    }

    public record LevelProgressionInfo
    {
        [JsonPropertyName("D9wXQI2V")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Id;

        [JsonPropertyName("d96tuT2E")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint RequiredExp;

        [JsonPropertyName("0P9X1YHs")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown; // What is ActionP ?

#if false // not parsed anymore
        [JsonPropertyName("YS2JG9no")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint SquadCost = 3;
#endif

        [JsonPropertyName("ziex06DY")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint SquadCost;

        [JsonPropertyName("oFQ3mbS6")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint MaxFriends;

        [JsonPropertyName("GZ2rKW90")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint MaxAddableFriends;
    }

    public record GuildInfo
    {
        [JsonPropertyName("sD73jd20")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Id = 0;

        [JsonPropertyName("s35idar9")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name;

        [JsonPropertyName("qp37xTDh")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description;

        [JsonPropertyName("dDKCN293")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? ArtId;

        [JsonPropertyName("osidufj5")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Level;

        [JsonPropertyName("P_RANK")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Rank;

        [JsonPropertyName("sc83dkh3")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? PrestigePoints;

        [JsonPropertyName("SivJ9sL9")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Members;

        [JsonPropertyName("Nt38aDqi")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? MaxMemberCount;

        [JsonPropertyName("aBcniqj8")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MasterName;

        [JsonPropertyName("Siv49s0l")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Exp;

        [JsonPropertyName("39bDai1y")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? ObtainedExp;

        [JsonPropertyName("o94cnA8P")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CreationDate;
    }

    // XGmGpmYW -> challenge arena
    // a739yK18 -> daily task prize?
    // Pk5F1vhx -> banner info
    // M3dw18eB -> Summoner journal??
    // JYFGe9y6 -> unit exp pattern mst
    // z5U7utsm -> extra skill mst
    // 4NG79sX1 -> dungeon key mst
    // 5Y4GJeo3 -> summon mst
    // Pf97SzVw -> summon effect
    // 8f0bCciN -> crafting mst
    // VkoZ5t3K -> define mst????
    // 1NTG2oVZ -> thophy group mst????
    // 6CTU8m2v -> trophy mst????
    // Ked15IpH -> throphy grade mst???
    // 5nBa3CAe -> translation mst
    // Lh1I3dGo -> town facility mst???
    // d0EkJ4TB -> town facility lv mst???
    // 1y2JDv79 -> town location mst???
    // 9ekQ4tZq -> town location lv mst???
    // 9x4zZCeN -> help mst???
    // 5C9LuNrk -> help sub mst???
    // 6kWq78zx -> arena rank mst
    // 36Sd0Aub -> sound mst
    // hV5vWu6C -> npc mst???
    // At7Gny2V -> URL mst
    // mQC4s5ka -> challenge mst???
    // h09mEvDR -> challenge hr mst???
    // 5M8jI4cP -> challenge mis mst????
    // zW1i02aG -> challenge grade mst???
    // 4C1Wt8sS -> challenge reward mst???
    // dn0NfRy1 -> challenge item mst????
    // nUmaEC41 -> challenge mvp mst????
    // P8V71kbw -> challenge rank reward mst????
    // B8lchAPr -> interactive banner info mst???

    public record InitializeResponse
    {
        [JsonPropertyName("IKqx1Cn9")]
        public GeneralUserInfo[]? UserData;

#if false // does not seem to be parsed anymore
        [JsonPropertyName("4ZfpSQv1")]
        public UserSoundInfo[]? SoundInfo;
#endif

        [JsonPropertyName("p283g07d")]
        public DailyBPInfo[]? BPInfo;

        // --- BEGIN MST
        [JsonPropertyName("Bd29Pqw0")]
        public LoginCampaignInfo[]? CampaignInfo;

        [JsonPropertyName("bD18x9Ti")]
        public LoginCampaignData[]? CampaignData;

        [JsonPropertyName("Pj6zDW3m")]
        public NoticeInfoResponse? NoticeInfo;

        [JsonPropertyName("Drudr2w5")]
        public DailyWheelInfo? DailyWheel;

        [JsonPropertyName("k23D7d43")]
        public DailyTaskMST[]? Tasks;

        [JsonPropertyName("mebW7mKD")]
        public VideoSlotConfig[]? VideoSlot;

        [JsonPropertyName("IkdSufj5")]
        public GuildInfo? Guild;

        [JsonPropertyName("YDv9bJ3s")]
        public LevelProgressionInfo[]? ProgressInfo;

        [JsonPropertyName("KeC10fuL")]
        public ResponseMST[]? MSTVersion;
        // --- END MST
    }

    // TODO: MST
}

