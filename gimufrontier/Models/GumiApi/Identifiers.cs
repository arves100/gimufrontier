using System.Text.Json.Serialization;

namespace gimufrontier.Models.GumiApi
{
    public record Identifiers
    {
        [JsonPropertyName("android_id")]
        public string AndroidId = "";
    }
}
