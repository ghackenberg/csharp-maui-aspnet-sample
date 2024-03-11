using CustomApp.Models.Pages;

namespace CustomApp.Pages;

public partial class IssuePage : ContentPage
{
	private IssuePageModel ViewModel => (IssuePageModel)BindingContext;

	public IssuePage()
	{
		InitializeComponent();
	}
}