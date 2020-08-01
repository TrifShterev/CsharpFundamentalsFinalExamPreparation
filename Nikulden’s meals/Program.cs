using System;
using System.Collections.Generic;
using System.Linq;

namespace Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
            int countUnlikedMeals = 0;
            string input;
            while ((input=Console.ReadLine())!="Stop")
            {
                var tokens = input.Split("-",StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[1];
                string meal = tokens[2];

                switch (tokens[0])
                {
                    case "Like":
                        if (!guests.ContainsKey(name))
                        {
                            guests.Add(name, new List<string>());
                            guests[name].Add(meal);
                        }
                        else if (!guests[name].Contains(meal))
                        {
                            guests[name].Add(meal);
                        }
                        break;
                    case "Unlike":
                        if (!guests.ContainsKey(name))
                        {
                            Console.WriteLine($"{name} is not at the party.");
                        }
                        else if (!guests[name].Contains(meal))
                        {
                            Console.WriteLine($"{name} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            guests[name].Remove(meal);
                            countUnlikedMeals++;
                            Console.WriteLine($"{name} doesn't like the {meal}.");
                        }
                        break;
                }
            }
            
            guests = guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var item in guests)
            {
                Console.WriteLine($"{item.Key}: {String.Join(", ",item.Value)}");
            }
            Console.WriteLine($"Unliked meals: {countUnlikedMeals}");
        }
    }
}
