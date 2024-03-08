using CustomLib.Clients;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomApp.Models.Pages
{
    class IssuesPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _load;

        private bool _done;

        private bool _success;

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

        public bool Done
        {
            get => _done;
            set
            {
                if (_done != value)
                {
                    _done = value;
                    OnPropertyChanged(nameof(Done));
                }
            }
        }

        public bool Success
        {
            get => _success;
            set
            {
                if (_success != value)
                {
                    _success = value;
                    OnPropertyChanged(nameof(Success));
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

        public IssuesPageModel()
        {
            Reload();
        }

        public void Reload()
        {
            Load = true;
            Done = false;

            Task.Run(async () =>
            {
                try
                {
                    var issues = await IssuesClient.Instance.List();

                    Count = issues.Count;

                    Success = true;
                    Error = false;
                }
                catch
                {
                    Success = false;
                    Error = true;
                }

                Load = false;
                Done = true;
            });
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
