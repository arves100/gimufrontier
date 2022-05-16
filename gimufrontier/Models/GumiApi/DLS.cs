using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.GumiApi
{
    public class DLS
    {
        [JsonPropertyName("game")]
        public string? Ip { get; set; }

        [JsonPropertyName("resource")]
        public string? CdnIp { get; set; }

        [JsonPropertyName("mstv")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint GameVersion { get; set; }

        [JsonPropertyName("gumilive")]
        public string? LoginApi { get; set; }

        [JsonPropertyName("bgimage")]
        public string? BackgroundImg { get; set; }
    }
}
