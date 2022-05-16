using gimufrontier.Serializations;
using System.Text.Json.Serialization;

namespace gimufrontier.Models
{
    /// <summary>
    /// Features supported by the game
    /// </summary>
    public record Features
    {
        [JsonPropertyName("randall")]
        public uint EnableRandallCapital = 0;

        [JsonPropertyName("frontierhunter")]
        public uint EnableFrontierHunter = 0;

        [JsonPropertyName("banner_mst")]
        public uint Unknown = 0;

        [JsonPropertyName("facebook_stories")]
        public uint EnableFacebookShareStories = 0;

        [JsonPropertyName("autobattle")]
        public uint EnableAutoBattle = 1;

        [JsonPropertyName("battle_item_limit")]
        public uint Unknown2 = 0;

        [JsonPropertyName("multiaccept")]
        public uint Unknown3 = 0;

        [JsonPropertyName("shop_friend")]
        public uint Unknown4 = 0;

        [JsonPropertyName("slot")]
        public uint EnableSlots = 0;

        [JsonPropertyName("sort")]
        public uint Unknown15 = 0;

        [JsonPropertyName("dungeon_key_cnt")]
        public uint Unknown5 = 0;

        [JsonPropertyName("ischeat_enable")]
        public uint Unknown6 = 0;

        [JsonPropertyName("supersonic_google")]
        public uint Unknown7 = 0;

        [JsonPropertyName("google_felloplay")]
        public uint Unknown8 = 0;

        [JsonPropertyName("corrupted_mst_check")]
        public uint Unknown9 = 0;

        [JsonPropertyName("tutorial_skip")]
        public uint EnableSkipTutorialButton = 1;

        [JsonPropertyName("bf_campaign_grand_quest")]
        public uint EnableGrandQuest = 0;

        [JsonPropertyName("bf_achievement")]
        public uint EnableAchievements = 0;

        [JsonPropertyName("bf_achievement_ext")]
        public uint Unknown10 = 0;

        [JsonPropertyName("arx_popup_enable")]
        public uint Unknown11 = 0;

        [JsonPropertyName("arx_popup_ios_enable")]
        public uint Unknown12 = 0;

        [JsonPropertyName("felloplay_community_ios")]
        public uint Unknown13 = 0;

        [JsonPropertyName("feature_gate")]
        public uint Unknown14 = 0;

        [JsonPropertyName("challenge_arena")]
        public uint EnableChallengeArena = 0;

        [JsonPropertyName("battle_speedup")]
        public uint EnableBattleSpeed = 1;

        [JsonPropertyName("battle_speed_ca")]
        public uint EnableBattleSpeedInCA = 1;

        [JsonPropertyName("autobattle_record")]
        public uint Unknown16 = 0;

        [JsonPropertyName("sendbag_enable")]
        public uint Unknown17 = 0;

        [JsonPropertyName("colosseum_enable")]
        public uint EnableColosseum = 0;

        [JsonPropertyName("video_ads")]
        public uint EnableVideoAds = 0;

        [JsonPropertyName("challenge_arena_banner_lock")]
        public uint Unknown18 = 0;

        [JsonPropertyName("guild_visible")]
        public uint Unknown19 = 0;

        [JsonPropertyName("guild")]
        public uint EnableGuilds = 0;

        [JsonPropertyName("name_change_func")]
        public uint Unknown20 = 0;

        [JsonPropertyName("video_ads_slots")]
        public uint EnableVideoAdsInSlot = 0;

        [JsonPropertyName("new_164_trial")]
        public uint Unknown21 = 0;

        [JsonPropertyName("amazon_coins_reward_control")]
        public uint Unknown22 = 0;

        [JsonPropertyName("daily_dungeon_list")]
        [JsonConverter(typeof(JsonStringUIntConverter))]
        public uint DailyDungeons = 0;

        [JsonPropertyName("cooldown_timer")]
        public uint Unknown23 = 0;

        [JsonPropertyName("va_sp_skill")]
        public uint Unknown24 = 0;

        [JsonPropertyName("frontiergate_plus")]
        public uint Unknown25 = 0;

        [JsonPropertyName("freepaid_gems")]
        public uint Unknown26 = 0;

        [JsonPropertyName("battle_speed_arena_pvp")]
        public uint EnableBattleSpeedInArena = 0;

        [JsonPropertyName("gatcha_category")]
        public uint Unknown27 = 0;

        [JsonPropertyName("unit_type_bonus_skill")]
        public uint Unknown28 = 0;
    }
}
