using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record DailyWheelInfo
    {
        [JsonPropertyName("XIvaD6Jp")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Id;

        [JsonPropertyName("35JXN4Ay")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown; // current user count??

        [JsonPropertyName("5xStG99s")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Unknown2 = 5; // user limit count??

        [JsonPropertyName("ad6i23pO")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint CurrentDay;

        [JsonPropertyName("u8iD6ka7")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint RemainingDaysToGuaranteedGem;

        [JsonPropertyName("ZC0msu2L")]
        public string GuaranteedGemMessage = " day(s) more to guaranteed Gem!";

        [JsonPropertyName("outas79f")]
        public string Unknown3 = "";
    }
}
