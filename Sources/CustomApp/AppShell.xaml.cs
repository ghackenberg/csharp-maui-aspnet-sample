using CustomApp.Pages;

namespace CustomApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("b/d", typeof(PageD));
        }
    }
}
