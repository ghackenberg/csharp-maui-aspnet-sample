namespace CustomLib.Models.Comments
{
    public class CommentGet : CommentPost
    {
        public string CommentId { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
