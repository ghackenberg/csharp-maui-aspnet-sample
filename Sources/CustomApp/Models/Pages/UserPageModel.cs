using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomApp.Models.Pages
{
    [QueryProperty(nameof(UserId), "UserId")]
    class UserPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _userId = "";

        public string UserId
        {
            get => _userId;
            set
            {
                if (!_userId.Equals(value))
                {
                    _userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
