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
        private readonly InitializeAddUserDelegate _dlg;

        public InitializeHandler(GimuDbContext context, IRedisDatabase redis, InitializeAddUserDelegate dlg)
        {
            _context = context;
            _redis = redis;
            _dlg = dlg;
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

        public async Task<InitializeResponse> Handle(User? user, InitializeRequest rq)
        {
            if (rq.UserInfos == null || rq.UserInfos.Length < 1)
                throw new Exception("Invalid initialize request");

            // carry over the server identification data into the server info
            var ui = rq.UserInfos[0];

            if (user == null)
            {
                user = await GetUser(ui.GumiLiveUserId, ui.GumiLiveToken);

                if (user == null)
                    throw new ActionException(ErrorID.ForceClose, ErrorOperation.Close, "     Session expired\nYour session has expired, restart the game");

                user.DeviceName = ui.DeviceName;
                user.OS = ui.OS;

                _dlg(user);
            }

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

                BPInfo = new DailyBPInfo[1] { new DailyBPInfo() }
            };
        }
    }
}
