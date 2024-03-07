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

        private readonly List<UserGet> _users = new List<UserGet>();

        public async Task<List<UserGet>?> List()
        {
            return await Task.Run(() =>
            {
                var result = new List<UserGet>();

                foreach (var user in _users)
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
                user.UserId = $"User-{_users.Count}";
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;

                _users.Add(user);

                return user;
            });
        }

        public async Task<UserGet?> Get(string id)
        {
            return await Task.Run(() =>
            {
                foreach (var user in _users)
                {
                    if (user.DeletedAt == null && user.UserId.Equals(id))
                    {
                        return user;
                    }
                }
                throw new HttpException(HttpStatusCode.NotFound, "Not found");
            });
        }

        public async Task<UserGet?> Put(string id, UserPut data)
        {
            return await Task.Run(() =>
            {
                foreach (var user in _users)
                {
                    if (user.DeletedAt == null && user.UserId.Equals(id))
                    {
                        user.UpdatedAt = DateTime.Now;
                        user.FirstName = data.FirstName;
                        user.LastName = data.LastName;

                        return user;
                    }
                }
                throw new HttpException(HttpStatusCode.NotFound, "Not found");
            });
        }

        public async Task<UserGet?> Delete(string id)
        {
            return await Task.Run(() =>
            {
                foreach (var user in _users)
                {
                    if (user.DeletedAt == null && user.UserId.Equals(id))
                    {
                        user.UpdatedAt = DateTime.Now;
                        user.DeletedAt = DateTime.Now;

                        return user;
                    }
                }
                throw new HttpException(HttpStatusCode.NotFound, "Not found");
            });
        }
    }
}
