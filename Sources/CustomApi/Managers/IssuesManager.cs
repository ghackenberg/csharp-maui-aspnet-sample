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

        private readonly List<IssueGet> _issues = new List<IssueGet>();

        public async Task<List<IssueGet>?> List()
        {
            return await Task.Run(() =>
            {
                var result = new List<IssueGet>();

                foreach (var issue in _issues)
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
            return await Task.Run(() =>
            {
                var issue = new IssueGet();
                issue.UserId = data.UserId;
                issue.IssueId = $"Issue-{_issues.Count}";
                issue.CreatedAt = DateTime.Now;
                issue.UpdatedAt = DateTime.Now;
                issue.Label = data.Label;

                _issues.Add(issue);

                return issue;
            });
        }

        public async Task<IssueGet?> Get(string id)
        {
            return await Task.Run(() =>
            {
                foreach (var issue in _issues)
                {
                    if (issue.DeletedAt == null && issue.IssueId.Equals(id))
                    {
                        return issue;
                    }
                }
                throw new HttpException(HttpStatusCode.NotFound, "Not found");
            });
        }

        public async Task<IssueGet?> Put(string id, IssuePut data)
        {
            return await Task.Run(() =>
            {
                foreach (var issue in _issues)
                {
                    if (issue.DeletedAt == null && issue.IssueId.Equals(id))
                    {
                        issue.UpdatedAt = DateTime.Now;
                        issue.Label = data.Label;

                        return issue;
                    }
                }
                throw new HttpException(HttpStatusCode.NotFound, "Not found");
            });
        }

        public async Task<IssueGet?> Delete(string id)
        {
            return await Task.Run(() =>
            {
                foreach (var issue in _issues)
                {
                    if (issue.DeletedAt == null && issue.IssueId.Equals(id))
                    {
                        issue.UpdatedAt = DateTime.Now;
                        issue.DeletedAt = DateTime.Now;

                        return issue;
                    }
                }
                throw new HttpException(HttpStatusCode.NotFound, "Not found");
            });
        }
    }
}
