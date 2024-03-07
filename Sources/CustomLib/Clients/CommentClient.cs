using CustomLib.Interfaces;
using CustomLib.Models.Comments;

namespace CustomLib.Clients
{
    public class CommentClient : AbstractClient<CommentGet, CommentPost, CommentPut>, CommentsInterface
    {
        public static readonly CommentClient Instance = new CommentClient();

        private CommentClient() : base("comments")
        {

        }
    }
}
