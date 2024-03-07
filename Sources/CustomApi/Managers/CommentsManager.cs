using CustomLib.Exceptions;
using CustomLib.Interfaces;
using CustomLib.Models.Comments;
using System.Net;

namespace CustomApi.Managers
{
    public class CommentsManager : CommentsInterface
    {
        public static readonly CommentsManager Instance = new CommentsManager();

        private CommentsManager() { }

        private readonly List<CommentGet> _comments = new List<CommentGet>();

        public async Task<List<CommentGet>?> List()
        {
            return await Task.Run(() =>
            {
                var result = new List<CommentGet>();

                foreach (var comment in _comments)
                {
                    if (comment.DeletedAt == null)
                    {
                        result.Add(comment);
                    }
                }

                return result;
            });
        }

        public async Task<CommentGet?> Post(CommentPost data)
        {
            return await Task.Run(() =>
            {
                var comment = new CommentGet();

                comment.UserId = data.UserId;
                comment.IssueId = data.IssueId;
                comment.CommentId = $"Comment-{_comments.Count}";
                comment.CreatedAt = DateTime.Now;
                comment.UpdatedAt = DateTime.Now;
                comment.Text = data.Text;

                _comments.Add(comment);

                return comment;
            });
        }

        public async Task<CommentGet?> Get(string id)
        {
            return await Task.Run(() =>
            {
                foreach (var comment in _comments)
                {
                    if (comment.DeletedAt == null && comment.CommentId.Equals(id))
                    {
                        return comment;
                    }
                }
                throw new HttpException(HttpStatusCode.NotFound, "Not found");
            });
        }

        public async Task<CommentGet?> Put(string id, CommentPut data)
        {
            return await Task.Run(() =>
            {
                foreach (var comment in _comments)
                {
                    if (comment.DeletedAt == null && comment.CommentId.Equals(id))
                    {
                        comment.UpdatedAt = DateTime.Now;
                        comment.Text = data.Text;

                        return comment;
                    }
                }
                throw new HttpException(HttpStatusCode.NotFound, "Not found");
            });
        }

        public async Task<CommentGet?> Delete(string id)
        {
            return await Task.Run(() =>
            {
                foreach (var comment in _comments)
                {
                    if (comment.DeletedAt == null && comment.CommentId.Equals(id))
                    {
                        comment.UpdatedAt = DateTime.Now;
                        comment.DeletedAt = DateTime.Now;

                        return comment;
                    }
                }
                throw new HttpException(HttpStatusCode.NotFound, "Not found");
            });
        }
    }
}
