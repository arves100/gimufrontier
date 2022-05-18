using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record DailyTaskMST
    {
        [JsonPropertyName("O36Qv37k")]
        public string Key = "";

        [JsonPropertyName("hd2Jf3nC")]
        public string Title = "";

        [JsonPropertyName("M7yKr4c1")]
        public string Description = "";

        [JsonPropertyName("Y3DbX5ot")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Count;

        [JsonPropertyName("T4bV8aI9")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint BPReward;

        [JsonPropertyName("a3011F8b")]
        public string TaskAreas = "";

        [JsonPropertyName("9cKyb15U")]
        public uint Unknown;
    }
}
