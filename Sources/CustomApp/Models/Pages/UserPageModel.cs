using CustomLib.Models.Users;

namespace CustomApp.Models.Pages
{
    public class UserPageModel : AbstractItemPageModel<UserRead>
    {
        public static readonly UserPageModel Instance = new UserPageModel();

        private UserPageModel() { }
    }
}
