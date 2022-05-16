using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action
{
    /// <summary>
    /// Type of error IDs
    /// </summary>
    public enum ErrorID
    {
        No = 0,
        Yes = 1,
        ForceClose = 3,
    }

    /// <summary>
    /// Operation to do in case of an error
    /// </summary>
    public enum ErrorOperation
    {
        Retry = 2,
        Continue = 3,
        Close = 4,
        Close_2 = 5,
        ReturnToGame = 6,
        RaidError = 7,
        Continue_2 = 8,
        LogoutFacebook = 9,
        Close_3 = 10,
    }

    /// <summary>
    /// action.php data header
    /// </summary>
    public record ActionHeader
    {
        /// <summary>
        /// ID of the client that is connected
        /// 
        /// For server data: this parameter is always "---"
        /// </summary>
        [JsonPropertyName("aV6cLn3v")]
        public string Id = "---";

        /// <summary>
        /// Request ID
        /// </summary>
        [JsonPropertyName("Hhgi79M1")]
        public string Request = "";

        [JsonPropertyName("4wij8ArG")]
        public string Unknown = "{}";

        [JsonPropertyName("j0Uszek2")]
        public int Unknown2 = 1;
    }

    /// <summary>
    /// action.php data body
    /// </summary>
    public class ActionBody
    {
        /// <summary>
        /// Encrypted JSON data
        /// </summary>
        [JsonPropertyName("Kn51uR4Y")]
        public string? Data { get; set; }
    }


    /// <summary>
    /// action.php error data
    /// </summary>
    public record ActionError
    {
        /// <summary>
        /// Error ID
        /// </summary>
        [JsonPropertyName("3e9aGpus")]
        [JsonConverter(typeof(JsonEnumStringIntConverter))]
        public ErrorID Id = ErrorID.No;

        [JsonPropertyName("iPD12YCr")]
        [JsonConverter(typeof(JsonEnumStringIntConverter))]
        public ErrorOperation Operation = ErrorOperation.Continue;

        [JsonPropertyName("ZC0msu2L")]
        public string ErrorMessage = "";

        [JsonPropertyName("zcJeTx18")]
        public string Unknown = "";
    }

    public record ExchangeData
    {
        [JsonPropertyName("F4q6i9xe")]
        public ActionHeader Header = new();

        [JsonPropertyName("a3vSYuq2")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionBody? Body = null;

        [JsonPropertyName("b5PH6mZa")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionError? Error = null;

        public static ExchangeData GenError(ErrorID id, ErrorOperation op, string msg)
        {
            return new ExchangeData()
            {
                Error = new ActionError
                {
                    Id = id,
                    Operation = op,
                    ErrorMessage = msg,
                    Unknown = ""
                }
            };
        }
    }
}
