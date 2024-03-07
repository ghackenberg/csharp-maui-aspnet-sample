using CustomLib.Exceptions;
using CustomLib.Interfaces;
using CustomLib.Models.Users;
using System.Net;

namespace CustomApi.Managers
{
    public class UsersManager : UsersInterface
    {
        public static readonly UsersManager Instance = new UsersManager();

        private UsersManager() { }

        private readonly List<UserGet> _list = new List<UserGet>();

        private readonly Dictionary<string, UserGet> _dict = new Dictionary<string, UserGet>();

        public async Task<List<UserGet>?> List()
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

        public async Task<UserGet?> Post(UserPost data)
        {
            return await Task.Run(() =>
            {
                var user = new UserGet();

                user.UserId = $"User-{_list.Count}";
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;

                _list.Add(user);
                _dict.Add(user.UserId, user);

                return user;
            });
        }

        public async Task<UserGet?> Get(string id)
        {
            return await Task.Run(() =>
            {
                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "User not found");
                }

                var user = _dict[id];

                if (user.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "User not found");
                }
                
                return user;
            });
        }

        public async Task<UserGet?> Put(string id, UserPut data)
        {
            return await Task.Run(() =>
            {
                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "User not found");
                }

                var user = _dict[id];

                if (user.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "User not found");
                }

                user.UpdatedAt = DateTime.Now;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;

                return user;
            });
        }

        public async Task<UserGet?> Delete(string id)
        {
            if (!_dict.ContainsKey(id))
            {
                throw new HttpException(HttpStatusCode.NotFound, "User not found");
            }

            var user = _dict[id];

            if (user.DeletedAt != null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "User not found");
            }

            user.UpdatedAt = DateTime.Now;
            user.DeletedAt = DateTime.Now;

            // Delete user issues
            await IssuesManager.Instance.DeleteByUserId(id);
            // Delete user comments
            await CommentsManager.Instance.DeleteByUserId(id);

            return user;
        }
    }
}
