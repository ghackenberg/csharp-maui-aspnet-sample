using CustomLib.Clients;
using Microsoft.Maui.Layouts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomApp.Models.Pages
{
    class UsersPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _load;

        private bool _error;

        private int _count;

        public bool Load
        {
            get => _load;
            set
            {
                if (_load != value)
                {
                    _load = value;
                    OnPropertyChanged(nameof(Load));
                }
            }
        }

        public bool Error
        {
            get => _error;
            set
            {
                if (_error != value)
                {
                    _error = value;
                    OnPropertyChanged(nameof(Error));
                }
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Count));
                }
            }
        }

        public UsersPageModel()
        {
            Reload();
        }

        public void Reload()
        {
            Load = true;

            Error = false;

            Task.Run(async () =>
            {
                try
                {
                    var users = await UsersClient.Instance.List();

                    Count = users.Count;
                }
                catch
                {
                    Error = true;
                }
                Load = false;
            });
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
