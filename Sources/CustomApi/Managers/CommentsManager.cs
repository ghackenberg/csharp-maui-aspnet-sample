using CustomLib.Exceptions.Http;
using CustomLib.Interfaces;
using CustomLib.Models.Comments;

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
        private readonly List<CommentRead> _list = new List<CommentRead>();
        /// <summary>
        /// All comments accessible via their ID.
        /// </summary>
        private readonly Dictionary<string, CommentRead> _dict = new Dictionary<string, CommentRead>();

        /// <summary>
        /// List all comments, which have been created and not deleted.
        /// </summary>
        /// <param name="query">The comment query.</param>
        /// <returns>The comment objects.</returns>
        public async Task<List<CommentRead>> Find(CommentQuery query)
        {
            return await Task.Run(() =>
            {
                var result = new List<CommentRead>();

                foreach (var comment in _list)
                {
                    if (comment.DeletedAt == null && comment.IssueId.Equals(query.IssueId))
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
        public async Task<CommentRead> Create(CommentCreate data)
        {
            return await Task.Run(async () =>
            {
                // Check user and issue

                await UsersManager.Instance.Read(data.UserId);
                await IssuesManager.Instance.Read(data.IssueId);

                // Create comment

                var comment = new CommentRead();

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
        /// <exception cref="NotFoundException">Comment ID not found.</exception>
        public async Task<CommentRead> Read(string id)
        {
            return await Task.Run(() =>
            {
                // Check comment

                if (!_dict.ContainsKey(id))
                {
                    throw new NotFoundException();
                }

                var comment = _dict[id];

                if (comment.DeletedAt != null)
                {
                    throw new NotFoundException();
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
        /// <exception cref="NotFoundException">Comment ID not found.</exception>
        public async Task<CommentRead> Update(string id, CommentUpdate data)
        {
            return await Task.Run(() =>
            {
                // Check comment

                if (!_dict.ContainsKey(id))
                {
                    throw new NotFoundException();
                }

                var comment = _dict[id];

                if (comment.DeletedAt != null)
                {
                    throw new NotFoundException();
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
        /// <exception cref="NotFoundException">Comment ID not found.</exception>
        public async Task<CommentRead> Delete(string id)
        {
            return await Task.Run(() =>
            {
                // Check comment

                if (!_dict.ContainsKey(id))
                {
                    throw new NotFoundException();
                }

                var comment = _dict[id];

                if (comment.DeletedAt != null)
                {
                    throw new NotFoundException();
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
        public async Task<List<CommentRead>> DeleteByUserId(string id)
        {
            var result = new List<CommentRead>();

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
        public async Task<List<CommentRead>> DeleteByIssueId(string id)
        {
            var result = new List<CommentRead>();

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
