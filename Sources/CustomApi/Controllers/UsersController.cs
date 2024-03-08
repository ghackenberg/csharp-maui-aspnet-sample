using CustomApi.Managers;
using CustomLib.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace CustomApi.Controllers
{
    /// <summary>
    /// Provides HTTP bindings for user CRUD operations.
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<List<UserGet>?> List()
        {
            return await UsersManager.Instance.List();
        }

        [HttpPost]
        public async Task<UserGet?> Post(UserPost data)
        {
            return await UsersManager.Instance.Post(data);
        }

        [HttpGet("{id}")]
        public async Task<UserGet?> Get(string id)
        {
            return await UsersManager.Instance.Get(id);
        }

        [HttpPut("{id}")]
        public async Task<UserGet?> Put(string id, UserPut data)
        {
            return await UsersManager.Instance.Put(id, data);
        }

        [HttpDelete("{id}")]
        public async Task<UserGet?> Delete(string id)
        {
            return await UsersManager.Instance.Delete(id);
        }
    }
}
