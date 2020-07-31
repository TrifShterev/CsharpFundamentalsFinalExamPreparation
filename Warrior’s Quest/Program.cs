using System;
using System.Linq;

namespace Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "For Azeroth")
            {
                string[] command = input.Split();

                bool isCorrectCommand = command[0] == "GladiatorStance" || command[0] == "DefensiveStance" || command[0] == "Dispel" || (command[0] == "Target" && command[1] == "Change") || (command[0] == "Target" && command[1] == "Remove");
                if (!isCorrectCommand)
                {
                    Console.WriteLine("Command doesn't exist!");
                    continue;
                }
                if (command[0] == "GladiatorStance")
                {
                    skill = skill.ToUpper().ToString();
                    Console.WriteLine(skill);
                }
                else if (command[0] == "DefensiveStance")
                {
                    skill = skill.ToLower().ToString();
                    Console.WriteLine(skill);
                }
                else if (command[0] == "Dispel")
                {
                    int indexOfDispel = int.Parse(command[1]);
                    var letterToReplaceWith = command[2].ToCharArray();
                    if (indexOfDispel >= 0 && indexOfDispel <= skill.Length-1)
                    {
                        skill = skill.Replace(skill.ElementAt(indexOfDispel), letterToReplaceWith[0]);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }

                }
                else if (command[0] == "Target" && command[1] == "Change")
                {
                    string substringToReplace = command[2];
                    string newSubstring = command[3];
                    skill = ReplacingSubstringMethodInString(skill, substringToReplace, newSubstring);
                    Console.WriteLine(skill);
                }
                else if (command[0] == "Target" && command[1] == "Remove")
                {
                    string substringToRemove = command[2];
                    skill = RemovingSubstringfromAString(skill, substringToRemove);
                    Console.WriteLine(skill);
                }
               
            }
        }
        private static string ReplacingSubstringMethodInString(string str, string substring, string substitute)
        {
            while (str.Contains(substring))
            {
                str = str.Replace(substring, substitute);
            }

            return str;
        }
        private static string RemovingSubstringfromAString(string skill, string substringToRemove)
        {
            while (skill.Contains(substringToRemove))
            {
                int startIndex = skill.IndexOf(substringToRemove);
                skill = skill.Remove(startIndex, substringToRemove.Length);
            }

            return skill;
        }
    }
}
