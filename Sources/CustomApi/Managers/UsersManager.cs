using CustomLib.Exceptions.Http;
using CustomLib.Interfaces;
using CustomLib.Models.Users;

namespace CustomApi.Managers
{
    /// <summary>
    /// Singleton for managing the users in main memory.
    /// </summary>
    public class UsersManager : UsersInterface
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        public static readonly UsersManager Instance = new UsersManager();

        /// <summary>
        /// Private constructor to prevent other instances.
        /// </summary>
        private UsersManager() { }

        /// <summary>
        /// All users.
        /// </summary>
        private readonly List<UserGet> _list = new List<UserGet>();
        /// <summary>
        /// All users accessible via their ID.
        /// </summary>
        private readonly Dictionary<string, UserGet> _dict = new Dictionary<string, UserGet>();

        /// <summary>
        /// List all users, which have been created and not deleted.
        /// </summary>
        /// <returns>The user objects.</returns>
        public async Task<List<UserGet>> List()
        {
            return await Task.Run(() =>
            {
                var result = new List<UserGet>();

                foreach (var user in _list)
                {
                    if (user.DeletedAt == null)
                    {
                        result.Add(user);
                    }
                }

                return result;
            });
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="data">The new user data.</param>
        /// <returns>The new user object.</returns>
        public async Task<UserGet> Post(UserPost data)
        {
            return await Task.Run(() =>
            {
                // Create user

                var user = new UserGet();

                user.UserId = Guid.NewGuid().ToString();
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;

                // Remember user

                _list.Add(user);
                _dict.Add(user.UserId, user);

                // Return user

                return user;
            });
        }

        /// <summary>
        /// Get an existing user.
        /// </summary>
        /// <param name="id">The existing user ID.</param>
        /// <returns>The existing user object.</returns>
        /// <exception cref="HttpNotFoundException">User ID not found.</exception>
        public async Task<UserGet> Get(string id)
        {
            return await Task.Run(() =>
            {
                // Check user

                if (!_dict.ContainsKey(id))
                {
                    throw new HttpNotFoundException();
                }

                var user = _dict[id];

                if (user.DeletedAt != null)
                {
                    throw new HttpNotFoundException();
                }

                // Return user
                
                return user;
            });
        }

        /// <summary>
        /// Update an existing user.
        /// </summary>
        /// <param name="id">The existing user ID.</param>
        /// <param name="data">The updated user data.</param>
        /// <returns>The updated user object.</returns>
        /// <exception cref="HttpNotFoundException">User ID not found.</exception>
        public async Task<UserGet> Put(string id, UserPut data)
        {
            return await Task.Run(() =>
            {
                // Check user

                if (!_dict.ContainsKey(id))
                {
                    throw new HttpNotFoundException();
                }

                var user = _dict[id];

                if (user.DeletedAt != null)
                {
                    throw new HttpNotFoundException();
                }

                // Update user

                user.UpdatedAt = DateTime.Now;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;

                // Return user

                return user;
            });
        }

        /// <summary>
        /// Delete an existing user as well as his/her issues and comments.
        /// </summary>
        /// <param name="id">The existing user ID.</param>
        /// <returns>The deleted user object.</returns>
        /// <exception cref="HttpNotFoundException">User ID not found.</exception>
        public async Task<UserGet> Delete(string id)
        {
            // Check user

            if (!_dict.ContainsKey(id))
            {
                throw new HttpNotFoundException();
            }

            var user = _dict[id];

            if (user.DeletedAt != null)
            {
                throw new HttpNotFoundException();
            }

            // Delete user

            user.UpdatedAt = DateTime.Now;
            user.DeletedAt = DateTime.Now;

            // Delete user issues and comments

            await IssuesManager.Instance.DeleteByUserId(id);
            await CommentsManager.Instance.DeleteByUserId(id);

            // Return user

            return user;
        }
    }
}
