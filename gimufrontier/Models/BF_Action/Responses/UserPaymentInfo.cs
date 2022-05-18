using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record UserPaymentInfo
    {
        [JsonPropertyName("P_LAST_PURCHASE")]
        public uint LastPurchaseDate;
    }
}
