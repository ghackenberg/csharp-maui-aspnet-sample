using CustomApp.Models.Pages;

namespace CustomApp.Controls.Pages;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();

		BindingContext = CalculatorPageModel.Instance;
	}
}