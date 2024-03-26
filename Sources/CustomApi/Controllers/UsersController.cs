using CustomApi.Managers;
using CustomLib.Interfaces;
using CustomLib.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace CustomApi.Controllers
{
    /// <summary>
    /// Provides HTTP bindings for user CRUD operations.
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase, UsersInterface
    {
        [HttpGet]
        public async Task<List<UserRead>> Find([FromQuery] UserQuery query)
        {
            return await UsersManager.Instance.Find(query);
        }

        [HttpPost]
        public async Task<UserRead> Create(UserCreate data)
        {
            return await UsersManager.Instance.Create(data);
        }

        [HttpGet("{id}")]
        public async Task<UserRead> Read(string id)
        {
            return await UsersManager.Instance.Read(id);
        }

        [HttpPut("{id}")]
        public async Task<UserRead> Update(string id, UserUpdate data)
        {
            return await UsersManager.Instance.Update(id, data);
        }

        [HttpDelete("{id}")]
        public async Task<UserRead> Delete(string id)
        {
            return await UsersManager.Instance.Delete(id);
        }
    }
}
