namespace CustomApp.Models.Pages
{
    [QueryProperty(nameof(Item), "Item")]
    public abstract class AbstractItemPageModel<T> : AbstractModel
    {
        private bool _isSaveEnabled = true;

        private bool _isLoadVisible = false;
        private bool _isErrorVisible = false;

        private string? _errorMessage;

        private T? _item;

        public bool IsSaveEnabled
        {
            set => SetProperty(ref _isSaveEnabled, value);
            get => _isSaveEnabled;
        }

        public bool IsLoadVisible
        {
            set => SetProperty(ref _isLoadVisible, value);
            get => _isLoadVisible;
        }

        public bool IsErrorVisible
        {
            set => SetProperty(ref _isErrorVisible, value);
            get => _isErrorVisible;
        }

        public string? ErrorMessage
        {
            set => SetProperty(ref _errorMessage, value);
            get => _errorMessage;
        }

        public T? Item
        {
            set => SetProperty(ref _item, value);
            get => _item;
        }
    }
}
