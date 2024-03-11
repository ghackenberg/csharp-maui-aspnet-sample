using CustomLib.Clients;
using CustomLib.Models.Issues;

namespace CustomApp.Models.Pages
{
    class IssuesPageModel : AbstractModel
    {
        private bool _isReloadEnabled;
        private bool _isLoadVisible;
        private bool _isListVisible;
        private bool _isErrorVisible;

        private string? _errorMessage;

        private List<IssueGet>? _issueList;

        public bool IsReloadEnabled
        {
            set { SetProperty(ref _isReloadEnabled, value); }
            get { return _isReloadEnabled; }
        }

        public bool IsLoadVisible
        {
            set { SetProperty(ref _isLoadVisible, value); }  
            get { return _isLoadVisible; }
        }

        public bool IsListVisible
        {
            set { SetProperty(ref _isListVisible, value); }
            get { return _isListVisible; }
        }

        public bool IsErrorVisible
        {
            set { SetProperty(ref _isErrorVisible, value); }
            get { return _isErrorVisible; }
        }

        public string? ErrorMessage
        {
            set { SetProperty(ref _errorMessage, value); }
            get { return _errorMessage; }
        }

        public List<IssueGet>? IssueList
        {
            set { SetProperty(ref _issueList, value); }
            get { return _issueList; }
        }

        public IssuesPageModel()
        {
            Reload();
        }

        public void Reload()
        {
            IsReloadEnabled = false;
            IsLoadVisible = true;
            IsListVisible = false;
            IsErrorVisible = false;

            Task.Run(async () =>
            {
                try
                {
                    var issues = await IssuesClient.Instance.List();

                    IssueList = issues;

                    IsListVisible = true;
                }
                catch (Exception exception)
                {
                    ErrorMessage = exception.Message;

                    IsErrorVisible = true;
                }

                IsReloadEnabled = true;
                IsLoadVisible = false;
            });
        }
    }
}
