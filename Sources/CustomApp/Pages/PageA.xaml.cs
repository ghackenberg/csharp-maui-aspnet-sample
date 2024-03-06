namespace CustomApp.Pages;

public partial class PageA : ContentPage
{
	public PageA()
	{
		InitializeComponent();
	}

    private void OnClicked(object sender, EventArgs e)
    {
		var query = new ShellNavigationQueryParameters
		{
			{ "ParamA", entry.Text },
			{ "ParamB", slider.Value },
			{ "ParamC", checkBox.IsChecked }
		};
		Shell.Current.GoToAsync("//a/d", query);
    }
}