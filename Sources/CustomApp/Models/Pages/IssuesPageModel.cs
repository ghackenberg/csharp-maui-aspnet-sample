using CustomLib.Models.Issues;
using CustomSdk.Clients;

namespace CustomApp.Models.Pages
{
    public class IssuesPageModel : AbstractItemsPageModel<IssueGet>
    {
        public static readonly IssuesPageModel Instance = new IssuesPageModel();

        private IssuesPageModel() { }

        protected override Task<List<IssueGet>> ReloadInternal()
        {
            return IssuesClient.Instance.List();
        }
    }
}
