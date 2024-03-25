namespace CustomApp.Models.Pages
{
    class CalculatorPageModel : AbstractModel
    {
        public static readonly CalculatorPageModel Instance = new CalculatorPageModel();

        private CalculatorPageModel() { }

        private string? _number1;
        private string? _number2;

        private string? _operation = "+"; // + - * /

        public string? Operation
        {
            set => SetProperty(ref _operation, value);
            get => _operation;
        }

        // TODO!!
    }
}
