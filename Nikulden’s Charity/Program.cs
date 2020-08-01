using System;
using System.Collections.Generic;
using System.Linq;

namespace Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input;
            while ((input=Console.ReadLine())!= "Finish")
            {
                var command = input.Split();

                switch (command[0])
                {
                    case "Replace":
                        while (message.Contains(command[1]))
                        {
                            message = message.Replace(command[1], command[2]);
                            Console.WriteLine(message);
                        }
                        break;
                    case "Cut":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        if (startIndex>=0&&endIndex<message.Length)
                        {
                            message = RemovingPartsOfAString(message, command);
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("Invalid indexes!");
                        }
                        break;
                    case "Make":
                        if (command[1]=="Upper")
                        {
                            message = message.ToUpper().ToString();
                            Console.WriteLine(message);
                        }
                        else
                        {
                            message = message.ToLower().ToString();
                            Console.WriteLine(message);
                        }
                        break;
                    case "Check":
                        if (message.Contains(command[1]))
                        {
                            Console.WriteLine($"Message contains {command[1]}");
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {command[1]}");
                        }
                        break;
                    case "Sum":
                        int startIndextToSum = int.Parse(command[1]);
                        int endIndexToSum = int.Parse(command[2]);
                        if (startIndextToSum >= 0 && endIndexToSum < message.Length)
                        {
                            SumsSubstringByASCII(message, startIndextToSum, endIndexToSum);
                        }
                        else
                        {
                            Console.WriteLine("Invalid indexes!");
                        }
                        break;
                }

            }
        }

        private static void SumsSubstringByASCII(string message, int startIndextToSum, int endIndexToSum)
        {
            List<int> numbers = new List<int>();
            var substring = message.Substring(startIndextToSum, (endIndexToSum - startIndextToSum) + 1);
            for (int i = 0; i < substring.Length; i++)
            {
                numbers.Add(substring[i]);
            }
            Console.WriteLine(numbers.Sum());
        }

        private static string RemovingPartsOfAString(string str, string[] instructions)
        {
            int startIndexToSlice = int.Parse(instructions[1]);
            int endIndexToGet = int.Parse(instructions[2]);
            int countOfSymbolsToRemove = (endIndexToGet - startIndexToSlice)+1;
            str = str.Remove(startIndexToSlice, countOfSymbolsToRemove);
            return str;
        }

    }
}
