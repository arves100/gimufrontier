using System.Text.Json.Serialization;

namespace gimufrontier.Models.GumiApi
{
    public class SREE
    {
        [JsonPropertyName("SREE")]
        public string? Data { get; set; }
    }
}
