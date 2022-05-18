using gimufrontier.Serializations;
using gimufrontier.Models.BF_Action.Requests;
using gimufrontier.Models.BF_Action.Responses;

namespace gimufrontier.Handlers
{
    [Handler("cTZ3W2JG", "ScJx6ywWEb0A3njT")]
    public class UserInfoHandler
    {
        private IConfigurationSection _cfg;

        public UserInfoHandler(IConfiguration cfg)
        {
            _cfg = cfg.GetRequiredSection("GameConfig");
        }

        public UserInfoResponse Handle(UserInfoRequest rq)
        {
            if (rq.UserInfos == null)
                throw new Exception("Invalid UserInfo request serialization");

            if (!StaticData.Users.ContainsKey(rq.UserInfos[0].GumiLiveToken))
                throw new ActionException(Models.BF_Action.ErrorID.No, Models.BF_Action.ErrorOperation.Close, "     Invalid user\nUser session is expired/not logged in");

            var user = StaticData.Users[rq.UserInfos[0].GumiLiveToken];

            var unitz = new UnitInfoResponse[2]
            {
                 new UnitInfoResponse
                {
                    UserId = user.GameUserId,
                    Unknown = 1001,
                    InternalUnitId = 820748,
                    UnitType = 1,
                    Level = 150,
                    BaseHP = 1000,
                    BaseAtk = 100,
                    BaseDef = 100,
                    BaseHeal = 100,
                 },
                 new UnitInfoResponse
                 {
                     Unknown = 2001,
                     UserId = user.GameUserId,
                     InternalUnitId = 60165,
                     UnitType = 1,
                     Level = 150,
                     BaseHP = 999999999,
                     BaseAtk = 999999999,
                     BaseDef =  999999999,
                     BaseHeal = 999999999,
                 }
            };

            return new UserInfoResponse
            {
                UserData = new Models.BF_Action.Responses.GeneralUserInfo[1] { user.GenerateUserInfo() },

#if false
                SoundInfo = new UserSoundInfo[1]
                {
                    new UserSoundInfo
                    {
                        UserId = user.GameUserId,
                        BgmVolume = 10,
                        SfxVolume = 10,
                    }
                },
#endif

                Progress = new UserProgress[1]
                {
                    new UserProgress
                    {
                        UserId = user.GameUserId,
                        Level = user.Data.Level,
                        Exp = user.Data.Exp,
                        FreeGemsCount = user.Data.FreeGems,
                        PaidGemsCount = user.Data.PaidGems,
                        HonorPoints = user.Data.HonorPt,
                        FriendMessage = user.Data.FriendMsg,
                        Karma = user.Data.Karma,
                        Zel = user.Data.Zel,
                        ColosseumTickets = user.Data.ColosseumTickets,
                        CurrentBravePoints = user.Data.BravePoints,
                        TotalBravePoints = user.Data.TotalBravePoints,
                        IncreasedMaxUnitCount = user.Data.UnitInc,
                        IncreasedMaxFriendCount = user.Data.FriendInc,
                        SummonTickets = user.Data.SummonTickets,
                        MysteryBoxCount = user.Data.MysteryBox,
                        MaxUnitCount = _cfg.GetValue<uint>("DefaultMaxUnits"),
                        MaxFriendCount = _cfg.GetValue<uint>("DefaultMaxFriends"),
                    }
                },

                // -- BEGIN MST

                NoticeInfo = new NoticeInfoResponse
                {
                    Id = 1,
                    NoticeUrl = "ios.bfww.gumi.sg/test.html",
                },

                UserLoginCampaign = new UserLoginCampaignInfo[]
                {
                    new UserLoginCampaignInfo
                    {
                        CampaignId = 100,
                        TotalDaysLoggedIn = 1,
                        TotalCampaignDays = 999,
                    }
                },

                UnitInfos = unitz,

                // -- EBD NST
            };
        }
    }
}
