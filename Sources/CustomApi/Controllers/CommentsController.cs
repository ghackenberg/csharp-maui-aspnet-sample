using CustomLib.Interfaces;
using CustomLib.Models.Comments;
using Microsoft.AspNetCore.Mvc;

namespace CustomApi.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase, CommentsInterface
    {
        [HttpGet]
        public async Task<List<CommentGet>?> List()
        {
            return new List<CommentGet>();
        }
        [HttpPost]
        public async Task<CommentGet?> Post(CommentPost data)
        {
            return new CommentGet();
        }
        [HttpGet("{id}")]
        public async Task<CommentGet?> Get(string id)
        {
            return new CommentGet();
        }
        [HttpPut("{id}")]
        public async Task<CommentGet?> Put(string id, CommentPut data)
        {
            return new CommentGet();
        }
        [HttpDelete("{id}")]
        public async Task<CommentGet?> Delete(string id)
        {
            return new CommentGet();
        }
    }
}
