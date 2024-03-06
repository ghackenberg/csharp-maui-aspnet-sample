namespace CustomLib
{
    class CommentDTO
    {
        public string CommentId { get; set; } = "";
        public string IssueId { get; set; } = "";
        public string UserId { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Text { get; set; } = "";
    }
}
