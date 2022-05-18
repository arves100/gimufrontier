using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record ResponseMST
    {
        [JsonPropertyName("moWQ30GH")]
        public string Id = "";

#if false
        [JsonPropertyName("e3QNsuZ8")]
        public string Description = "";
#endif

        [JsonPropertyName("d2RFtP8T")]
        public uint Version;

        [JsonPropertyName("H6k1LIxC")]
        public uint Unknown;

        [JsonPropertyName("5kbnkTp0")]
        public uint SubVersion;
    }
}
