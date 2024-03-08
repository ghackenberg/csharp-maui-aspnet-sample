using CustomLib.Interfaces;
using CustomLib.Models.Users;

namespace CustomLib.Clients
{
    /// <summary>
    /// A singleton for calling user CRUD operations via HTTP.
    /// </summary>
    public class UsersClient : AbstractClient<UserGet, UserPost, UserPut>, UsersInterface
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        public static readonly UsersClient Instance = new UsersClient();

        /// <summary>
        /// The private constructor preventing other singleton instances.
        /// </summary>
        public UsersClient() : base("users") { }
    }
}
