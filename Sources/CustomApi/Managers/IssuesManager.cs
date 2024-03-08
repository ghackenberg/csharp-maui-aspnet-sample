using CustomLib.Exceptions.Http;
using CustomLib.Interfaces;
using CustomLib.Models.Issues;

namespace CustomApi.Managers
{
    /// <summary>
    /// Singleton for managing the issues in main memory.
    /// </summary>
    public class IssuesManager : IssuesInterface
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        public static readonly IssuesManager Instance = new IssuesManager();

        /// <summary>
        /// Private constructor to prevent other instances.
        /// </summary>
        private IssuesManager() { }

        /// <summary>
        /// All issues.
        /// </summary>
        private readonly List<IssueGet> _list = new List<IssueGet>();
        /// <summary>
        /// All issues accessible via their ID.
        /// </summary>
        private readonly Dictionary<string, IssueGet> _dict = new Dictionary<string, IssueGet>();

        /// <summary>
        /// List all issues, which have been created and not deleted.
        /// </summary>
        /// <returns>The issue objects.</returns>
        public async Task<List<IssueGet>> List()
        {
            return await Task.Run(() =>
            {
                var result = new List<IssueGet>();

                foreach (var issue in _list)
                {
                    if (issue.DeletedAt == null)
                    {
                        result.Add(issue);
                    }
                }

                return result;
            });
        }

        /// <summary>
        /// Create new issue.
        /// </summary>
        /// <param name="data">The new issue data.</param>
        /// <returns>The new issue object.</returns>
        public async Task<IssueGet> Post(IssuePost data)
        {
            return await Task.Run(async () =>
            {
                // Check user

                await UsersManager.Instance.Get(data.UserId);

                // Create issue

                var issue = new IssueGet();

                issue.UserId = data.UserId;
                issue.IssueId = Guid.NewGuid().ToString();
                issue.CreatedAt = DateTime.Now;
                issue.UpdatedAt = DateTime.Now;
                issue.Label = data.Label;

                // Remember issue

                _list.Add(issue);
                _dict.Add(issue.IssueId, issue);

                // Return issue

                return issue;
            });
        }

        /// <summary>
        /// Get an existing issue.
        /// </summary>
        /// <param name="id">The existing issue id.</param>
        /// <returns>The existing user object.</returns>
        /// <exception cref="NotFoundException">Issue ID not found.</exception>
        public async Task<IssueGet> Get(string id)
        {
            return await Task.Run(() =>
            {
                // Check issue

                if (!_dict.ContainsKey(id))
                {
                    throw new NotFoundException();
                }

                var issue = _dict[id];

                if (issue.DeletedAt != null)
                {
                    throw new NotFoundException();
                }

                // Return issue

                return issue;
            });
        }

        /// <summary>
        /// Update an existing issue.
        /// </summary>
        /// <param name="id">The existing issue ID.</param>
        /// <param name="data">The updated issue data.</param>
        /// <returns>The updated issue object.</returns>
        /// <exception cref="NotFoundException">Issue ID not found.</exception>
        public async Task<IssueGet> Put(string id, IssuePut data)
        {
            return await Task.Run(() =>
            {
                // Check issue

                if (!_dict.ContainsKey(id))
                {
                    throw new NotFoundException();
                }

                var issue = _dict[id];

                if (issue.DeletedAt != null)
                {
                    throw new NotFoundException();
                }

                // Update issue

                issue.UpdatedAt = DateTime.Now;
                issue.Label = data.Label;

                // Return issue

                return issue;
            });
        }

        /// <summary>
        /// Delete an existing issue and its comments.
        /// </summary>
        /// <param name="id">The existing issue ID.</param>
        /// <returns>The deleted issue object.</returns>
        /// <exception cref="NotFoundException">Issue ID not found.</exception>
        public async Task<IssueGet> Delete(string id)
        {
            // Check issue
            
            if (!_dict.ContainsKey(id))
            {
                throw new NotFoundException();
            }

            var issue = _dict[id];

            if (issue.DeletedAt != null)
            {
                throw new NotFoundException();
            }

            // Delete issue

            issue.UpdatedAt = DateTime.Now;
            issue.DeletedAt = DateTime.Now;

            // Delete issue comments

            await CommentsManager.Instance.DeleteByIssueId(id);

            // Return issue

            return issue;
        }

        /// <summary>
        /// Delete all existing issues by user ID.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>The deleted issue objects.</returns>
        public async Task<List<IssueGet>> DeleteByUserId(string id)
        {
            var result = new List<IssueGet>();

            foreach (var issue in _list)
            {
                if (issue.DeletedAt == null && issue.UserId.Equals(id))
                {
                    await Delete(issue.IssueId);

                    result.Add(issue);
                }
            }

            return result;
        }
    }
}
