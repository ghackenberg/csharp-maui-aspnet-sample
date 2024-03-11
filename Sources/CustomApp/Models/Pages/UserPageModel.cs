using CustomLib.Models.Users;

namespace CustomApp.Models.Pages
{
    [QueryProperty(nameof(User), "User")]
    class UserPageModel : AbstractModel
    {
        private UserGet? _user;

        public UserGet? User
        {
            set => SetProperty(ref _user, value);
            get => _user;
        }
    }
}
