using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomApp.Models.Pages
{
    class IssuePageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _issueId = "";

        public string IssueId
        {
            get => _issueId;
            set
            {
                if (!_issueId.Equals(value))
                {
                    _issueId = value;
                    OnPropertyChanged(nameof(IssueId));
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
