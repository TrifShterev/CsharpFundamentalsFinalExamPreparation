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
//                A password is valid when:
//It starts with a group of  symbols and ends with the same symbols(the same length)
//There is a greater than sign(>) after the first group and a less than sign(<) before the last one
//In between the greater than sign and the less than sign there are four groups(each of three characters), separated by pipe("|")
//The first group consists only of numbers
//The second group – only lower case letters
//The third one – only upper case letters
//The fourth one – all symbols except '<' and '>'
//Example for a valid message: 
//"$$$>312|dfe|KFE|@!#<$$$"
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
