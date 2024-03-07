using CustomLib.Interfaces;
using CustomLib.Models.Users;

namespace CustomLib.Clients
{
    public class UserClient : AbstractClient<UserGet, UserPost, UserPut>, UsersInterface
    {
        public static readonly UserClient Instance = new UserClient();

        public UserClient() : base("users")
        {

        }
    }
}
