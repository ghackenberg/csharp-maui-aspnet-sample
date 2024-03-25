using CustomApp.Models.Pages;
using CustomLib.Models.Issues;

namespace CustomApp.Controls.Pages;

public partial class IssuesPage : ContentPage
{
    public IssuesPage()
	{
		InitializeComponent();

        BindingContext = IssuesPageModel.Instance;
    }

    private void OnReloadClicked(object sender, EventArgs e)
    {
        // Reload items
        IssuesPageModel.Instance.Reload();
    }

    private void OnIssueClicked(object sender, SelectedItemChangedEventArgs e)
    {
        // Read item
        var issue = (IssueGet)e.SelectedItem;

        // Build item
        var item = new IssueGet
        {
            UserId = issue.UserId,
            IssueId = issue.IssueId,
            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
            DeletedAt = issue.DeletedAt,
            Label = issue.Label
        };

        // Build dictionary
        var parameter = new Dictionary<string, object>()
        {
            { "Item", item }
        };

        // Change route
        Shell.Current.GoToAsync("issue", parameter);
    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        // Build item
        var item = new IssueGet();

        // Build parameters
        var parameter = new Dictionary<string, object>()
        {
            { "Item", item }
        };

        // Change route
        Shell.Current.GoToAsync("issue", parameter);
    }
}