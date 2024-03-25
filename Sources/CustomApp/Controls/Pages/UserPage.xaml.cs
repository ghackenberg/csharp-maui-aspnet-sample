using CustomApp.Models.Pages;
using CustomLib.Models.Users;
using CustomSdk.Clients;

namespace CustomApp.Controls.Pages;

public partial class UserPage : ContentPage
{
    public UserPage()
	{
    	InitializeComponent();

        BindingContext = UserPageModel.Instance;
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        Task.Run(async () =>
        {
            UserPageModel.Instance.IsSaveEnabled = false;

            UserPageModel.Instance.IsLoadVisible = true;
            UserPageModel.Instance.IsErrorVisible = false;

            try
            {
                if (UserPageModel.Instance.Item == null)
                {
                    throw new Exception("Unexpected application state");
                }

                if (UserPageModel.Instance.Item.UserId.Equals(""))
                {
                    var data = new UserPost
                    {
                        FirstName = UserPageModel.Instance.Item.FirstName,
                        LastName = UserPageModel.Instance.Item.LastName
                    };

                    await UsersClient.Instance.Post(data);
                }
                else
                {
                    var data = new UserPut
                    {
                        FirstName = UserPageModel.Instance.Item.FirstName,
                        LastName = UserPageModel.Instance.Item.LastName
                    };

                    await UsersClient.Instance.Put(UserPageModel.Instance.Item.UserId, data);
                }

                UsersPageModel.Instance.Reload();

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception exception)
            {
                UserPageModel.Instance.ErrorMessage = exception.Message;

                UserPageModel.Instance.IsErrorVisible = true;
            }

            UserPageModel.Instance.IsSaveEnabled = true;

            UserPageModel.Instance.IsLoadVisible = false;
        });
    }
}