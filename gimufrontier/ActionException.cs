using gimufrontier.Models.BF_Action;

namespace gimufrontier
{
    /// <summary>
    /// Exception that can be passed to action.php to send custom errors
    /// </summary>
    public class ActionException : Exception
    {
        public ErrorID Id { get; private set; }
        public ErrorOperation Operation { get; private set; }
        public string ErrMessage { get; private set; }

        public ActionException(ErrorID id, ErrorOperation op, string msg)
        {
            Id = id;
            Operation = op;
            ErrMessage = msg;
        }
    }
}
