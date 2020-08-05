using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Some_Useful_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

        }
        private static string ReplacingSubstringMethodInString(string str, string substring, string substitute)
        {
            while (str.Contains(substring))
            {
                str = str.Replace(substring, substitute);
            }

            return str;
        }
        private static string RemovingPartsOfAString(string str, string[] instructions)
        {
            int startIndexToSlice = int.Parse(instructions[1]);
            int endIndexToGet = int.Parse(instructions[2]);
            int countOfSymbolsToRemove = (endIndexToGet - startIndexToSlice)+1;
            str = str.Remove(startIndexToSlice, countOfSymbolsToRemove);
            return str;
        }

        static string MakesPartOfStringToUpperCases(int startIndex, int endIndex, string rawString)
        {
            int length = endIndex - startIndex;
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
        static string FindingOddsByIndexInList(List<string> list)
        {
            List<string> oddsList = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 1)
                {
                    oddsList.Add(list[i]);
                }
            }
            return String.Join(" ", oddsList);
        }
        static string FindingEvensByIndexInList(List<string> list)
        {
            List<string> evenList = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenList.Add(list[i]);
                }
            }
            return String.Join(" ", evenList);
        }
        static void SwapingElementsInListByIndex(string element1, string element2, List<string> list)
        {
            var index = list.IndexOf(element1);
            var newIndex = list.IndexOf(element2);
            var temp = list[index];
            list[index] = list[newIndex];
            list[newIndex] = temp;
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
        private static string ReplacingCharInString(string str, char symbol)
        {
            while (str.Contains(symbol))
            {
               str= str.Replace(symbol, '-');
            }
            return str;
        }
        private static void EncryptStringByASCII(string email)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < email.Length; i++)
            {
                numbers.Add(email[i]);
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }

}
