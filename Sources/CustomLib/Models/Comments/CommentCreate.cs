namespace CustomLib.Models.Comments
{
    public class CommentCreate : CommentUpdate
    {
        public string IssueId { get; set; } = "";
        public string UserId { get; set; } = "";
    }
}
