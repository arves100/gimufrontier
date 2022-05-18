using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record UnitInfoResponse
    {
        [JsonPropertyName("h7eY3sAK")]
        public string UserId = "";

        [JsonPropertyName("edy7fq3L")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown; // Update EF?? Is this Delta time update???? Why here??????

        [JsonPropertyName("pn16CNah")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint InternalUnitId;

        [JsonPropertyName("nBTx56W9")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint UnitType;

        [JsonPropertyName("D9wXQI2V")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Level;

        [JsonPropertyName("d96tuT2E")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Exp;

        [JsonPropertyName("gQInj3H6")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint TotalExp;

        [JsonPropertyName("e7DK0FQT")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint BaseHP;

        [JsonPropertyName("cuIWp89g")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint AddHp;

        [JsonPropertyName("TokWs1B3")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ExtHp;

        [JsonPropertyName("ISj9u5VL")]
        public uint LimitOverHp;

        [JsonPropertyName("67CApcti")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint BaseAtk;

        [JsonPropertyName("RT4CtH5d")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint AddAtk;

        [JsonPropertyName("t4m1RH6Y")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ExtAtk;

        [JsonPropertyName("D6bKH5eV")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint LimitOverAtk;

        [JsonPropertyName("q08xLEsy")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint BaseDef;

        [JsonPropertyName("GcMD0hy6")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint AddDef;

        [JsonPropertyName("e6mY8Z0k")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ExtDef;

        [JsonPropertyName("3CsiQA0h")]
        public uint LimitOverDef;

        [JsonPropertyName("PWXu25cg")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint BaseHeal;

        [JsonPropertyName("C1HZr3pb")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint AddHeal;

        [JsonPropertyName("X6jf8DUw")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ExtHeal;

        [JsonPropertyName("XJs2rPx0")]
        public uint LimitOverHeal;

#if false // not parsed anymore
        [JsonPropertyName("xujp1nz2")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown;
#endif

        [JsonPropertyName("iNy0ZU5M")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Element;

        [JsonPropertyName("oS3kTZ2W")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint LeaderSkillId;

        [JsonPropertyName("nj9Lw7mV")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint SkillId;

        [JsonPropertyName("3NbeC8AB")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint UnitId;

        [JsonPropertyName("iEFZ6H19")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ExtraSkillId;

        [JsonPropertyName("RQ5GnFE2")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint SkillLv;

#if false

        [JsonPropertyName("Ge8Yo32T")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown3;

        [JsonPropertyName("RXfC31FA")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown3;

        [JsonPropertyName("mZA7fH2v")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown3;

        [JsonPropertyName("Bvkx8s6M")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown4;

#endif

        [JsonPropertyName("Bvkx8s6M")]
        public uint ReceiveDate;

        [JsonPropertyName("0R3qTPK9")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint EquipItemFrameID;

        [JsonPropertyName("Ge8Yo32T")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint EquipItemID;

        [JsonPropertyName("RXfC31FA")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint EquipItemFrameID2;

        [JsonPropertyName("mZA7fH2v")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint EquipItemID2;

        [JsonPropertyName("dJNpLc81")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint NewFlg;

        [JsonPropertyName("DbMVG16I")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown4;

        [JsonPropertyName("cP83zNsv")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ExtraPassiveSkillID;

        [JsonPropertyName("LjY4DfRg")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint ExtraPassiveSkillID2;

        [JsonPropertyName("T4rewHa9")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint AddExtrPassiveSkillID;

        [JsonPropertyName("2pAyFjmZ")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint UnitImgType;

        [JsonPropertyName("bFQbZh3x")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? FeBP;

        [JsonPropertyName("3RgneFpP")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? FeUsedBP;

        [JsonPropertyName("GIO9DTif")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? FeMaxUsableBP;

        [JsonPropertyName("Fnxab5CN")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? FeSkillInfo;

        [JsonPropertyName("49sa3sld")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? OmniLevel;
    }
}
