using System;
using System.Text.RegularExpressions;

namespace Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var count = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input,@"([U][$])(?<name>[A-Z][a-z]{2,})(\1)([P][@][$])(?<password>[A-za-z]{3,}[0-9]+)(\3)");

                if (match.Success)
                {
                    
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["name"]}, Password: {match.Groups["password"]}");
                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }

            }
            Console.WriteLine($"Successful registrations: {count}");         
            
        }
    }
}
