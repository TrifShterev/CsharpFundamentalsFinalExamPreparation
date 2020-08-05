using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> followers = new Dictionary<string, List<int>>();

            string input;
            while ((input=Console.ReadLine())!= "Log out")
            {
                var command = input.Split(":");
                string username = command[1];

                switch (command[0])
                {
                    case "New follower":
                        if (!followers.ContainsKey(username))
                        {
                            followers.Add(username, new List<int>());
                            followers[username].Add(0);
                            followers[username].Add(0);
                        }
                        break;
                    case "Like":
                        int likes = int.Parse(command[2]);
                        if (!followers.ContainsKey(username))
                        {
                            followers.Add(username, new List<int>());
                            followers[username].Add( likes);
                            followers[username].Add(0);
                        }
                        else
                        {
                            followers[username][0]+=likes;
                        }
                        break;
                    case "Comment":
                        if (!followers.ContainsKey(username))
                        {
                            followers.Add(username, new List<int>());
                            followers[username].Add(1);
                        }
                        else
                        {
                            followers[username][1] += 1;
                        }
                        break;
                    case "Blocked":
                        if (!followers.ContainsKey(username))
                        {
                            Console.WriteLine($"{username} doesn't exist.");
                        }
                        else
                        {
                            followers.Remove(username);
                        }
                        break;
                }
            }
            followers = followers.OrderByDescending(x =>x.Value.Sum()).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"{followers.Count} followers");
            foreach (var item in followers)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Sum()}");
            }
        }
    }
}
