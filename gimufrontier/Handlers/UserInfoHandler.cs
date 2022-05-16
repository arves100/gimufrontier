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

        public UserInfoResponse Handle(User user, UserInfoRequest rq)
        {
            if (rq.UserInfos == null)
                throw new Exception("Invalid UserInfo request serialization");

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
            };
        }
    }
}
