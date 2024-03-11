using CustomLib.Models.Issues;

namespace CustomApp.Models.Pages
{
    public class IssuePageModel : AbstractItemPageModel<IssueGet>
    {
        public static readonly IssuePageModel Instance = new IssuePageModel();

        private IssuePageModel() { }
    }
}
