namespace CustomLib.Models.Issues
{
    public class IssueGet : IssuePost
    {
        public string IssueId { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}
