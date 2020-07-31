using System;
using System.Linq;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string input;
            while ((input=Console.ReadLine())!="Generate")
            {
                var instructions = input.Split(">>>");
                switch (instructions[0])
                {
                    case "Contains":
                        if (activationKey.Contains(instructions[1]))
                        {
                            Console.WriteLine($"{activationKey} contains {instructions[1]}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        int startIndex = int.Parse(instructions[2]);
                        int endIndex = int.Parse(instructions[3]);
                        if (instructions[1] == "Upper")
                        {
                            activationKey= MakesPartOfStringToUpperCases(startIndex, endIndex, activationKey);
                            Console.WriteLine(activationKey);
                        }
                        else if (instructions[1] == "Lower")
                        {
                           activationKey= MakesPartOfStringToLowerCases(startIndex, endIndex, activationKey);
                            Console.WriteLine(activationKey);
                        }
                        break;
                    case "Slice":
                    activationKey= RemovingPartsOfAString(activationKey, instructions);
                        Console.WriteLine(activationKey);
                        break;
                }
            }
            
            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        private static string RemovingPartsOfAString(string activationKey, string[] instructions)
        {
            int startIndexToSlice = int.Parse(instructions[1]);
            int endIndexToGet = int.Parse(instructions[2]);
            int countOfSymbolsToRemove = endIndexToGet - startIndexToSlice;
            activationKey = activationKey.Remove(startIndexToSlice, countOfSymbolsToRemove);
            return activationKey;
        }

        static string MakesPartOfStringToUpperCases(int startIndex, int endIndex, string rawString)
        { int length = endIndex - startIndex;
            var substring = rawString.Substring(startIndex, length).ToUpper().ToString();
            rawString = rawString.Remove(startIndex, length);
            rawString = rawString.Insert(startIndex, substring);

            return rawString;

        }
        static string MakesPartOfStringToLowerCases(int startIndex, int endIndex, string rawString)
        {
            int length = endIndex - startIndex;
            var substring = rawString.Substring(startIndex, length).ToLower().ToString();
            rawString = rawString.Remove(startIndex, length);
            rawString = rawString.Insert(startIndex, substring);

            return rawString;

        }
    }
}
