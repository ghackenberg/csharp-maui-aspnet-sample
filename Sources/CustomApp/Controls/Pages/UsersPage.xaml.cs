using CustomApp.Models.Pages;

namespace CustomApp.Controls.Pages;

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
        var user = (UserRead)e.SelectedItem;

        // Build item
        var item = new UserRead
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
            { "Item", new UserRead() }
        };

        // Change route
        Shell.Current.GoToAsync("user", parameter);
    }
}