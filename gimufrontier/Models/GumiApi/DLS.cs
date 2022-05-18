using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.GumiApi
{
    public record DLS
    {
        [JsonPropertyName("game")]
        public string Ip = "";

        [JsonPropertyName("resource")]
        public string CdnIp = "";

        [JsonPropertyName("mstv")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint GameVersion;

        [JsonPropertyName("gumilive")]
        public string LoginApi = "";

        [JsonPropertyName("bgimage")]
        public string BackgroundImg = "";

        // Foces the game to show a message and then exit
        [JsonPropertyName("force")]
        [JsonConverter(typeof(JsonStringBoolConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Force = null;

        // Message to show
        [JsonPropertyName("force_msg")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ForceMsg = null;

    }
}
