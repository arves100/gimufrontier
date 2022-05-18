using gimufrontier.Models.BF_Action.Requests;
using gimufrontier.Models.BF_Action.Responses;
using gimufrontier.Serializations;

namespace gimufrontier.Handlers
{
    [Handler("NiYWKdzs", "f6uOewOD")]
    public class HomeCallHandler
    {
        public HomeCallResponse Handle(UserInfoRequest rq)
        {
            return new HomeCallResponse
            {
                PaymentInfo = new UserPaymentInfo
                {
                    LastPurchaseDate = 0,
                },

                NoticeInfo = new NoticeInfoResponse
                {
                    Id = 1,
                    NoticeUrl = "ios.bfww.gumi.sg/test.html",
                },

                RaidRoundInfo = new GuildRaidRoundInfo
                {
                    ServerTime = StaticData.DateTimeNowToUnix(),
                },

                SignalKeyInfo = rq.SignalKeys,
            };
        }
    }
}
