namespace CustomApp.Models
{
    abstract class AbstractItemsPageModel<T> : AbstractModel
    {
        private bool _isReloadEnabled;
        private bool _isCreateEnabled;

        private bool _isLoadVisible;
        private bool _isListVisible;
        private bool _isErrorVisible;

        private string? _errorMessage;

        private List<T>? _itemList;

        public AbstractItemsPageModel()
        {
            Reload();
        }

        public bool IsReloadEnabled
        {
            set => SetProperty(ref _isReloadEnabled, value);
            get => _isReloadEnabled;
        }

        public bool IsCreateEnabled
        {
            set => SetProperty(ref _isCreateEnabled, value);
            get => _isCreateEnabled;
        }

        public bool IsLoadVisible
        {
            set => SetProperty(ref _isLoadVisible, value);
            get => _isLoadVisible;
        }

        public bool IsListVisible
        {
            set => SetProperty(ref _isListVisible, value);
            get => _isListVisible;
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

        public List<T>? ItemList
        {
            set => SetProperty(ref _itemList, value);
            get => _itemList;
        }

        public void Reload()
        {
            IsReloadEnabled = false;
            IsCreateEnabled = false;

            IsLoadVisible = true;
            IsListVisible = false;
            IsErrorVisible = false;

            Task.Run(async () =>
            {
                try
                {
                    ItemList = await ReloadInternal();

                    IsListVisible = true;
                }
                catch (Exception exception)
                {
                    ErrorMessage = exception.Message;

                    IsErrorVisible = true;
                }

                IsReloadEnabled = true;
                IsCreateEnabled = true;

                IsLoadVisible = false;
            });
        }

        protected abstract Task<List<T>> ReloadInternal();
    }
}
