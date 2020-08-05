using System;
using System.Text.RegularExpressions;

namespace PasswordREGEXImportant
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match pass = Regex.Match(input, @"^(.+)>(?<one>\d{3})\|(?<two>[a-z]{3})\|(?<three>[A-Z]{3})\|(?<four>[^<>]{3})<\1$");
                if (pass.Success)
                {
                    string first = pass.Groups["one"].ToString();
                    string second = pass.Groups["two"].ToString();
                    string third = pass.Groups["three"].ToString();
                    string fourth = pass.Groups["four"].ToString();
                  Console.WriteLine($"Password: {first + second + third+fourth}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
