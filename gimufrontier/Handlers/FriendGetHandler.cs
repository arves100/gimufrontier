using gimufrontier.Models.BF_Action.Requests;
using gimufrontier.Models.BF_Action.Responses;
using gimufrontier.Serializations;

namespace gimufrontier.Handlers
{
    //[Handler("2o4axPIC", "EoYuZ2nbImhCU1c0")]
    public class FriendGetHandler
    {
        public FriendGetResponse Handle(UserInfoRequest rq)
        {
            return new FriendGetResponse
            {
                Friends = new object[0] { },
            };
        }
    }
}
