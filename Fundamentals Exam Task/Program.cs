using System;

namespace Fundamentals_Exam_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string input;
            while ((input=Console.ReadLine())!= "Travel")
            {
                var command = input.Split(":");

                switch (command[0])
                {
                    case "Add Stop":
                        var index = int.Parse(command[1]);
                        var stringToInsert = command[2];
                        if (index>=0&&index<stops.Length)
                        {
                            stops = stops.Insert(index, stringToInsert);
                            Console.WriteLine(stops);
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        if (startIndex>=0&&endIndex<stops.Length)
                        {
                            stops = RemovingPartsOfAString(stops, command);
                            Console.WriteLine(stops);
                        }
                        
                        break;
                    case "Switch":
                       
                            stops = ReplacingSubstringMethodInString(stops, command[1], command[2]);
                            Console.WriteLine(stops);
                        
                        break;
                }

            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
        private static string RemovingPartsOfAString(string str, string[] instructions)
        {
            int startIndexToSlice = int.Parse(instructions[1]);
            int endIndexToGet = int.Parse(instructions[2]);
            int countOfSymbolsToRemove = (endIndexToGet - startIndexToSlice) + 1;
            str = str.Remove(startIndexToSlice, countOfSymbolsToRemove);
            return str;
        }
        private static string ReplacingSubstringMethodInString(string str, string oldString, string newString)
        {
            while (str.Contains(oldString))
            {
                str = str.Replace(oldString, newString);
            }

            return str;
        }
    }
}
