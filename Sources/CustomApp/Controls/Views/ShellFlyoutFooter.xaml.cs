using CustomApp.Models.Views;

namespace CustomApp.Controls.Views;

public partial class ShellFlyoutFooter : ContentView
{
    private ShellFlyoutFooterModel ViewModel => (ShellFlyoutFooterModel)BindingContext;

    public ShellFlyoutFooter()
	{
		InitializeComponent();
	}
}