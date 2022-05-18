using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{

    public record UserProgress
    {
        [JsonPropertyName("h7eY3sAK")]
        public string UserId = "";

        [JsonPropertyName("D9wXQI2V")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Level = 1;

        [JsonPropertyName("d96tuT2E")]
        [JsonConverter(typeof(JsonStringULongConverter))]
        public ulong Exp;

        [JsonPropertyName("YnM14RIP")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown2; // max action point?

        [JsonPropertyName("0P9X1YHs")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown3; // action point?

#if false // not present in game code anymore
        [JsonPropertyName("V0yJS7vZ")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown1;
#endif

        [JsonPropertyName("f0IY4nj8")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown4; // action rest timer?

        [JsonPropertyName("9m5FWR8q")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown5; // max fight point?

        [JsonPropertyName("YS2JG9no")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown6; // fight point?

        [JsonPropertyName("32HCWt51")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint VortexArenaOrbTime;

        [JsonPropertyName("jp9s8IyY")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown7; // fight reset timer?

        [JsonPropertyName("ouXxIY63")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint MaxUnitCount;

        // max unit increased with the gems
        [JsonPropertyName("Px1X7fcd")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint IncreasedMaxUnitCount;

        [JsonPropertyName("QYP4kId9")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ActiveSquadCost;

        [JsonPropertyName("Z0Y4RoD7")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ActiveSquadId;

        [JsonPropertyName("gKNfIZiA")]
        public uint ActiveArenaSquad;

        [JsonPropertyName("TwqMChon")]
        // TODO: make an array converter
        public string Unknown8 = "-1,-99,-99"; // reinforcement deck + ex1 + ex2??

        [JsonPropertyName("3u41PhR2")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint MaxFriendCount;

        [JsonPropertyName("2rR5s6wn")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint IncreasedMaxFriendCount;

        [JsonPropertyName("5pjoGBC4")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint WarehouseCount1;

        [JsonPropertyName("iI7Wj6pM")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint WarehouseCount2;

        [JsonPropertyName("J3stQ7jd")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint HonorPoints;

        [JsonPropertyName("Najhr8m6")]
        [JsonConverter(typeof(JsonStringULongConverter))]
        public ulong Zel;

        [JsonPropertyName("HTVh8a65")]
        [JsonConverter(typeof(JsonStringULongConverter))]
        public ulong Karma;

        [JsonPropertyName("03UGMHxF")]
        public uint Unknown9; // brave coin?

        [JsonPropertyName("bM7RLu5K")]
        public string FriendMessage = "";

        [JsonPropertyName("s2WnRw9N")]
        public string FriendWantGiftId = "0,0,0,0,0"; // TODO: make an array converter

        [JsonPropertyName("EfinBo65")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown10; // present count

        [JsonPropertyName("qVBx7g2c")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown11; // friend agree cnt

        [JsonPropertyName("1RQT92uE")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown12; // gift receive cnt

#if false // not present in current game code (perhaps it's last login?)
        [JsonPropertyName("kW5QuUz7")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown13; // my value was 20220422
#endif

        [JsonPropertyName("3w6YDS4z")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ConsecutiveDaysLogin;

        [JsonPropertyName("lKuj3Ier")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ColosseumTickets;

        [JsonPropertyName("JmFn3g9t")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ArenaRankId;

        [JsonPropertyName("9r3aLmaB")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint SummonTickets;

        [JsonPropertyName("bya9a67k")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint TotalBravePoints;

        [JsonPropertyName("22rqpZTo")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint CurrentBravePoints;

        [JsonPropertyName("KAZmxkgy")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown14; // rainbow coin

        [JsonPropertyName("AKP8t3xK")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint CAUnknown;

        [JsonPropertyName("Nou5bCmm")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint CAUnknown2;

        [JsonPropertyName("s3uU4Lgb")]
        public uint SlotGameFlag; // TODO: discover this flags

        [JsonPropertyName("3a8b9D8i")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint CompletedDailyTasksCount;

        [JsonPropertyName("7qncTHUJ")]
        public uint Unknown15;// inbox message cnt

#if false // not present in game code anymore
        [JsonPropertyName("38d7D18b")]
        public uint Unknown16;

        [JsonPropertyName("D38bda8B")]
        public uint Unknown17;
#endif

        [JsonPropertyName("Qo9doUsp")]
        public uint MysteryBoxCount;

        [JsonPropertyName("d37CaiX1")]
        public uint PaidGemsCount;

        [JsonPropertyName("92uj7oXB")]
        public uint FreeGemsCount;
    }

    // zI2tJB7R -> user team archive
    // PQ56vbkI -> user team arena archive
    // dX7S2Lc1 -> user party squad info
    // GV81ctzR -> user unit dictionary??
    // 3kcmQy7B -> favourite unit info
    // UT1SVg59 -> cleared mission info??
    // 9wjrh74P -> wharehouse info???
    // VSRPkdId -> favourite item info
    // bd5Rj6pN -> user item dictionary info??
    // 8jBJ7uKR -> user arena info 
    // d98mjNDc -> sound info?
    // 6C0kzwM5 -> brave medal info
    // Bnc4LpM8 -> achievement info
    // yXNM8kL3 -> permit place??
    // Y73tHKS8 -> permit place sp???
    // Y73mHKS8 - permit place ml ???
    // YRgx49WG -> town facility info
    // yj46Q2xw -> town location info
    // s8TCo2MS -> town location detail info
    // 51yQrDBR -> permit receipe???
    // 1IR86sAv -> gatcha info
    // Bm1WNDQ0 -> gift mst
    // eFU7Qtb0 -> dungeon key info
    // 5PR2VmH1 -> mission break info??
    // 1ry6BKoe -> raid user info
    // 4W6EhXLS -> user purchase info??
    // Dp0MjKAf -> user release info ??
    // 6FrKacq7 -> signal key info???
    // 71U5wzhI -> equip info??
    // nAligJSQ -> equip boost item??
    // 30uygM9m -> received gift info
    // Md9gG3c0 -> general event MST
    // yNnvj59x -> npc info MST
    // 6e4b7sQt -> friend point info??
    // n5mdIUqj -> summoner info
    // dhMmbm5p -> summoner arms info??
    // 8UawtzHw -> first squad mst
    // 2375D38i -> feature gating info??
    // 62Dz13dP -> unknown/not present in game code
    // M3dw18eB -> summoner journal user info
    // a3d5d12i -> second type summon ticket info
    // hE1d083b -> second type summon ticket mst
    // da3qD39b -> resummon summon mst
    // l234vdKs -> event token info
    // sxorQ3Mb -> ddb unit info
    // tR4katob -> ddb unit level info
    // 3aDk1xk7 -> excluded dungeon mst

    public record VideoAdInfoResponse
    {
        [JsonPropertyName("k3ab6D82")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint VideoId;

        [JsonPropertyName("Diwl3b56")]
        public uint IsAvailable;

        [JsonPropertyName("Y3de0n2p")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint RegionId; // TODO: which regions

        [JsonPropertyName("26adZ1iy")]
        public uint IsEnabled;

        [JsonPropertyName("oohpPLCt")]
        public uint NextAvailableTimeLeft;
    }

    public record VideoAdsRegion
    {
        [JsonPropertyName("Y3de0n2p")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Id;

        [JsonPropertyName("j3d6E2ia")]
        public string Regions = "US,JP,SG";
    }

    public record UserLoginCampaignInfo
    {
        [JsonPropertyName("H1Dkq93v")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint CampaignId;

        [JsonPropertyName("ad6i23pO")]
        public uint TotalDaysLoggedIn;

        [JsonPropertyName("1adb38d5")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint TotalCampaignDays;

        [JsonPropertyName("4tswNoV9")]
        public uint Unknown = 1; // First of the day?
    }

    public record UserInfoResponse
    {
        [JsonPropertyName("IKqx1Cn9")]
        public GeneralUserInfo[]? UserData;

        [JsonPropertyName("fEi17cnx")]
        public UserProgress[]? Progress;

#if false // does not seem to be parsed anymore
        [JsonPropertyName("4ZfpSQv1")]
        public UserSoundInfo[]? SoundInfo;
#endif

        [JsonPropertyName("Pj6zDW3m")]
        public NoticeInfoResponse? NoticeInfo;

        [JsonPropertyName("3da6bd0a")]
        public UserLoginCampaignInfo[]? UserLoginCampaign;

        [JsonPropertyName("bpD29eiQ")]
        public VideoAdsRegion[]? VideoConfig = new VideoAdsRegion[1]
        {
            new VideoAdsRegion(),
        };

        [JsonPropertyName("4ceMWH6k")]
        public UnitInfoResponse[]? UnitInfos;

        [JsonPropertyName("j129kD6r")]
        public VideoAdInfoResponse[]? VideoAdInfos = new VideoAdInfoResponse[2]
        {
            new VideoAdInfoResponse
            {
                IsAvailable = 1,
                IsEnabled = 1,
                NextAvailableTimeLeft = 1650672000,
                VideoId = 998,
            },
            new VideoAdInfoResponse
            {
                IsEnabled = 1,
                IsAvailable = 1,
                NextAvailableTimeLeft = 1650628800,
                VideoId = 999,
            },
        };
    }
}
