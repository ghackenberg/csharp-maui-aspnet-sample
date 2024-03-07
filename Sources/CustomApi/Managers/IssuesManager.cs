using CustomLib.Exceptions;
using CustomLib.Interfaces;
using CustomLib.Models.Issues;
using System.Net;

namespace CustomApi.Managers
{
    public class IssuesManager : IssuesInterface
    {
        public static readonly IssuesManager Instance = new IssuesManager();

        private IssuesManager() { }

        private readonly List<IssueGet> _list = new List<IssueGet>();

        private readonly Dictionary<string, IssueGet> _dict = new Dictionary<string, IssueGet>();

        public async Task<List<IssueGet>?> List()
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

        public async Task<IssueGet?> Post(IssuePost data)
        {
            return await Task.Run(async () =>
            {
                // Check if user exists
                await UsersManager.Instance.Get(data.UserId);

                var issue = new IssueGet();

                issue.UserId = data.UserId;
                issue.IssueId = Guid.NewGuid().ToString();
                issue.CreatedAt = DateTime.Now;
                issue.UpdatedAt = DateTime.Now;
                issue.Label = data.Label;

                _list.Add(issue);
                _dict.Add(issue.IssueId, issue);

                return issue;
            });
        }

        public async Task<IssueGet?> Get(string id)
        {
            return await Task.Run(() =>
            {
                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Issue not found");
                }

                var issue = _dict[id];

                if (issue.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Issue not found");
                }

                return issue;
            });
        }

        public async Task<IssueGet?> Put(string id, IssuePut data)
        {
            return await Task.Run(() =>
            {
                if (!_dict.ContainsKey(id))
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Issue not found");
                }

                var issue = _dict[id];

                if (issue.DeletedAt != null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Issue not found");
                }

                issue.UpdatedAt = DateTime.Now;
                issue.Label = data.Label;

                return issue;
            });
        }

        public async Task<IssueGet?> Delete(string id)
        {
            if (!_dict.ContainsKey(id))
            {
                throw new HttpException(HttpStatusCode.NotFound, "Issue not found");
            }

            var issue = _dict[id];

            if (issue.DeletedAt != null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "Issue not found");
            }

            issue.UpdatedAt = DateTime.Now;
            issue.DeletedAt = DateTime.Now;

            // Delete issue comments
            await CommentsManager.Instance.DeleteByIssueId(id);

            return issue;
        }

        public async Task DeleteByUserId(string id)
        {
            foreach (var issue in _list)
            {
                if (issue.DeletedAt == null && issue.UserId.Equals(id))
                {
                    await Delete(issue.IssueId);
                }
            }
        }
    }
}
