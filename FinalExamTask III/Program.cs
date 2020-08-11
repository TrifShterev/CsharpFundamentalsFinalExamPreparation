using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinalExamTask_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                var inputInfo = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

                var plant = inputInfo[0];
                var rarity = double.Parse(inputInfo[1]);

                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new List<double>());
                    plants[plant].Add(rarity);
                    plants[plant].Add(0);
                }
                else
                {
                    plants[plant][0] = rarity;
                }
            }
            string input;
            while ((input=Console.ReadLine())!= "Exhibition")
            {
                var command = input.Split(": ",StringSplitOptions.RemoveEmptyEntries);
                var subCommand = command[1].Split(" - ");
                var plantName = subCommand[0];
                switch (command[0])
                {
                    case "Rate":
                        if (!plants.ContainsKey(plantName))
                        { 
                            Console.WriteLine("error");
                        }
                        else
                        {
                            double rating = double.Parse(subCommand[1]);
                            plants[plantName].Add( rating);
                        }
                        break;
                    case "Update":
                        if (plants.ContainsKey(plantName))
                        { double newRating = double.Parse(subCommand[1]);
                            plants[plantName][0] = newRating;

                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        if (plants.ContainsKey(plantName))
                        {
                            plants[plantName][1] = 0;
                        }
                        break;
                }
            }plants = plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1] / 2).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Console.WriteLine("Plants for the exhibition:");

             foreach (var item in plants)
            {
                if (item.Value.Count>2)
                {
                    var average = item.Value.Sum() - item.Value[0];
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {(average/2):F2}");
                }
                else
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {(item.Value[1]):F2}");
                }
                
            }
        }
    }
}
