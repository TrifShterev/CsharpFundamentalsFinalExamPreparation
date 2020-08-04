using System;
using System.Collections.Generic;
using System.Linq;

namespace Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string input;
            while ((input=Console.ReadLine())!= "Complete")
            {
                string[] command = input.Split();

                if (command.Contains("Make")&&command.Contains("Upper"))
                {
                    email = email.ToUpper();
                    Console.WriteLine(email);
                }
                else if (command.Contains("Make")&&command.Contains("Lower"))
                {
                    email = email.ToLower();
                    Console.WriteLine(email);
                }
                else if (command.Contains("GetDomain"))
                {
                    int count = int.Parse(command[1]);
                    var domain = email.TakeLast(count);
                    Console.WriteLine(String.Join("",domain));
                }
                else if (command.Contains("GetUsername"))
                {
                    if (email.Contains("@"))
                    {
                        var index = email.IndexOf('@');
                        var userName = email.Substring(0, index);
                        Console.WriteLine(userName);

                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }

                }
                else if (command.Contains("Replace"))
                {
                    char symbol = char.Parse(command[1]);
                    Console.WriteLine(ReplacingCharInString(email, symbol));
                    
                }
                else if (command.Contains("Encrypt"))
                {
                    EncryptStringByASCII(email);

                }
            }
        }

        private static void EncryptStringByASCII(string email)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < email.Length; i++)
            {
                numbers.Add(email[i]);
            }
            Console.WriteLine(String.Join(" ",numbers));
        }

        private static string ReplacingCharInString(string email, char symbol)
        {
            while (email.Contains(symbol))
            {
               email= email.Replace(symbol,'-');
            }
            return email;
        }
    }
}
