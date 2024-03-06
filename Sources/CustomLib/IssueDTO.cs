namespace CustomLib
{
    class IssueDTO
    {
        public string IssueId { get; set; } = "";
        public string UserId { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Label { get; set; } = "";
    }
}
