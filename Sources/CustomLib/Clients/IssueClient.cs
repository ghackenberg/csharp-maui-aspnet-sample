using CustomLib.Interfaces;
using CustomLib.Models.Issues;

namespace CustomLib.Clients
{
    public class IssueClient : AbstractClient<IssueGet, IssuePost, IssuePut>, IssuesInterface
    {
        public static readonly IssueClient Instance = new IssueClient();

        private IssueClient() : base("issues")
        {

        }
    }
}
