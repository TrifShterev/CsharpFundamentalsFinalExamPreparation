using System;
using System.Collections.Generic;
using System.Linq;
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
        private static string RemovingPartsOfAString(string activationKey, string[] instructions)
        {
            int startIndexToSlice = int.Parse(instructions[1]);
            int endIndexToGet = int.Parse(instructions[2]);
            int countOfSymbolsToRemove = endIndexToGet - startIndexToSlice;
            activationKey = activationKey.Remove(startIndexToSlice, countOfSymbolsToRemove);
            return activationKey;
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
    }

}
