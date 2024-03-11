using CustomLib.Models.Users;

namespace CustomApp.Models.Pages
{
    public class UserPageModel : AbstractItemPageModel<UserGet>
    {
        public static readonly UserPageModel Instance = new UserPageModel();

        private UserPageModel() { }
    }
}
