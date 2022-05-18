using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action
{
    public enum OSValue
    {
        Android = 2,
    }

    public enum LanguageValue
    {
        en = 0,
    }

    public record UserSoundInfo
    {
        [JsonPropertyName("h7eY3sAK")]
        public string UserId = "";

        [JsonPropertyName("Tgw5ua04")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint BgmVolume = 10;

        [JsonPropertyName("Dw5hick9")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint SfxVolume = 10;
    }

    public record SignalKeyInfo
    {
        [JsonPropertyName("Kn51uR4Y")]
        public string SignalKeyTag = "";
    }

}
