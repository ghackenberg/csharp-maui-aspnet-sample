using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomApp.Models.Pages
{
    [QueryProperty(nameof(ParamA), "ParamA")]
    [QueryProperty(nameof(ParamB), "ParamB")]
    [QueryProperty(nameof(ParamC), "ParamC")]
    class PageDModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _paramA;
        private double _paramB;
        private bool _paramC;

        public string ParamA
        {
            get => _paramA;
            set
            {
                if (!_paramA.Equals(value))
                {
                    _paramA = value;
                    OnPropertyChanged();
                }
            }
        }
        public double ParamB
        {
            get => _paramB;
            set
            {
                if (_paramB != value)
                {
                    _paramB = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ParamC
        {
            get => _paramC;
            set
            {
                if (_paramC != value)
                {
                    _paramC = value;
                    OnPropertyChanged();
                }
            }
        }

        public PageDModel()
        {
            _paramA = "";
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
