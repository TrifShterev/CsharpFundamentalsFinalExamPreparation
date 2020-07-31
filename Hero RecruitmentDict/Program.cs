using System;
using System.Collections.Generic;
using System.Linq;

namespace Hero_RecruitmentDict
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();
            string input;
            while ((input=Console.ReadLine())!="End")
            {
                var command = input.Split();
                string hero = command[1];

                switch (command[0])
                {
                    case "Enroll":
                        if (!heroes.ContainsKey(hero))
                        {
                            heroes.Add(hero, new List<string>());
                        }
                        else
                        {
                            Console.WriteLine($"{hero} is already enrolled.");
                        }
                        break;
                    case "Learn":
                        string spellToLearn = command[2];
                        if (!heroes.ContainsKey(hero))
                        {
                            Console.WriteLine($"{hero} doesn't exist.");

                        }
                        else if (heroes[hero].Contains(spellToLearn))
                        {
                            Console.WriteLine($"{hero} has already learnt {spellToLearn}.");
                        }
                        else
                        {
                            heroes[hero].Add(spellToLearn);
                        }
                        break;
                    case "Unlearn":
                        string spellToRemove = command[2];
                        if (!heroes.ContainsKey(hero))
                        {
                            Console.WriteLine($"{hero} doesn't exist.");

                        }
                        else if (!heroes[hero].Contains(spellToRemove))
                        {
                            Console.WriteLine($"{hero} doesn't know {spellToRemove}.");
                        }
                        else
                        {
                            heroes[hero].Remove(spellToRemove);
                        }
                        break;
                }

            }
            heroes = heroes.OrderByDescending(kvp => kvp.Value.Count).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            foreach (var item in heroes)
            {
                Console.WriteLine("Heroes: ");
                Console.WriteLine($"=={item.Key}: {string.Join(", ",item.Value)}");
            }
        }
    }
}
