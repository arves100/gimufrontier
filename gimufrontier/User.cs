using gimufrontier.Models.BF_Action;
using gimufrontier.Models.BF_Action.Responses;
using gimufrontier.Models.Database;

namespace gimufrontier
{
    public class User
    {
        public string GameUserId { get; protected set; }
        public string DeviceName { get; set; }
        public string GumiToken { get; protected set; }

        public OSValue OS { get; set; }

        public UserDb Data = new();

        public User(UserDb db, string token)
        {
            Data = db;
            GameUserId = Rng.NoSpecial(20);
            DeviceName = "";
            GumiToken = token;
        }

        public GeneralUserInfo GenerateUserInfo()
        {
            return new GeneralUserInfo
            {
                DeviceName = DeviceName,
                TutorialChapter = Data.Tutorial,
                FinishedTutorial = Data.FinishedTutorial,
                DebugMode = Data.IsAdmin,
                UserId = GameUserId,
                Username = Data.Username,
                FriendId = Data.FriendId,
                OS = OS,
                GumiLiveToken = GumiToken,
                GumiLiveUserId = Data.ApiId,
            };
        }
    }
}
