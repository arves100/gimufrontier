using Microsoft.AspNetCore.Mvc;
using gimufrontier.Models.Login;
using StackExchange.Redis;
using System.Text.Json;
using System.Text;
using gimufrontier.Models.GumiApi;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace gimufrontier.Controllers
{
    /// <summary>
    /// Live API login controller (api-sl.gl.bfww.gumi.sg/accounts/)
    /// </summary>
    [ApiController]
    [Route("/accounts")]
    public class AccountsController : ControllerBase
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly GimuDbContext _context;

        /// <summary>
        /// Redis context
        /// </summary>
        private readonly IRedisDatabase _redis;

        /// <summary>
        /// ASP.NET Logger
        /// </summary>
        private readonly ILogger<AccountsController> _logger;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="logger">ASP.NET Logger</param>
        /// <param name="context">Database context</param>
        /// <param name="redis">Redis context</param>
        public AccountsController(ILogger<AccountsController> logger, GimuDbContext context, IRedisDatabase redis)
        {
            _logger = logger;
            _context = context;
            _redis = redis;
        }

        /// <summary>
        /// Login with Facebook token
        /// </summary>
        /// <returns>Login object</returns>
        [HttpGet("facebook/login")]
        [Produces("application/json")]
        public async Task<Login> FacebookLogin()
        {
            // ak = game api keys for gumi login backend, pretty much ignored

            var q = Request.Query;

            try
            {
                var str = "";
                foreach (var qq in q)
                {
                    str += qq.Key + "=" + qq.Value + ", ";
                }
                _logger.LogDebug("queries: {str}", str);

                var fbId = q["facebook_access_info"];

                var idi = q["identifiers"][0];

                // Decode "identifiers"
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(idi));

                var obj = (Identifiers?)await JsonSerializer.DeserializeAsync(ms, typeof(Identifiers), StaticData.DefaultOptions);

                if (obj == null)
                    throw new Exception("Json deserialization error");

                // Check if the user facebook login exists
                var fb = await _context.FacebookUsers.Where(x => x.Token == fbId[0] && x.AndroidId == obj.AndroidId).SingleOrDefaultAsync();

                if (fb == null)
                    throw new Exception("User not found");

                // Generate a new GUMI Api token
                var loginToken = Rng.NewToken(100);

                // Update redis with the new token
                await _redis.Database.StringSetAsync($"api_{loginToken}", fb.UserId, flags: CommandFlags.FireAndForget);

                return new Login
                {
                    Status = LoginStatus.successful,
                    UserID = fb.UserId,
                    Token = loginToken,
                    StatusId = LoginStatusId.Success,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to login facebook api. Exception: {ex}", ex);

                return new Login
                {
                    Status = LoginStatus.error,
                    UserID = "",
                    Token = "",
                    StatusId = LoginStatusId.Failed,
                };
            }
        }

        /// <summary>
        /// Guest login without Facebook
        /// </summary>
        /// <returns>Login object</returns>
        [HttpGet("guest/login")]
        [Produces("application/json")]
        public Login GuestLogin()
        {
            var str = "";
            foreach (var q in Request.Query)
            {
                str += q.Key + "=" + q.Value + ", ";
            }
            _logger.LogDebug("queries: {str}", str);

            // TODO

            return new Login
            {
                Status = LoginStatus.error,
                UserID = "",
                Token = "",
                StatusId = LoginStatusId.Failed,
            };
        }
    }
}
