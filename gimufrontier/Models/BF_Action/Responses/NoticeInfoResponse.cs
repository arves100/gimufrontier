using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record NoticeInfoResponse
    {
        [JsonPropertyName("xJNom6i0")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint Id;

        [JsonPropertyName("jsRoN50z")]
        public string NoticeUrl = "";
    }
}
