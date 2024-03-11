using CustomApp.Models.Pages;

namespace CustomApp.Pages;

public partial class UsersPage : ContentPage
{
    private UsersPageModel ViewModel => (UsersPageModel)BindingContext;
    public UsersPage()
	{
		InitializeComponent();
	}

    private void OnClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("user");
    }
}