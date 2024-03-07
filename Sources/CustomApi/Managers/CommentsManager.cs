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

        private readonly List<CommentGet> _list = new List<CommentGet>();

        private readonly Dictionary<string, CommentGet> _dict = new Dictionary<string, CommentGet>();

        public async Task<List<CommentGet>?> List()
        {
            return await Task.Run(() =>
            {
                var result = new List<CommentGet>();

                foreach (var comment in _list)
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
            return await Task.Run(async () =>
            {
                // Check if user exists
                await UsersManager.Instance.Get(data.UserId);
                // Check if issue exists
                await IssuesManager.Instance.Get(data.IssueId);

                var comment = new CommentGet();

                comment.UserId = data.UserId;
                comment.IssueId = data.IssueId;
                comment.CommentId = $"Comment-{_list.Count}";
                comment.CreatedAt = DateTime.Now;
                comment.UpdatedAt = DateTime.Now;
                comment.Text = data.Text;

                _list.Add(comment);
                _dict.Add(comment.CommentId, comment);

                return comment;
            });
        }

        public async Task<CommentGet?> Get(string id)
        {
            return await Task.Run(() =>
            {
                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                var comment = _dict[id];

                if (comment.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                return comment;
            });
        }

        public async Task<CommentGet?> Put(string id, CommentPut data)
        {
            return await Task.Run(() =>
            {
                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                var comment = _dict[id];

                if (comment.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                comment.UpdatedAt = DateTime.Now;
                comment.Text = data.Text;

                return comment;
            });
        }

        public async Task<CommentGet?> Delete(string id)
        {
            return await Task.Run(() =>
            {
                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                var comment = _dict[id];

                if (comment.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                comment.UpdatedAt = DateTime.Now;
                comment.DeletedAt = DateTime.Now;

                return comment;
            });
        }

        public async Task DeleteByUserId(string id)
        {
            foreach (var comment in _list)
            {
                if (comment.DeletedAt == null && comment.UserId.Equals(id))
                {
                    await Delete(comment.CommentId);
                }
            }
        }

        public async Task DeleteByIssueId(string id)
        {
            foreach (var comment in _list)
            {
                if (comment.DeletedAt == null && comment.IssueId.Equals(id))
                {
                    await Delete(comment.CommentId);
                }
            }
        }
    }
}
