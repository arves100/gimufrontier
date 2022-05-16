using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Requests
{
    public record RequestMST
    {
        [JsonPropertyName("moWQ30GH")]
        public string Name = "";

        [JsonPropertyName("d2RFtP8T")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Value;
    }
}
