using CustomLib.Models.Issues;
using CustomSdk.Clients;

namespace CustomApp.Models.Pages
{
    public class IssuesPageModel : AbstractItemsPageModel<IssueRead>
    {
        public static readonly IssuesPageModel Instance = new IssuesPageModel();

        private IssuesPageModel() { }

        protected override Task<List<IssueRead>> ReloadInternal()
        {
            return IssuesClient.Instance.Find(new IssueQuery());
        }
    }
}
