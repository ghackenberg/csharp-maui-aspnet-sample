using CustomLib.Interfaces;
using CustomLib.Models.Issues;

namespace CustomSdk.Clients
{
    /// <summary>
    /// A singleton for callding issue CRUD operations via HTTP.
    /// </summary>
    public class IssuesClient : AbstractClient<IssueRead, IssueQuery, IssueCreate, IssueUpdate>, IssuesInterface
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
