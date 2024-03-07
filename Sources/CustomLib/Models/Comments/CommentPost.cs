namespace CustomLib.Models.Comments
{
    public class CommentPost : CommentPut
    {
        public string IssueId { get; set; } = "";
        public string UserId { get; set; } = "";
    }
}
