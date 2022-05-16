using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Requests
{
    public record SignalKeyRequest
    {
        [JsonPropertyName("Kn51uR4Y")]
        public string SignalKeyTag = "";
    }

    public record UserInfoRequest
    {
        [JsonPropertyName("IKqx1Cn9")]
        public GeneralUserInfo[]? UserInfos;

        [JsonPropertyName("KeC10fuL")]
        public RequestMST[]? MST;

        [JsonPropertyName("6FrKacq7")]
        public SignalKeyRequest[]? SignalKeys;
    }
}
