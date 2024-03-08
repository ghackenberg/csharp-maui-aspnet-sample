using CustomLib.Interfaces;
using CustomLib.Models.Users;

namespace CustomLib.Clients
{
    /// <summary>
    /// A singleton for calling user CRUD operations via HTTP.
    /// </summary>
    public class UserClient : AbstractClient<UserGet, UserPost, UserPut>, UsersInterface
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        public static readonly UserClient Instance = new UserClient();

        /// <summary>
        /// The private constructor preventing other singleton instances.
        /// </summary>
        public UserClient() : base("users") { }
    }
}
