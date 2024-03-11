namespace CustomApp.Models.Pages
{
    [QueryProperty(nameof(UserId), "UserId")]
    [QueryProperty(nameof(FirstName), "FirstName")]
    [QueryProperty(nameof(LastName), "LastName")]
    class UserPageModel : AbstractItemPageModel
    {
        private string _userId = "";
        private string _firstName = "";
        private string _lastName = "";

        public string UserId
        {
            set => SetProperty(ref _userId, value);
            get => _userId;
        }

        public string FirstName
        {
            set => SetProperty(ref _firstName, value);
            get => _firstName;
        }

        public string LastName
        {
            set => SetProperty(ref _lastName, value);
            get => _lastName;
        }
    }
}
