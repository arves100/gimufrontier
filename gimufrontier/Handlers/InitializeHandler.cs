using gimufrontier.Serializations;
using gimufrontier.Models.BF_Action.Requests;
using gimufrontier.Models.BF_Action.Responses;
using gimufrontier.Models.BF_Action;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace gimufrontier.Handlers
{
    public delegate void InitializeAddUserDelegate(User user);

    [Handler("MfZyu1q9", "EmcshnQoDr20TZz1")]
    public class InitializeHandler
    {
        private readonly GimuDbContext _context;
        private readonly IRedisDatabase _redis;

        public InitializeHandler(GimuDbContext context, IRedisDatabase redis)
        {
            _context = context;
            _redis = redis;
        }

        private async Task<User?> GetUser(string apiUserId, string apiToken)
        {
            var db = _redis.Database;
            var v = await db.StringGetAsync($"api_{apiToken}");
            if (v == RedisValue.Null)
                return null; // invalid token
            
            if (((string)v) != apiUserId)
                return null; // trying to access another account with a different token

            var userData = await _context.Users.Where(x => x.ApiId == apiUserId).SingleOrDefaultAsync();

            if (userData == null)
                throw new ActionException(ErrorID.ForceClose, ErrorOperation.Close, "     Invalid user\nPlease clear you data first before logging again");

            if (userData.IsBanned)
                throw new ActionException(ErrorID.ForceClose, ErrorOperation.Close, "     Invalid user\nThis user has been banned from the server");

            return new User(userData, apiToken);
        }

        public async Task<InitializeResponse> Handle(InitializeRequest rq)
        {
            if (rq.MST == null || rq.UserInfos == null || rq.UserInfos.Length < 1)
                throw new Exception("Invalid initialize request");

            // carry over the server identification data into the server info
            var ui = rq.UserInfos[0];

            User? user = null;

            if (!StaticData.Users.ContainsKey(ui.GumiLiveToken))
            {
                user = await GetUser(ui.GumiLiveUserId, ui.GumiLiveToken);

                if (user == null)
                    throw new ActionException(ErrorID.ForceClose, ErrorOperation.Close, "     Session expired\nYour session has expired, restart the game");

                user.DeviceName = ui.DeviceName;
                user.OS = ui.OS;

                StaticData.Users.Add(ui.GumiLiveToken, user);
            }
            else
                user = StaticData.Users[ui.GumiLiveToken];

            return new InitializeResponse
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

                BPInfo = new DailyBPInfo[1] { new DailyBPInfo() },

                // --- BEGIN MST

                CampaignInfo = new LoginCampaignInfo[]
                {
                    new LoginCampaignInfo
                    {
                        Id = 100,
                        DuringDays = 999,
                        StartDate = 1652743558, // unix time
                        BannerPath = "/logincampaign/Summer2017_Day00Banner.png",
                    }
                },

                MSTVersion = StaticData.MSTResponse,

                NoticeInfo = new NoticeInfoResponse
                {
                    Id = 1,
                    NoticeUrl = "ios.bfww.gumi.sg/test.html",
                },

                DailyWheel = new DailyWheelInfo
                {
                    Id = 13,
                    CurrentDay = 3,
                    RemainingDaysToGuaranteedGem = 4,
                },

                ProgressInfo = StaticData.Progressions,

                Tasks = new DailyTaskMST[]
                {
                    new DailyTaskMST
                    {
                        Description = "Hi",
                        Title = "Hi",
                        BPReward = 10,
                        Key = "CM",
                        Count = 1,
                    },

                    new DailyTaskMST
                    {
                        Description = "Hi again",
                        Title = "Hi again",
                        BPReward = 10,
                        Count = 1,
                        Key = "VV"
                    },

                    new DailyTaskMST
                    {
                        Description = "Hi once more",
                        Title = "Hi once more",
                        BPReward = 10,
                        Count = 1,
                        Key = "AV"
                    },
                },


                VideoSlot = new VideoSlotConfig[]
                {
                    new VideoSlotConfig
                    {
                        Value1 = "{\"zS45RFGb\":\"999\",\"I1Cki7Pb\":\"video slots\",\"h1PSnk5t\":\"4,5,6\",\"yu18xScw\":\"1\",\"qA7M9EjP\":\"2014-05-26 06:00:00\",\"SzV0Nps7\":\"2018-12-31 23:59:59\",\"2HY3jpgu\":\"0\",\"v9TR3cDz\":\"0\",\"b5yeVr61\":\"1@0\",\"2iFQ9uhT\":\"999\",\"qp37xTDh\":\"1\",\"jsRoN50z\":\"\\/bf\\/web\\/slots\\/html\\/videoslot.php\",\"TX98PnpE\":\"slot_base.png,slot_btn_on.png,slot_label_start.png,slot_medal_insert.png,slot_medal.png,item_large.png,bravemedal_large.png,sphere_large.png\"}",
                        Value2 = "[{\"PINm2pM5\":\"4\",\"Z8eJi4pq\":\"14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,1,2,3,4,5,6,7,8,9,10,11,12,13\"},{\"PINm2pM5\":\"5\",\"Z8eJi4pq\":\"4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,1,2,3\"},{\"PINm2pM5\":\"6\",\"Z8eJi4pq\":\"26,27,28,29,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,32\"}]",
                        Value3 = "[{\"sE6tyI9i\":\"14\",\"iQM9dH0F\":\"item.png\"},{\"sE6tyI9i\":\"15\",\"iQM9dH0F\":\"item.png\"},{\"sE6tyI9i\":\"16\",\"iQM9dH0F\":\"item.png\"},{\"sE6tyI9i\":\"17\",\"iQM9dH0F\":\"item.png\"},{\"sE6tyI9i\":\"18\",\"iQM9dH0F\":\"sphere.png\"},{\"sE6tyI9i\":\"19\",\"iQM9dH0F\":\"sphere.png\"},{\"sE6tyI9i\":\"20\",\"iQM9dH0F\":\"e_tome.png\"},{\"sE6tyI9i\":\"21\",\"iQM9dH0F\":\"g_tome.png\"},{\"sE6tyI9i\":\"22\",\"iQM9dH0F\":\"fire_shard.png\"},{\"sE6tyI9i\":\"23\",\"iQM9dH0F\":\"elgif.png\"},{\"sE6tyI9i\":\"24\",\"iQM9dH0F\":\"elgif.png\"},{\"sE6tyI9i\":\"25\",\"iQM9dH0F\":\"elgif.png\"},{\"sE6tyI9i\":\"26\",\"iQM9dH0F\":\"item.png\"},{\"sE6tyI9i\":\"27\",\"iQM9dH0F\":\"s_ticket.png\"},{\"sE6tyI9i\":\"28\",\"iQM9dH0F\":\"s_ticketx2.png\"},{\"sE6tyI9i\":\"29\",\"iQM9dH0F\":\"s_ticketx5.png\"},{\"sE6tyI9i\":\"1\",\"iQM9dH0F\":\"s_flog.png\"},{\"sE6tyI9i\":\"2\",\"iQM9dH0F\":\"b_flog.png\"},{\"sE6tyI9i\":\"3\",\"iQM9dH0F\":\"b_emperor.png\"},{\"sE6tyI9i\":\"4\",\"iQM9dH0F\":\"b_queen.png\"},{\"sE6tyI9i\":\"5\",\"iQM9dH0F\":\"o_frog.png\"},{\"sE6tyI9i\":\"6\",\"iQM9dH0F\":\"pup_unit.png\"},{\"sE6tyI9i\":\"7\",\"iQM9dH0F\":\"allup_unit.png\"},{\"sE6tyI9i\":\"8\",\"iQM9dH0F\":\"c_god.png\"},{\"sE6tyI9i\":\"9\",\"iQM9dH0F\":\"g_god.png\"},{\"sE6tyI9i\":\"10\",\"iQM9dH0F\":\"f_totem.png\"},{\"sE6tyI9i\":\"11\",\"iQM9dH0F\":\"m_mecha.png\"},{\"sE6tyI9i\":\"12\",\"iQM9dH0F\":\"item.png\"},{\"sE6tyI9i\":\"13\",\"iQM9dH0F\":\"item.png\"},{\"sE6tyI9i\":\"32\",\"iQM9dH0F\":\"easter_ticket.png\"}]",
                        Value4 = "{\"wRIgGCHh\":\"0\",\"qqdr4HlW\":\"0\",\"E9gMeBW0\":\"42\",\"JwBrVzIZ\":\"10\",\"BrMgnCaT\":\"7\",\"er8Ups6U\":\"0\"}",
                    },
                },

                Guild = new GuildInfo(),

                CampaignData = new LoginCampaignData[]
                {
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 1,
                    },
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 2,
                    },
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 3,
                    },
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 4,
                    },
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 5,
                    },
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 6,
                    },
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 7,
                    },
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 8,
                    },
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 9,
                    },
                    new LoginCampaignData
                    {
                        MstId = 100,
                        RewardImage = "/logincampaign/Summer2017_Day01.png",
                        Day = 10,
                    },

                }

                // --- END MST
            };
        }
    }
}
