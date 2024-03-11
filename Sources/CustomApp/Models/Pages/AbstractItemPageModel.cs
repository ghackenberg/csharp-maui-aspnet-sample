namespace CustomApp.Models.Pages
{
    abstract class AbstractItemPageModel : AbstractModel
    {
        private bool _isSaveEnabled = true;

        private bool _isLoadVisible = false;
        private bool _isErrorVisible = false;

        private string? _errorMessage;

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
    }
}
