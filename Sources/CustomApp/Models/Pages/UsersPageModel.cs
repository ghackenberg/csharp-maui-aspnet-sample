using CustomLib.Models.Users;
using CustomSdk.Clients;

namespace CustomApp.Models.Pages
{
    public class UsersPageModel : AbstractItemsPageModel<UserRead>
    {
        public static readonly UsersPageModel Instance = new UsersPageModel();

        private UsersPageModel() { }

        protected override Task<List<UserRead>> ReloadInternal()
        {
            return UsersClient.Instance.Find(new UserQuery());
        }
    }
}
