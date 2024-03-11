using CustomLib.Models.Issues;

namespace CustomApp.Models.Pages
{
    [QueryProperty(nameof(Issue), "Issue")]
    class IssuePageModel : AbstractModel
    {
        private IssueGet? _issue;

        public IssueGet? Issue
        {
            set => SetProperty(ref _issue, value);
            get => _issue;
        }
    }
}
