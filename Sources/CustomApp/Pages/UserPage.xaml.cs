using CustomApp.Models.Pages;
using CustomLib.Clients;
using CustomLib.Models.Users;

namespace CustomApp.Pages;

public partial class UserPage : ContentPage
{
    private UserPageModel ViewModel => (UserPageModel)BindingContext;

    public UserPage()
	{
		InitializeComponent();
	}

    private void OnSaveClicked(object sender, EventArgs e)
    {
        Task.Run(async () =>
        {
            ViewModel.IsSaveEnabled = false;

            ViewModel.IsLoadVisible = true;
            ViewModel.IsErrorVisible = false;

            try
            {
                if (ViewModel.UserId.Equals(""))
                {
                    var data = new UserPost
                    {
                        FirstName = ViewModel.FirstName,
                        LastName = ViewModel.LastName
                    };

                    await UsersClient.Instance.Post(data);
                }
                else
                {
                    var data = new UserPut
                    {
                        FirstName = ViewModel.FirstName,
                        LastName = ViewModel.LastName
                    };

                    await UsersClient.Instance.Put(ViewModel.UserId, data);
                }
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception exception)
            {
                ViewModel.ErrorMessage = exception.Message;

                ViewModel.IsErrorVisible = true;
            }

            ViewModel.IsSaveEnabled = true;

            ViewModel.IsLoadVisible = false;
        });
    }
}