using CustomLib.Models.Issues;

namespace CustomApp.Models.Pages
{
    public class IssuePageModel : AbstractItemPageModel<IssueRead>
    {
        public static readonly IssuePageModel Instance = new IssuePageModel();

        private IssuePageModel() { }
    }
}
