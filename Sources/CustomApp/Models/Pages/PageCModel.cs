using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomApp.Models.Pages
{
    class PageCModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
