using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Requests
{
    public record InitializeRequest
    {
        [JsonPropertyName("IKqx1Cn9")]
        public GeneralUserInfo[]? UserInfos;

        [JsonPropertyName("KeC10fuL")]
        public RequestMST[]? MST;
    }
}
