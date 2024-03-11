using CustomApp.Models.Pages;

namespace CustomApp.Pages;

public partial class IssuePage : ContentPage
{
	public IssuePage()
	{
		InitializeComponent();

		BindingContext = IssuePageModel.Instance;
	}
}