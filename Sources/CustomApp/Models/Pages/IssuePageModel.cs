namespace CustomApp.Models.Pages
{
    [QueryProperty(nameof(UserId), "UserId")]
    [QueryProperty(nameof(IssueId), "IssueId")]
    [QueryProperty(nameof(Label), "Label")]
    class IssuePageModel : AbstractItemPageModel
    {
        private string _userId = "";
        private string _issueId = "";
        private string _label = "";

        public string UserId
        {
            set => SetProperty(ref _userId, value);
            get => _userId;
        }

        public string IssueId
        {
            set => SetProperty(ref _issueId, value);
            get => _issueId;
        }

        public string Label
        {
            set => SetProperty(ref _label, value);
            get => _label;
        }
    }
}
