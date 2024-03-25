using CustomApp.Models.Views;

namespace CustomApp.Controls.Views;

public partial class ShellFlyoutHeader : ContentView
{
    private ShellFlyoutHeaderModel ViewModel => (ShellFlyoutHeaderModel)BindingContext;

    public ShellFlyoutHeader()
	{
		InitializeComponent();
	}
}