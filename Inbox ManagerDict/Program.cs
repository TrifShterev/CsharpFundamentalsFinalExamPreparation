using System;
using System.Collections.Generic;
using System.Linq;

namespace Inbox_ManagerDict
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> usersColection = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                var commands = input.Split("->");
                var username = commands[1];
                

                switch (commands[0])
                {
                    case "Add":
                        if (!usersColection.ContainsKey(username))
                        {
                            usersColection.Add(username, new List<string>());
                        }
                        else
                        {
                            Console.WriteLine($"{ username} is already registered");
                        }
                        break;
                    case "Send":
                        var email = commands[2];
                        usersColection[username].Add(email);

                        break;
                    case "Delete":
                        if (!usersColection.ContainsKey(username))
                        {
                            Console.WriteLine($"{username} not found!");
                        }
                        else
                        {
                            usersColection.Remove(username);
                        }
                        break;
                }
            }
            usersColection = usersColection.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"Users count: {usersColection.Count}");
            foreach (var item in usersColection)
            {

                Console.WriteLine(item.Key);
                foreach (var email in item.Value)
                {
                    Console.WriteLine($" - {email}");
                }
            }
        }
    }
}
