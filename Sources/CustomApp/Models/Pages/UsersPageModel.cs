using CustomLib.Clients;
using CustomLib.Models.Users;

namespace CustomApp.Models.Pages
{
    class UsersPageModel : AbstractItemsPageModel<UserGet>
    {
        protected override Task<List<UserGet>> ReloadInternal()
        {
            return UsersClient.Instance.List();
        }
    }
}
