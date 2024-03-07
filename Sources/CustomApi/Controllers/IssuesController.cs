using CustomLib.Interfaces;
using CustomLib.Models.Issues;
using Microsoft.AspNetCore.Mvc;

namespace CustomApi.Controllers
{
    [Route("api/issues")]
    [ApiController]
    public class IssuesController : ControllerBase, IssuesInterface
    {
        [HttpGet]
        public async Task<List<IssueGet>?> List()
        {
            return new List<IssueGet>();
        }
        [HttpPost]
        public async Task<IssueGet?> Post(IssuePost data)
        {
            return new IssueGet();
        }
        [HttpGet("{id}")]
        public async Task<IssueGet?> Get(string id)
        {
            return new IssueGet();
        }
        [HttpPut("{id}")]
        public async Task<IssueGet?> Put(string id, IssuePut data)
        {
            return new IssueGet();
        }
        [HttpDelete("{id}")]
        public async Task<IssueGet?> Delete(string id)
        {
            return new IssueGet();
        }
    }
}
