using CustomApp.Models.Pages;

namespace CustomApp.Pages;

public partial class UsersPage : ContentPage
{
    private UsersPageModel ViewModel => (UsersPageModel)BindingContext;
    public UsersPage()
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
        Shell.Current.GoToAsync("user", parameter);
    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("user");
    }
}