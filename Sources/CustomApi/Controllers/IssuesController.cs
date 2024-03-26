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
        public async Task<List<IssueRead>> Find([FromQuery] IssueQuery query)
        {
            return await IssuesManager.Instance.Find(query);
        }

        [HttpPost]
        public async Task<IssueRead> Create(IssueCreate data)
        {
            return await IssuesManager.Instance.Create(data);
        }

        [HttpGet("{id}")]
        public async Task<IssueRead> Read(string id)
        {
            return await IssuesManager.Instance.Read(id);
        }

        [HttpPut("{id}")]
        public async Task<IssueRead> Update(string id, IssueUpdate data)
        {
            return await IssuesManager.Instance.Update(id, data);
        }

        [HttpDelete("{id}")]
        public async Task<IssueRead> Delete(string id)
        {
            return await IssuesManager.Instance.Delete(id);
        }
    }
}
