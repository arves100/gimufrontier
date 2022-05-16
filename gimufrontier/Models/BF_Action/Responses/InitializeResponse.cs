using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models.BF_Action.Responses
{
    public record DailyBPInfo
    {
        [JsonPropertyName("k3bD738b")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint DailyAccumulatedBravePoints;
    }

    // XGmGpmYW -> challenge arena
    // k23D7d43 -> today daily task
    // a739yK18 -> daily task prize?
    // Pk5F1vhx -> banner info
    // M3dw18eB -> Summoner journal??
    // Bd29Pqw0 -> daily login banner
    // bD18x9Ti -> daily login rewards
    // mebW7mKD -> video ads slot
    // Drudr2w5 -> daily login rewards info??
    // IkdSufj5 -> guild info
    // Pj6zDW3m -> login notice
    // KeC10fuL -> mst version info
    // JYFGe9y6 -> unit exp pattern mst
    // z5U7utsm -> extra skill mst
    // YDv9bJ3s -> user level mst
    // 4NG79sX1 -> dungeon key mst
    // 5Y4GJeo3 -> summon mst
    // Pf97SzVw -> summon effect
    // 8f0bCciN -> crafting mst
    // VkoZ5t3K -> define mst????
    // 1NTG2oVZ -> thophy group mst????
    // 6CTU8m2v -> trophy mst????
    // Ked15IpH -> throphy grade mst???
    // 5nBa3CAe -> translation mst
    // Lh1I3dGo -> town facility mst???
    // d0EkJ4TB -> town facility lv mst???
    // 1y2JDv79 -> town location mst???
    // 9ekQ4tZq -> town location lv mst???
    // 9x4zZCeN -> help mst???
    // 5C9LuNrk -> help sub mst???
    // 6kWq78zx -> arena rank mst
    // 36Sd0Aub -> sound mst
    // hV5vWu6C -> npc mst???
    // At7Gny2V -> URL mst
    // mQC4s5ka -> challenge mst???
    // h09mEvDR -> challenge hr mst???
    // 5M8jI4cP -> challenge mis mst????
    // zW1i02aG -> challenge grade mst???
    // 4C1Wt8sS -> challenge reward mst???
    // dn0NfRy1 -> challenge item mst????
    // nUmaEC41 -> challenge mvp mst????
    // P8V71kbw -> challenge rank reward mst????
    // B8lchAPr -> interactive banner info mst???

    public record InitializeResponse
    {
        [JsonPropertyName("IKqx1Cn9")]
        public GeneralUserInfo[]? UserData;

#if false // does not seem to be parsed anymore
        [JsonPropertyName("4ZfpSQv1")]
        public UserSoundInfo[]? SoundInfo;
#endif

        [JsonPropertyName("p283g07d")]
        public DailyBPInfo[]? BPInfo;

        // TODO: MST
    }
}
