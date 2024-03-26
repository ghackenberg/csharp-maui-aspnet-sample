namespace CustomLib.Models.Comments
{
    public class CommentQuery
    {
        public string IssueId { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"IssueId={IssueId}";
        }
    }
}
