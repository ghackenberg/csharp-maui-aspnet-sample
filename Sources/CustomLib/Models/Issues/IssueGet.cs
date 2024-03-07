namespace CustomLib.Models.Issues
{
    public class IssueGet : IssuePost
    {
        public string IssueId { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
