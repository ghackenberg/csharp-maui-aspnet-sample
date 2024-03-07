using CustomLib.Interfaces;
using CustomLib.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace CustomApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase, UsersInterface
    {
        [HttpGet]
        public async Task<List<UserGet>?> List()
        {
            return new List<UserGet>();
        }
        [HttpPost]
        public async Task<UserGet?> Post(UserPost data)
        {
            return new UserGet();
        }
        [HttpGet("{id}")]
        public async Task<UserGet?> Get(string id)
        {
            return new UserGet();
        }
        [HttpPut("{id}")]
        public async Task<UserGet?> Put(string id, UserPut data)
        {
            return new UserGet();
        }
        [HttpDelete("{id}")]
        public async Task<UserGet?> Delete(string id)
        {
            return new UserGet();
        }
    }
}
