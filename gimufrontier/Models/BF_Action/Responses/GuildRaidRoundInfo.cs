using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record GuildRaidRoundInfo
    {
        [JsonPropertyName("dk39bDa1")]
        public string SeasonId = "";

        [JsonPropertyName("81tacsfJ")]
        public string RoundId = "";

        [JsonPropertyName("s385qzx9")]
        public string Unknown = "";

        [JsonPropertyName("z1I0P1Qk")]
        public long ServerTime;

        [JsonPropertyName("qS4wLauD")]
        public uint PreparationDuration = 100000;

        [JsonPropertyName("l4txLZJ1")]
        public uint BattlePreparationDuration = 100000;

        [JsonPropertyName("WhVJkLa1")]
        public uint BattleForceEndDuration = 100000;

        [JsonPropertyName("6lldENEG")]
        public uint ConsolidationDuration;

#if false // not parsed anymore
        [JsonPropertyName("7k5fMj3L")]
        public string Unknown = "";
#endif

        [JsonPropertyName("djaB081u")]
        // TODO: Enum?
        public string Phase = "SEASION_END";

        [JsonPropertyName("ka8D1i0b")]
        // TODO: shouldn't this be a uint/DateTime?
        public string CurrentPhaseEndTime = "";

        [JsonPropertyName("d3B6aKl3")]
        // TODO: shouldn't this be a uint/DateTime?
        public string OutputstRelocateRemainingTime = "";
    }
}
