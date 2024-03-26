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
        public async Task<List<CommentRead>> Find([FromQuery] CommentQuery query)
        {
            return await CommentsManager.Instance.Find(query);
        }

        [HttpPost]
        public async Task<CommentRead> Create(CommentCreate data)
        {
            return await CommentsManager.Instance.Create(data);
        }

        [HttpGet("{id}")]
        public async Task<CommentRead> Read(string id)
        {
            return await CommentsManager.Instance.Read(id);
        }

        [HttpPut("{id}")]
        public async Task<CommentRead> Update(string id, CommentUpdate data)
        {
            return await CommentsManager.Instance.Update(id, data);
        }

        [HttpDelete("{id}")]
        public async Task<CommentRead> Delete(string id)
        {
            return await CommentsManager.Instance.Delete(id);
        }
    }
}
