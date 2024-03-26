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
                    Loop().Wait();
                }
                else
                {
                    Process(args).Wait();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Could not execute program: {ex.Message}");
            }
        }

        static async Task Loop()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter next command: ");

                    var command = Console.ReadLine();

                    if (command == null)
                    {
                        Console.WriteLine("Could not process command!");
                    }
                    else
                    {
                        if (await Process(command.Split(" ")))
                        {
                            continue;
                        }
                        else
                        {
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

        static async Task<bool> Process(string[] command)
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
                    Console.WriteLine("Supported commands:");
                    Console.WriteLine(" - quit");
                    Console.WriteLine(" - help");
                    Console.WriteLine(" - list users");
                    Console.WriteLine(" - list issues");
                    Console.WriteLine(" - list comments <issueId>");
                    Console.WriteLine(" - post user <firstName> <lastName>");
                    Console.WriteLine(" - post issue <userId> <label>");
                    Console.WriteLine(" - post comment <userId> <issueId> <text>");
                    Console.WriteLine(" - get user <userId>");
                    Console.WriteLine(" - get issue <issueId>");
                    Console.WriteLine(" - get comment <commentId>");
                    Console.WriteLine(" - put user <userId> <firstName> <lastName>");
                    Console.WriteLine(" - put issue <issueId> <label>");
                    Console.WriteLine(" - put comment <commentId> <text>");
                    Console.WriteLine(" - delete user <userId>");
                    Console.WriteLine(" - delete issue <issueId>");
                    Console.WriteLine(" - delete comment <commentId>");
                }
                else
                {
                    CommandNotSupported();
                }
            }
            else if (command.Length == 2)
            {
                if (command[0].Equals("list"))
                {
                    if (command[1].Equals("users"))
                    {
                        await ListUsers();
                    }
                    else if (command[1].Equals("issues"))
                    {
                        await ListIssues();
                    }
                    else
                    {
                        CommandNotSupported();
                    }
                }
                else
                {
                    CommandNotSupported();
                }
            }
            else if (command.Length == 3)
            {
                if (command[0].Equals("list"))
                {
                    if (command[1].Equals("comments"))
                    {
                        await ListComments(command[2]);
                    }
                    else
                    {
                        CommandNotSupported();
                    }
                }
                else if (command[0].Equals("get"))
                {
                    if (command[1].Equals("user"))
                    {
                        await GetUser(command[2]);
                    }
                    else if (command[1].Equals("issue"))
                    {
                        await GetIssue(command[2]);
                    }
                    else if (command[1].Equals("comment"))
                    {
                        await GetComment(command[2]);
                    }
                    else
                    {
                        CommandNotSupported();
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
                        CommandNotSupported();
                    }
                }
                else
                {
                    CommandNotSupported();
                }
            }
            else if (command.Length == 4)
            {
                if (command[0].Equals("post"))
                {
                    if (command[1].Equals("user"))
                    {
                        await PostUser(command[2], command[3]);
                    }
                    else if (command[1].Equals("issue"))
                    {
                        await PostIssue(command[2], command[3]);
                    }
                    else
                    {
                        CommandNotSupported();
                    }
                }
                else if (command[0].Equals("Put"))
                {
                    if (command[1].Equals("issue"))
                    {
                        await PutIssue(command[2], command[3]);
                    }
                    else if (command[1].Equals("comment"))
                    {
                        await PutComment(command[2], command[3]);
                    }
                    else
                    {
                        CommandNotSupported();
                    }
                }
                else
                {
                    CommandNotSupported();
                }
            }
            else if (command.Length == 5)
            {
                if (command[0].Equals("post"))
                {
                    if (command[1].Equals("comment"))
                    {
                        await PostComment(command[2], command[3], command[4]);
                    }
                    else
                    {
                        CommandNotSupported();
                    }
                }
                else if (command[0].Equals("put"))
                {
                    if (command[1].Equals("user"))
                    {
                        await PutUser(command[2], command[3], command[4]);
                    }
                    else
                    {
                        CommandNotSupported();
                    }
                }
                else
                {
                    CommandNotSupported();
                }
            }
            else
            {
                CommandNotSupported();
            }
            return true;
        }

        static async Task ListUsers()
        {
            var query = new UserQuery();

            foreach (var user in await UsersClient.Instance.List(query))
            {
                await PrintUser(user);
            }
        }

        static async Task ListIssues()
        {
            var query = new IssueQuery();

            foreach (var issue in await IssuesClient.Instance.List(query))
            {
                await PrintIssue(issue);
            }
        }

        static async Task ListComments(string issueId)
        {
            var query = new CommentQuery();

            query.IssueId = issueId;

            foreach (var comment in await CommentsClient.Instance.List(query))
            {
                await PrintComment(comment);
            }
        }

        static async Task PostUser(string firstName, string lastName)
        {
            var data = new UserPost();

            data.FirstName = firstName;
            data.LastName = lastName;

            await UsersClient.Instance.Post(data);
        }

        static async Task PostIssue(string userId, string label)
        {
            var data = new IssuePost();

            data.UserId = userId;
            data.Label = label;

            await IssuesClient.Instance.Post(data);
        }

        static async Task PostComment(string userId, string issueId, string text)
        {
            var data = new CommentPost();

            data.UserId = userId;
            data.IssueId = issueId;
            data.Text = text;

            await CommentsClient.Instance.Post(data);
        }

        static async Task GetUser(string userId)
        {
            var user = await UsersClient.Instance.Get(userId);

            await PrintUser(user);
        }

        static async Task GetIssue(string issueId)
        {
            var issue = await IssuesClient.Instance.Get(issueId);

            await PrintIssue(issue);
        }

        static async Task GetComment(string commentId)
        {
            var comment = await CommentsClient.Instance.Get(commentId);

            await PrintComment(comment);
        }

        static async Task PutUser(string userId, string firstName, string lastName)
        {
            var data = new UserPut();

            data.FirstName = firstName;
            data.LastName = lastName;

            await UsersClient.Instance.Put(userId, data);
        }

        static async Task PutIssue(string issueId, string label)
        {
            var data = new IssuePut();

            data.Label = label;

            await IssuesClient.Instance.Put(issueId, data);
        }

        static async Task PutComment(string commentId, string text)
        {
            var data = new CommentPut();

            data.Text = text;

            await CommentsClient.Instance.Put(commentId, data);
        }

        static async Task DeleteUser(string userId)
        {
            await UsersClient.Instance.Delete(userId);
        }

        static async Task DeleteIssue(string issueId)
        {
            await IssuesClient.Instance.Delete(issueId);
        }

        static async Task DeleteComment(string commentId)
        {
            await CommentsClient.Instance.Delete(commentId);
        }

        static async Task PrintUser(UserGet user)
        {
            await Task.Run(() => Console.WriteLine($"[{user.UserId}] {user.FirstName} {user.LastName}"));
        }

        static async Task PrintIssue(IssueGet issue)
        {
            var user = await UsersClient.Instance.Get(issue.UserId);

            Console.WriteLine($"[{issue.IssueId}] {user.FirstName} {user.LastName}: {issue.Label}");
        }

        static async Task PrintComment(CommentGet comment)
        {
            var user = await UsersClient.Instance.Get(comment.UserId);
            var issue = await IssuesClient.Instance.Get(comment.IssueId);

            Console.WriteLine($"[{comment.CommentId}] {user.FirstName} {user.LastName}: {issue.Label} -> {comment.Text}");
        }

        static void CommandNotSupported()
        {
            Console.Error.WriteLine("Command not supported!");
        }
    }
}
