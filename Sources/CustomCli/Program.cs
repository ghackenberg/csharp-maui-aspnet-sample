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
                    Console.WriteLine("Supported commands: quit, help, list users, list issues, list comments");
                }
                else
                {
                    Console.Error.WriteLine("Command not supported!");
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
                    else if (command[1].Equals("comments"))
                    {
                        await ListComments();
                    }
                    else
                    {
                        Console.Error.WriteLine("Command not supported!");
                    }
                }
                else
                {
                    Console.Error.WriteLine("Command not supported!");
                }
            }
            else
            {
                Console.Error.WriteLine("Command not supported!");
            }
            return true;
        }

        static async Task ListUsers()
        {
            foreach (var user in await UsersClient.Instance.List())
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

        static async Task ListIssues()
        {
            foreach (var issue in await IssuesClient.Instance.List())
            {
                Console.WriteLine(issue.Label);
            }
        }

        static async Task ListComments()
        {
            foreach (var comment in await CommentsClient.Instance.List())
            {
                Console.WriteLine(comment.Text);
            }
        }
    }
}
