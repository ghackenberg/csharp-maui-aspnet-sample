namespace CustomLib.Models.Comments
{
    public class CommentRead : CommentCreate
    {
        public string CommentId { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}
