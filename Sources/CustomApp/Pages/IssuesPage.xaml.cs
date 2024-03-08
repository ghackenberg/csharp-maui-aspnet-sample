namespace CustomApp.Pages;

public partial class IssuesPage : ContentPage
{
	public IssuesPage()
	{
		InitializeComponent();
    }

    private void OnClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("issue");
    }
}