namespace CustomApp.Models.Pages
{
    [QueryProperty(nameof(Item), "Item")]
    abstract class AbstractItemPageModel<T> : AbstractModel
    {
        private T? _item;

        public T? Item
        {
            set => SetProperty(ref _item, value);
            get => _item;
        }
    }
}
