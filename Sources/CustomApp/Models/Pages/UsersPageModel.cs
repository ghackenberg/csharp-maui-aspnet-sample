using CustomLib.Models.Users;
using CustomSdk.Clients;

namespace CustomApp.Models.Pages
{
    public class UsersPageModel : AbstractItemsPageModel<UserGet>
    {
        public static readonly UsersPageModel Instance = new UsersPageModel();

        private UsersPageModel() { }

        protected override Task<List<UserGet>> ReloadInternal()
        {
            return UsersClient.Instance.List();
        }
    }
}
