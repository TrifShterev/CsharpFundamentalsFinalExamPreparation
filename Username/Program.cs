using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Sign up")
            {
                var command = input.Split();

                switch (command[0])
                {
                    case "Case":
                        if (command[1] == "upper")
                        {
                            username = username.ToUpper();
                            Console.WriteLine(username);
                        }
                        else if(command[1] == "lower")
                        {
                            username = username.ToLower();
                            Console.WriteLine(username);
                        }
                        break;
                    case "Reverse":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        if (startIndex >= 0 && endIndex <= username.Length-1)
                        {
                            int length = endIndex - startIndex;
                            var substring = username.Substring(startIndex, length + 1).Reverse().ToList();
                            Console.WriteLine(String.Concat(substring));
                        }
                        break;
                    case "Cut":
                        if (username.Contains(command[1]))
                        {

                            username = username.Remove(username.IndexOf(command[1]), command[1].Length);
                            Console.WriteLine(username);

                        }
                        else
                        {
                            Console.WriteLine($"The word {username} doesn't contain {command[1]}.");
                        }
                        break;
                    case "Replace":
                        var symbol = char.Parse(command[1]);
                        if (username.Contains(symbol))
                        {
                            username = ReplacingCharInString(username, symbol);
                            Console.WriteLine(username);
                        }
                       
                        break;
                    case "Check":
                        var symbolToCheckFor = char.Parse(command[1]);
                        if (username.Contains(symbolToCheckFor))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {symbolToCheckFor}."
);
                        }
                        break;
                }

            }
        }
        private static string ReplacingCharInString(string str, char symbol)
        {
            while (str.Contains(symbol))
            {
                str = str.Replace(symbol, '*');
            }
            return str;
        }
    }
}
