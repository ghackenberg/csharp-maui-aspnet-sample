using CustomApi.Managers;
using CustomLib.Interfaces;
using CustomLib.Models.Issues;
using Microsoft.AspNetCore.Mvc;

namespace CustomApi.Controllers
{
    /// <summary>
    /// Provides HTTP bindings for issue CRUD operations.
    /// </summary>
    [Route("api/issues")]
    [ApiController]
    public class IssuesController : ControllerBase, IssuesInterface
    {
        [HttpGet]
        public async Task<List<IssueGet>?> List()
        {
            return await IssuesManager.Instance.List();
        }

        [HttpPost]
        public async Task<IssueGet?> Post(IssuePost data)
        {
            return await IssuesManager.Instance.Post(data);
        }

        [HttpGet("{id}")]
        public async Task<IssueGet?> Get(string id)
        {
            return await IssuesManager.Instance.Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IssueGet?> Put(string id, IssuePut data)
        {
            return await IssuesManager.Instance.Put(id, data);
        }

        [HttpDelete("{id}")]
        public async Task<IssueGet?> Delete(string id)
        {
            return await IssuesManager.Instance.Delete(id);
        }
    }
}
