using CustomApp.Models.Pages;

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
        var parameter = new Dictionary<string, object>()
        {
            { "Item", e.SelectedItem }
        };
        Shell.Current.GoToAsync("issue", parameter);
    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("issue");
    }
}