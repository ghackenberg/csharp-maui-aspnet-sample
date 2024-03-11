using CustomApp.Models.Pages;
using CustomApp.Models.Views;

namespace CustomApp.Views;

public partial class ShellFlyoutFooter : ContentView
{
    private ShellFlyoutFooterModel ViewModel => (ShellFlyoutFooterModel)BindingContext;

    public ShellFlyoutFooter()
	{
		InitializeComponent();
	}
}