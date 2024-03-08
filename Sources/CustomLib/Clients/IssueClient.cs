using CustomLib.Interfaces;
using CustomLib.Models.Issues;

namespace CustomLib.Clients
{
    /// <summary>
    /// A singleton for callding issue CRUD operations via HTTP.
    /// </summary>
    public class IssueClient : AbstractClient<IssueGet, IssuePost, IssuePut>, IssuesInterface
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        public static readonly IssueClient Instance = new IssueClient();

        /// <summary>
        /// The private constructor preventing other singleton instances.
        /// </summary>
        private IssueClient() : base("issues") { }
    }
}
