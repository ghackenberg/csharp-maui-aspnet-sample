using CustomLib.Interfaces;
using CustomLib.Models.Issues;

namespace CustomLib.Clients
{
    /// <summary>
    /// A singleton for callding issue CRUD operations via HTTP.
    /// </summary>
    public class IssuesClient : AbstractClient<IssueGet, IssuePost, IssuePut>, IssuesInterface
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        public static readonly IssuesClient Instance = new IssuesClient();

        /// <summary>
        /// The private constructor preventing other singleton instances.
        /// </summary>
        private IssuesClient() : base("issues") { }
    }
}
