using CustomApp.Models.Pages;
using CustomLib.Models.Issues;

namespace CustomApp.Pages;

public partial class IssuesPage : ContentPage
{
    private IssuesPageModel ViewModel => (IssuesPageModel)BindingContext;

    public IssuesPage()
	{
		InitializeComponent();
    }

    private void OnReloadClicked(object sender, EventArgs e)
    {
        ViewModel.Reload();
    }

    private void OnIssueClicked(object sender, SelectedItemChangedEventArgs e)
    {
        var issue = (IssueGet)e.SelectedItem;
        var parameter = new Dictionary<string, object>()
        {
            { "IssueId", issue.IssueId },
            { "UserId", issue.UserId },
            { "Label", issue.Label },
        };
        Shell.Current.GoToAsync("issue", parameter);
    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("issue");
    }
}