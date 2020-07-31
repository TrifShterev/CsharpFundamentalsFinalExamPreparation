using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BossRushREGEX
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {                
                Match boss = Regex.Match
                    (Console.ReadLine(),@"[|](?<name>[A-Z]{3,})[|]:[#](?<title>[A-Za-z]+ [A-Za-z]+)[#]");
                if (!boss.Success)
                {
                    Console.WriteLine("Access denied!");
                    continue;
                }                           
                    Console.WriteLine($"{boss.Groups["name"]}, The {boss.Groups["title"]}");
                    Console.WriteLine($">> Strength: {boss.Groups["name"].Length}");
                    Console.WriteLine($">> Armour: {boss.Groups["title"].Length}");
                
            }
        }
    }
}
