using CustomLib.Exceptions;
using CustomLib.Interfaces;
using CustomLib.Models.Comments;
using System.Net;

namespace CustomApi.Managers
{
    /// <summary>
    /// Singleton for managing the comments in main memory.
    /// </summary>
    public class CommentsManager : CommentsInterface
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        public static readonly CommentsManager Instance = new CommentsManager();

        /// <summary>
        /// Private constructor to prevent other instances.
        /// </summary>
        private CommentsManager() { }

        /// <summary>
        /// All comments.
        /// </summary>
        private readonly List<CommentGet> _list = new List<CommentGet>();
        /// <summary>
        /// All comments accessible via their ID.
        /// </summary>
        private readonly Dictionary<string, CommentGet> _dict = new Dictionary<string, CommentGet>();

        /// <summary>
        /// List all comments, which have been created and not deleted.
        /// </summary>
        /// <returns>The comment objects.</returns>
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

        /// <summary>
        /// Create a new comment.
        /// </summary>
        /// <param name="data">The new comment data.</param>
        /// <returns>The new comment object.</returns>
        public async Task<CommentGet?> Post(CommentPost data)
        {
            return await Task.Run(async () =>
            {
                // Check user and issue

                await UsersManager.Instance.Get(data.UserId);
                await IssuesManager.Instance.Get(data.IssueId);

                // Create comment

                var comment = new CommentGet();

                comment.UserId = data.UserId;
                comment.IssueId = data.IssueId;
                comment.CommentId = Guid.NewGuid().ToString();
                comment.CreatedAt = DateTime.Now;
                comment.UpdatedAt = DateTime.Now;
                comment.Text = data.Text;

                // Remember comment

                _list.Add(comment);
                _dict.Add(comment.CommentId, comment);

                // Return comment

                return comment;
            });
        }

        /// <summary>
        /// Get an existing comment.
        /// </summary>
        /// <param name="id">The existing comment ID.</param>
        /// <returns>The existing comment object.</returns>
        /// <exception cref="HttpException">Comment ID not found.</exception>
        public async Task<CommentGet?> Get(string id)
        {
            return await Task.Run(() =>
            {
                // Check comment

                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                var comment = _dict[id];

                if (comment.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                // Return comment

                return comment;
            });
        }

        /// <summary>
        /// Update an existing comment.
        /// </summary>
        /// <param name="id">The existing comment ID.</param>
        /// <param name="data">The updated comment data.</param>
        /// <returns>The updated comment object.</returns>
        /// <exception cref="HttpException">Comment ID not found.</exception>
        public async Task<CommentGet?> Put(string id, CommentPut data)
        {
            return await Task.Run(() =>
            {
                // Check comment

                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                var comment = _dict[id];

                if (comment.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                // Update comment

                comment.UpdatedAt = DateTime.Now;
                comment.Text = data.Text;

                // Return comment

                return comment;
            });
        }

        /// <summary>
        /// Delete an existing comment.
        /// </summary>
        /// <param name="id">The exsting comment ID.</param>
        /// <returns>The deleted comment object.</returns>
        /// <exception cref="HttpException">Comment ID not found.</exception>
        public async Task<CommentGet?> Delete(string id)
        {
            return await Task.Run(() =>
            {
                // Check comment

                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                var comment = _dict[id];

                if (comment.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Comment not found");
                }

                // Delete comment

                comment.UpdatedAt = DateTime.Now;
                comment.DeletedAt = DateTime.Now;

                // Return comment

                return comment;
            });
        }

        /// <summary>
        /// Delete all comment by user ID.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>The deleted comment objects.</returns>
        public async Task<List<CommentGet>> DeleteByUserId(string id)
        {
            var result = new List<CommentGet>();

            foreach (var comment in _list)
            {
                if (comment.DeletedAt == null && comment.UserId.Equals(id))
                {
                    await Delete(comment.CommentId);

                    result.Add(comment);
                }
            }

            return result;
        }

        /// <summary>
        /// Delete all comments by issue ID.
        /// </summary>
        /// <param name="id">The issue ID.</param>
        /// <returns>The deleted comment objects.</returns>
        public async Task<List<CommentGet>> DeleteByIssueId(string id)
        {
            var result = new List<CommentGet>();

            foreach (var comment in _list)
            {
                if (comment.DeletedAt == null && comment.IssueId.Equals(id))
                {
                    await Delete(comment.CommentId);

                    result.Add(comment);
                }
            }

            return result;
        }
    }
}
