using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern= @"[!](?<command>[A-Z][a-z]{2,})[!]:\[(?<message>[A-Za-z]{8,})\]";

                Match message = Regex.Match(input, pattern);
                if (message.Success)
                {
                    EncryptingByASCIIToNumbers(message);
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }

        private static void EncryptingByASCIIToNumbers(Match message)
        {
            List<int> numbers = new List<int>();
            var wordToEncrypt = message.Groups["message"].ToString();
            for (int j = 0; j < wordToEncrypt.Length; j++)
            {
                numbers.Add(wordToEncrypt[j]);

            }
            Console.WriteLine($"{message.Groups["command"]}: {String.Join(' ', numbers)}");
        }
    }
}
