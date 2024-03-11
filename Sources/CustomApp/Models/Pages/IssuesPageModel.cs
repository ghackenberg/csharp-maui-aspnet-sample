using CustomLib.Clients;
using CustomLib.Models.Issues;

namespace CustomApp.Models.Pages
{
    class IssuesPageModel : AbstractItemsPageModel<IssueGet>
    {
        protected override Task<List<IssueGet>> ReloadInternal()
        {
            return IssuesClient.Instance.List();
        }
    }
}
