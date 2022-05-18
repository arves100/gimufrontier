using gimufrontier.Models;
using gimufrontier.Models.BF_Action.Requests;
using gimufrontier.Models.BF_Action.Responses;
using gimufrontier.Serializations;
using System.Reflection;
using System.Text.Json;

namespace gimufrontier
{
    /// <summary>
    /// Holds static configuration/data of the application that should be immutable
    /// </summary>
    public class StaticData
    {
        /// <summary>
        /// Cached default JSON options
        /// </summary>
        public static readonly JsonSerializerOptions DefaultOptions = new()
        {
            IncludeFields = true,
        };

        /// <summary>
        /// Logged in users
        /// </summary>
        public static readonly Dictionary<string, User> Users = new();

        public static long DateTimeToUnix(DateTime t)
        {
            return new DateTimeOffset(t).ToUnixTimeSeconds();
        }

        public static long DateTimeNowToUnix()
        {
            return DateTimeToUnix(DateTime.Now);
        }

        public static readonly LevelProgressionInfo[] Progressions = new LevelProgressionInfo[1000];
        public static ResponseMST[]? MSTResponse;

        public static void SetupData()
        {
#if true // TODO: Hardcoded
            Progressions[0] = new LevelProgressionInfo
            {
                Id = 0,
                RequiredExp = 0,
                Unknown = 15,
                SquadCost = 400,
                MaxAddableFriends = 0,
                MaxFriends = 10,
            };

            for (int i = 1; i < 1000; i++)
            {
                Progressions[i] = new LevelProgressionInfo
                {
                    Id = 1,
                    RequiredExp = Progressions[i-1].RequiredExp + 1000,
                    Unknown = 15,
                    SquadCost = Progressions[i-1].SquadCost + 5,
                    MaxFriends = 10,
                    MaxAddableFriends = 0,
                };
            }
#endif

            var fs = new FileStream("mstinfo.json", FileMode.Open);
            MSTVersionCfg? mst = (MSTVersionCfg?)JsonSerializer.Deserialize(fs, typeof(MSTVersionCfg), DefaultOptions);
            if (mst == null || mst?.MSTs == null)
                throw new NullReferenceException("Unable to load MST data");

            MSTResponse = new ResponseMST[mst.MSTs.Length];

            for (var i = 0; i < mst.MSTs.Length; i++)
            {
                var m = mst.MSTs[i];

                MSTResponse[i] = new ResponseMST
                {
                    Id = m.Name,
                    Version = m.Version,
                    SubVersion = m.SubVersion,
                    Unknown = m.Unknown,
                };
            }
            fs.Close();
        }
    }
}
