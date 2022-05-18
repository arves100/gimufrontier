using gimufrontier.Models.GumiApi;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace gimufrontier.Controllers
{
    /// <summary>
    /// Live API controller (api-sl.bfww.gumi.sg/dls)
    /// </summary>
    [ApiController]
    [Route("/dls")]
    public class DlsController : ControllerBase
    {
        private IConfigurationSection _cfg;

        /// <summary>
        /// ASP.NET Logger
        /// </summary>
        private readonly ILogger<DlsController> _logger;

        /// <summary>
        /// Controller costructor
        /// </summary>
        /// <param name="logger">ASP.NET Logger</param>
        /// <param name="cfg">JSON Configuration</param>
        public DlsController(ILogger<DlsController> logger, IConfiguration cfg)
        {
            _logger = logger;
            _cfg = cfg.GetRequiredSection("ServerConfig");
        }

        /// <summary>
        /// Handles game info request (dls)
        /// </summary>
        /// <returns>Serializated SREE object</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<SREE> Get()
        {
            var str = "";
            foreach (var q in Request.Query)
            {
                str += q.Key + "=" + q.Value + ", ";
            }
            _logger.LogDebug("Receive queries: {str}", str);

            var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, new DLS
            {
                Ip = _cfg.GetValue<string>("GameUrl"),
                GameVersion = _cfg.GetValue<uint>("GameVersion"),
                BackgroundImg = _cfg.GetValue<string>("BannerImage"),
                LoginApi = _cfg.GetValue<string>("ApiUrl"),
                CdnIp = _cfg.GetValue<string>("AssetUrl"),
            }, StaticData.DefaultOptions);

            var data = stream.ToArray();
            _logger.LogDebug("Response {data}", Encoding.UTF8.GetString(data));

            return new SREE
            {
                Data = Cryptation.SREE(data)
            };
        }
    }
}
