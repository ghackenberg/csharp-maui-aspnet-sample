using CustomApp.Pages;

namespace CustomApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("users/user", typeof(UserPage));
            Routing.RegisterRoute("issues/issue", typeof(IssuePage));
        }
    }
}
