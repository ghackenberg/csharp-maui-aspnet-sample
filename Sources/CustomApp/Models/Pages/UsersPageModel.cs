using CustomLib.Clients;

namespace CustomApp.Models.Pages
{
    class UsersPageModel : AbstractModel
    {
        private bool _load;
        private bool _error;
        private int _count;

        public bool Load
        {
            set => SetProperty(ref _load, value);
            get => _load;
        }

        public bool Error
        {
            set => SetProperty(ref _error, value);
            get => _error;
        }

        public int Count
        {
            set => SetProperty(ref _count, value);
            get => _count;
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
    }
}
