using CustomApi.Managers;
using CustomLib.Interfaces;
using CustomLib.Models.Comments;
using Microsoft.AspNetCore.Mvc;

namespace CustomApi.Controllers
{
    /// <summary>
    /// Provides HTTP bindings for comment CRUD operations.
    /// </summary>
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase, CommentsInterface
    {
        [HttpGet]
        public async Task<List<CommentGet>> List([FromQuery] CommentQuery query)
        {
            return await CommentsManager.Instance.List(query);
        }

        [HttpPost]
        public async Task<CommentGet> Post(CommentPost data)
        {
            return await CommentsManager.Instance.Post(data);
        }

        [HttpGet("{id}")]
        public async Task<CommentGet> Get(string id)
        {
            return await CommentsManager.Instance.Get(id);
        }

        [HttpPut("{id}")]
        public async Task<CommentGet> Put(string id, CommentPut data)
        {
            return await CommentsManager.Instance.Put(id, data);
        }

        [HttpDelete("{id}")]
        public async Task<CommentGet> Delete(string id)
        {
            return await CommentsManager.Instance.Delete(id);
        }
    }
}
