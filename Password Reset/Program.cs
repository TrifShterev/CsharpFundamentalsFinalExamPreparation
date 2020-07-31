using System;
using System.Collections.Generic;

namespace Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input;
            while ((input=Console.ReadLine())!="Done")
            {
                var command = input.Split();

                switch (command[0])
                {
                    case "TakeOdd":
                      password=  FindingOddsByIndexInList(password);
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int startIndex = int.Parse(command[1]);
                        int length = int.Parse(command[2]);
                        password = password.Remove(startIndex, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string substring = command[1];
                        string substitute = command[2];
                        if (!password.Contains(substring))
                        {
                            Console.WriteLine("Nothing to replace!");
                            continue;
                        }
                        password = ReplacingSubstringMethodInString(password, substring, substitute);
                        Console.WriteLine(password);
                        break;
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }

        private static string ReplacingSubstringMethodInString(string password, string substring, string substitute)
        {
            while (password.Contains(substring))
            {
                password = password.Replace(substring, substitute);
            }
            
            return password;
        }

        static string FindingOddsByIndexInList(string input)
        {
            string PasswordOdds = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 1)
                {
                    PasswordOdds += input[i];
                }
            }
            return PasswordOdds;
        }
    }
}
