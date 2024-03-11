using CustomApp.Models.Pages;

namespace CustomApp.Pages;

public partial class UserPage : ContentPage
{
    private UserPageModel ViewModel => (UserPageModel)BindingContext;

    public UserPage()
	{
		InitializeComponent();
	}
}