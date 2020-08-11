using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FinalExamTask_II
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([=\/])(?<name>[A-Z][A-Za-z]{3,})(\1)";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> destinations = new List<string>();
            int travelPoints = 0;
            foreach (Match item in matches)
            {
                string destination = item.Groups["name"].Value;
                travelPoints += destination.Length;
                destinations.Add(destination);
            }


            Console.WriteLine($"Destinations: {String.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
            
        }
    }
}
