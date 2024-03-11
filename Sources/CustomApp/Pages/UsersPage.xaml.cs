using CustomApp.Models.Pages;
using CustomLib.Models.Users;

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
        var user = (UserGet)e.SelectedItem;
        var parameter = new Dictionary<string, object>()
        {
            { "UserId", user.UserId },
            { "FirstName", user.FirstName },
            { "LastName", user.LastName }
        };
        Shell.Current.GoToAsync("user", parameter);
    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("user");
    }
}