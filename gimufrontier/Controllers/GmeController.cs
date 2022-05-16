using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using gimufrontier.Models.BF_Action;
using gimufrontier.Models;
using System.Reflection;
using gimufrontier.Serializations;
using gimufrontier.Handlers;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace gimufrontier.Controllers
{
    /// <summary>
    /// Controller for the main game operations (ios21900.bfww.gumi.sg/bf/gme/)
    /// </summary>
    [ApiController]
    [Route("/bf/gme")]
    public class GmeController : ControllerBase
    {
        /// <summary>
        /// Logged in users
        /// </summary>
        private Dictionary<string, User> _users = new();

        /// <summary>
        /// ASP.NET Logger
        /// </summary>
        private readonly ILogger<GmeController> _logger;

        /// <summary>
        /// Server features
        /// </summary>
        private readonly Features _features = new();

        /// <summary>
        /// action.php handlers
        /// </summary>
        private readonly Dictionary<string, (string, object, MethodInfo)> _handlers = new();

        /// <summary>
        /// New user delegate that will be called be InitializeHandler
        /// (callback is very low I know... I haven't found a better way yet)
        /// </summary>
        private readonly InitializeAddUserDelegate _newUserDlg;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="logger">ASP.NET logger</param>
        /// <param name="ctx">Database context</param>
        /// <param name="redis">Redis context</param>
        /// <param name="cfg">JSON Configuration</param>
        public GmeController(ILogger<GmeController> logger, GimuDbContext ctx, IRedisDatabase redis, IConfiguration cfg)
        {
            logger.LogDebug("Entrypoint: ios21900.bfww.gumi.sg/bf/gme/");
            _logger = logger;
            _newUserDlg = AddNewUser;

            // TODO: This is terribly slow because it is called every time at object creation
            //  I should change it into something else
            InitializeHandlers("gimufrontier.Handlers", new object[] { ctx, redis, cfg, _newUserDlg });

            // TODO: Setup _features
        }

        private void AddNewUser(User u)
        {
            _users.Add(u.GameUserId, u);
        }


        /// <summary>
        /// Loads all handlers by creating an instance of each handle which DI parameters and keeping it cached for getting invoked multiple times
        /// </summary>
        /// <param name="ns">Namespace of the handlers to load</param>
        private void InitializeHandlers(string ns, object[] instances)
        {
            var mlist = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.Namespace == ns && x.IsClass && x.GetCustomAttribute(typeof(HandlerAttribute)) != null && x.GetMethod("Handle") != null)
                .Select(x => (x, (HandlerAttribute?)x.GetCustomAttribute(typeof(HandlerAttribute)), x.GetMethod("Handle"), x.GetConstructors()))
                .ToList();

            foreach (var o in mlist)
            {
                if (o.Item2 == null || o.Item3 == null)
                    continue;

                var ctor = o.Item4.Where(x => x.IsPublic).SingleOrDefault();
                if (ctor == null)
                    continue;

                _logger.LogDebug("Attempting to register handler for {Id}", o.Item2.Id);

                object?[]? i2 = null;
                var param = ctor.GetParameters();

                if (param.Any())
                {
                    i2 = param.Select(x => instances.Where(y => y.GetType().IsAssignableTo(x.ParameterType)).SingleOrDefault())
                              .Where(x => x != null)
                              .ToArray();

                    if (i2.Length != param.Length)
                        continue;
                }

                var handlerObj = Activator.CreateInstance(o.x, i2);
                if (handlerObj == null)
                    continue;

                _logger.LogInformation("Action handler {Id} registred!", o.Item2.Id);
                _handlers.Add(o.Item2.Id, (o.Item2.Key, handlerObj, o.Item3));
            }
        }

        /// <summary>
        /// Handles the main game action
        /// </summary>
        /// <returns>action.php exchangedata result</returns>
#if DEBUG // Debug entrypoint used to test serialization/deserialization behavours (or some custom clients??)
        [HttpGet("action.debug.php")]
#endif
        [HttpPost("action.php")]
        [Produces("application/json")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<ExchangeData> Action()
        {
            try
            {
                var clientRequest = (ExchangeData?)await JsonSerializer.DeserializeAsync(Request.Body, typeof(ExchangeData), new JsonSerializerOptions { IncludeFields = true });
                if (clientRequest == null)
                    throw new Exception("Client request deserialization returned null");

                if (clientRequest.Header == null || clientRequest.Header.Request == null || clientRequest.Body == null || clientRequest.Body.Data == null)
                    throw new Exception("Invalid client request data");

                if (!_handlers.ContainsKey(clientRequest.Header.Request))
                {
                    _logger.LogWarning("Unimplemented request ${Request} }, player id ${Id}, body ${Data}", clientRequest.Header.Request, clientRequest.Header.Id, clientRequest.Body.Data);
                    return ExchangeData.GenError(ErrorID.Yes, ErrorOperation.Continue, $"Request {clientRequest.Header.Request} not implemented!");
                }

                // Get the handler
                var handler = _handlers[clientRequest.Header.Request];
                var handlerParams = handler.Item3.GetParameters();

                if (handlerParams == null || handlerParams?.Length != 2)
                    throw new Exception("Invalid handler");

                // Decrypt JSON
                var key = Encoding.UTF8.GetBytes(handler.Item1);
                var clientJson = Cryptation.Game2Server(clientRequest.Body.Data, key);

                // Deserialize the request into C# class
                var ms = new MemoryStream(clientJson);
                var request = await JsonSerializer.DeserializeAsync(ms, handlerParams[1].ParameterType, new JsonSerializerOptions { IncludeFields = true });

                User? user = null;

                if (_users.ContainsKey(clientRequest.Header.Id))
                    user = _users[clientRequest.Header.Id];

                var isAwaitable = handler.Item3.ReturnType.GetMethod(nameof(Task.GetAwaiter)) != null;

                object? response;

                // Run the handler
                if (isAwaitable)
                    response = (object?)await (dynamic?)handler.Item3.Invoke(handler.Item2, new object?[2] { user, request });
                else
                    response = handler.Item3.Invoke(handler.Item2, new object?[2] { user, request });

                if (response == null)
                    throw new Exception("Unable to generate server response");

                // Serialize the response into JSON
                ms = new MemoryStream();
                await JsonSerializer.SerializeAsync(ms, response, handler.Item3.ReturnType, new JsonSerializerOptions { IncludeFields = true });

                var responseData = ms.ToArray();

#if DEBUG
                _logger.LogInformation("Response for {Request} -> {responseData}", clientRequest.Header.Request, Encoding.UTF8.GetString(responseData));
#endif

                // Send data back to the game

                return new ExchangeData
                {
                    Body = new ActionBody
                    {
                        Data = Cryptation.Server2Game(responseData, key),
                    },
                };
            }
            catch (ActionException ex)
            {
                return ExchangeData.GenError(ex.Id, ex.Operation, ex.ErrMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError("action.php handling error! exception:\n{ex}", ex);
                return ExchangeData.GenError(ErrorID.Yes, ErrorOperation.Close, "     Server Error\nInternal server error");
            }
        }

        /// <summary>
        /// Handlers server time request
        /// </summary>
        /// <returns>Current server time</returns>
        [HttpGet("action/getServerTime.php")]
        //[Produces("text/plain")] // TODO
        public long ServerTime()
        {
            return new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        }

        /// <summary>
        /// Handlers feature check
        /// </summary>
        /// <returns>features info</returns>
        [HttpGet("featureCheck.php")]
        [Produces("application/json")]
        public Features Features()
        {
            // cached to avoid memory usage
            return _features;
        }
    }
}
