using CustomLib.Models.Comments;
using CustomLib.Models.Issues;
using CustomLib.Models.Users;
using CustomSdk.Clients;

namespace CustomCli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Reading commands from standard input");

                    // Loop-read multiple commands from standard input
                    Loop().Wait();
                }
                else
                {
                    Console.WriteLine("Reading command from program arguments");

                    // Read single command from program arguments
                    Process(args).Wait();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Could not execute program: {ex.Message}");
            }
        }

        private static async Task Loop()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine();

                    Console.Write("Please enter next command: ");

                    var command = Console.ReadLine();

                    Console.WriteLine();

                    if (command == null)
                    {
                        Console.Error.WriteLine("Could not process command!");
                    }
                    else
                    {
                        if (await Process(command.Split(" ")))
                        {
                            // Read next command
                            continue;
                        }
                        else
                        {
                            // Stop reading commands
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Could not execute command: {ex.Message}");
                }
            }
        }

        private static async Task<bool> Process(string[] command)
        {
            if (command.Length == 1)
            {
                if (command[0].Equals("quit"))
                {
                    Console.WriteLine("Good bye!");
                    return false;
                }
                else if (command[0].Equals("help"))
                {
                    PrintHelp();
                }
                else
                {
                    PrintUnknownCommand();
                }
            }
            else if (command.Length == 2)
            {
                if (command[0].Equals("find"))
                {
                    if (command[1].Equals("users"))
                    {
                        await FindUsers();
                    }
                    else if (command[1].Equals("issues"))
                    {
                        await FindIssues();
                    }
                    else
                    {
                        PrintUnknownCommand();
                    }
                }
                else
                {
                    PrintUnknownCommand();
                }
            }
            else if (command.Length == 3)
            {
                if (command[0].Equals("find"))
                {
                    if (command[1].Equals("comments"))
                    {
                        await FindComments(command[2]);
                    }
                    else
                    {
                        PrintUnknownCommand();
                    }
                }
                else if (command[0].Equals("read"))
                {
                    if (command[1].Equals("user"))
                    {
                        await ReadUser(command[2]);
                    }
                    else if (command[1].Equals("issue"))
                    {
                        await ReadIssue(command[2]);
                    }
                    else if (command[1].Equals("comment"))
                    {
                        await ReadComment(command[2]);
                    }
                    else
                    {
                        PrintUnknownCommand();
                    }
                }
                else if (command[0].Equals("delete"))
                {
                    if (command[1].Equals("user"))
                    {
                        await DeleteUser(command[2]);
                    }
                    else if (command[1].Equals("issue"))
                    {
                        await DeleteIssue(command[2]);
                    }
                    else if (command[1].Equals("comment"))
                    {
                        await DeleteComment(command[2]);
                    }
                    else
                    {
                        PrintUnknownCommand();
                    }
                }
                else
                {
                    PrintUnknownCommand();
                }
            }
            else if (command.Length == 4)
            {
                if (command[0].Equals("create"))
                {
                    if (command[1].Equals("user"))
                    {
                        await CreateUser(command[2], command[3]);
                    }
                    else if (command[1].Equals("issue"))
                    {
                        await CreateIssue(command[2], command[3]);
                    }
                    else
                    {
                        PrintUnknownCommand();
                    }
                }
                else if (command[0].Equals("update"))
                {
                    if (command[1].Equals("issue"))
                    {
                        await UpdateIssue(command[2], command[3]);
                    }
                    else if (command[1].Equals("comment"))
                    {
                        await UpdateComment(command[2], command[3]);
                    }
                    else
                    {
                        PrintUnknownCommand();
                    }
                }
                else
                {
                    PrintUnknownCommand();
                }
            }
            else if (command.Length == 5)
            {
                if (command[0].Equals("create"))
                {
                    if (command[1].Equals("comment"))
                    {
                        await CreateComment(command[2], command[3], command[4]);
                    }
                    else
                    {
                        PrintUnknownCommand();
                    }
                }
                else if (command[0].Equals("update"))
                {
                    if (command[1].Equals("user"))
                    {
                        await UpdateUser(command[2], command[3], command[4]);
                    }
                    else
                    {
                        PrintUnknownCommand();
                    }
                }
                else
                {
                    PrintUnknownCommand();
                }
            }
            else
            {
                PrintUnknownCommand();
            }
            return true;
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Supported commands:");
            Console.WriteLine(" - quit");
            Console.WriteLine(" - help");
            Console.WriteLine(" - find users");
            Console.WriteLine(" - find issues");
            Console.WriteLine(" - find comments <issueId>");
            Console.WriteLine(" - create user <firstName> <lastName>");
            Console.WriteLine(" - create issue <userId> <label>");
            Console.WriteLine(" - create comment <userId> <issueId> <text>");
            Console.WriteLine(" - read user <userId>");
            Console.WriteLine(" - read issue <issueId>");
            Console.WriteLine(" - read comment <commentId>");
            Console.WriteLine(" - update user <userId> <firstName> <lastName>");
            Console.WriteLine(" - update issue <issueId> <label>");
            Console.WriteLine(" - update comment <commentId> <text>");
            Console.WriteLine(" - delete user <userId>");
            Console.WriteLine(" - delete issue <issueId>");
            Console.WriteLine(" - delete comment <commentId>");
        }

        private static async Task FindUsers()
        {
            var query = new UserQuery();

            foreach (var user in await UsersClient.Instance.Find(query))
            {
                await PrintUser(user);
            }
        }

        private static async Task FindIssues()
        {
            var query = new IssueQuery();

            foreach (var issue in await IssuesClient.Instance.Find(query))
            {
                await PrintIssue(issue);
            }
        }

        private static async Task FindComments(string issueId)
        {
            var query = new CommentQuery();

            query.IssueId = issueId;

            foreach (var comment in await CommentsClient.Instance.Find(query))
            {
                await PrintComment(comment);
            }
        }

        private static async Task CreateUser(string firstName, string lastName)
        {
            var data = new UserCreate();

            data.FirstName = firstName;
            data.LastName = lastName;

            var user = await UsersClient.Instance.Create(data);

            await PrintUser(user);
        }

        private static async Task CreateIssue(string userId, string label)
        {
            var data = new IssueCreate();

            data.UserId = userId;
            data.Label = label;

            var issue = await IssuesClient.Instance.Create(data);

            await PrintIssue(issue);
        }

        private static async Task CreateComment(string userId, string issueId, string text)
        {
            var data = new CommentCreate();

            data.UserId = userId;
            data.IssueId = issueId;
            data.Text = text;

            var comment = await CommentsClient.Instance.Create(data);

            await PrintComment(comment);
        }

        private static async Task ReadUser(string userId)
        {
            var user = await UsersClient.Instance.Read(userId);

            await PrintUser(user);
        }

        private static async Task ReadIssue(string issueId)
        {
            var issue = await IssuesClient.Instance.Read(issueId);

            await PrintIssue(issue);
        }

        private static async Task ReadComment(string commentId)
        {
            var comment = await CommentsClient.Instance.Read(commentId);

            await PrintComment(comment);
        }

        private static async Task UpdateUser(string userId, string firstName, string lastName)
        {
            var data = new UserUpdate();

            data.FirstName = firstName;
            data.LastName = lastName;

            var user = await UsersClient.Instance.Update(userId, data);

            await PrintUser(user);
        }

        private static async Task UpdateIssue(string issueId, string label)
        {
            var data = new IssueUpdate();

            data.Label = label;

            var issue = await IssuesClient.Instance.Update(issueId, data);

            await PrintIssue(issue);
        }

        private static async Task UpdateComment(string commentId, string text)
        {
            var data = new CommentUpdate();

            data.Text = text;

            var comment = await CommentsClient.Instance.Update(commentId, data);

            await PrintComment(comment);
        }

        private static async Task DeleteUser(string userId)
        {
            var user = await UsersClient.Instance.Delete(userId);

            await PrintUser(user);
        }

        private static async Task DeleteIssue(string issueId)
        {
            var issue = await IssuesClient.Instance.Delete(issueId);

            await PrintIssue(issue);
        }

        private static async Task DeleteComment(string commentId)
        {
            var comment = await CommentsClient.Instance.Delete(commentId);

            await PrintComment(comment);
        }

        private static async Task PrintUser(UserRead user)
        {
            await Task.Run(() => { });

            Console.WriteLine($"[{user.UserId}] {user.FirstName} {user.LastName}");
            Console.WriteLine($" - (Created: {user.CreatedAt}, Updated: {user.UpdatedAt}, Deleted: {user.DeletedAt})");
        }

        private static async Task PrintIssue(IssueRead issue)
        {
            var user = await UsersClient.Instance.Read(issue.UserId);

            Console.WriteLine($"[{issue.IssueId}] {issue.Label}");
            Console.WriteLine($" - (User: {user.FirstName} {user.LastName}");
            Console.WriteLine($" - (Created: {issue.CreatedAt}, Updated: {issue.UpdatedAt}, Deleted: {issue.DeletedAt})");
        }

        private static async Task PrintComment(CommentRead comment)
        {
            var user = await UsersClient.Instance.Read(comment.UserId);
            var issue = await IssuesClient.Instance.Read(comment.IssueId);

            Console.WriteLine($"[{comment.CommentId}] {comment.Text}");
            Console.WriteLine($" - (User: {user.FirstName} {user.LastName}");
            Console.WriteLine($" - (Issue: {issue.Label})");
            Console.WriteLine($" - (Created: {comment.CreatedAt}, Updated: {comment.UpdatedAt}, Deleted: {comment.DeletedAt})");
        }

        private static void PrintUnknownCommand()
        {
            Console.Error.WriteLine("Unknown command!");
            Console.WriteLine();
            PrintHelp();
        }
    }
}
