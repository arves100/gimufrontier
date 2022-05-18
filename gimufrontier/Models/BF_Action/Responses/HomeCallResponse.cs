using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record HomeCallResponse
    {
        [JsonPropertyName("T_USER_PAYMENT_INFO")]
        public UserPaymentInfo? PaymentInfo;

        [JsonPropertyName("Pj6zDW3m")]
        public NoticeInfoResponse? NoticeInfo;

        [JsonPropertyName("Nebq4d8x")]
        public GuildRaidRoundInfo? RaidRoundInfo;

        [JsonPropertyName("6FrKacq7")]
        public SignalKeyInfo[]? SignalKeyInfo;
    }
}
