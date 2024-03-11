using CustomApp.Models.Pages;
using CustomLib.Models.Users;

namespace CustomApp.Pages;

public partial class UsersPage : ContentPage
{
    public UsersPage()
	{
		InitializeComponent();

        BindingContext = UsersPageModel.Instance;
    }

    private void OnReloadClicked(object sender, EventArgs e)
    {
        // Reload items
        UsersPageModel.Instance.Reload();
    }

    private void OnIssueClicked(object sender, SelectedItemChangedEventArgs e)
    {
        // Get item
        var user = (UserGet)e.SelectedItem;

        // Build item
        var item = new UserGet
        {
            UserId = user.UserId,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            DeletedAt = user.DeletedAt,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        // Build parameters
        var parameter = new Dictionary<string, object>()
        {
            { "Item", item }
        };

        // Change route
        Shell.Current.GoToAsync("user", parameter);
    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        // Build parameters
        var parameter = new Dictionary<string, object>()
        {
            { "Item", new UserGet() }
        };

        // Change route
        Shell.Current.GoToAsync("user", parameter);
    }
}