namespace CustomApp.Pages;

public partial class UsersPage : ContentPage
{
	public UsersPage()
	{
		InitializeComponent();
	}

    private void OnClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("user");
    }
}