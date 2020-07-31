using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> cities = new Dictionary<string, List<double>>();

            string infoAboutTargets;
            while ((infoAboutTargets=Console.ReadLine())!="Sail")
            {
                var targets = infoAboutTargets.Split("||");
                string city = targets[0];
                double population = double.Parse(targets[1]);
                double gold = double.Parse(targets[2]);
                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new List<double>());
                    cities[city].Add(population);
                    cities[city].Add(gold);
                }
                else
                {
                    cities[city][0] += population;
                    cities[city][1] += gold;
                }

            }
            string events;
            while ((events=Console.ReadLine())!="End")
            {
                var command = events.Split("=>");
                string city = command[1];

                switch (command[0])
                {
                    case "Plunder":
                        double peopleKilled = double.Parse(command[2]);
                        double goldStolen = double.Parse(command[3]);
                        cities[city][0] -= peopleKilled;
                        cities[city][1] -= goldStolen;
                        Console.WriteLine($"{city} plundered! {goldStolen} gold stolen, {peopleKilled} citizens killed.");

                        if (cities[city][0]<=0|| cities[city][1] <= 0)
                        {
                            Console.WriteLine($"{city} has been wiped off the map!");
                            cities.Remove(city);
                        }
                        break;
                    case "Prosper":
                        double goldGained = double.Parse(command[2]);
                        if (goldGained<=0)
                        {
                            Console.WriteLine($"Gold added cannot be a negative number!");
                            continue;
                        }
                        cities[city][1] += goldGained;
                        Console.WriteLine($"{goldGained} gold added to the city treasury. {city} now has {cities[city][1]} gold.");
                        break;
                }
            }
            if (cities.Count==0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                return;
            }
            cities = cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            foreach (var city in cities)
            {                
                Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
            }

        }
    }
}
