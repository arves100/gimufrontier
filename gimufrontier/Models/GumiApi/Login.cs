using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.Login
{
    /// <summary>
    /// Login status
    /// </summary>
    public enum LoginStatus
    {
        successful = 0,
        error = 1,
    }

    public enum LoginStatusId
    {
        Success = 0,
        Failed = 1,
        InvalidAk = 15,
    }

    /// <summary>
    /// Live API login data
    /// </summary>
    public class Login
    {
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LoginStatus Status = LoginStatus.error;

        [JsonPropertyName("game_user_id")]
        public string UserID = "";

        [JsonPropertyName("token")]
        public string Token = "";

        [JsonPropertyName("status_no")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LoginStatusId StatusId = LoginStatusId.Failed;

        [JsonPropertyName("servers")]
        public object? Servers = null;
    }
}
