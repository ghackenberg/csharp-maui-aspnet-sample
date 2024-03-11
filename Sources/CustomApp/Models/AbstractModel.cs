using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomApp.Models
{
    public abstract class AbstractModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string name = "")
        {
            if (Object.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(name);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
