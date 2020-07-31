using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes_of_Code_and_Logic_VIIDictionary
{
    class Program
    {
        private static int amountOfHeal;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputONe = Console.ReadLine().Split();
                if (!heroes.ContainsKey(inputONe[0]))
                {
                    string name = inputONe[0];
                    int Hp = int.Parse(inputONe[1]);
                    int Mp = int.Parse(inputONe[2]);
                    heroes.Add(name, new List<int>());
                    heroes[name].Add(Hp);
                    if (heroes[name][0] > 100)
                    {
                        heroes[name][0] = 100;
                    }
                    heroes[name].Add(Mp);
                    if (heroes[name][1] > 200)
                    {
                        heroes[name][1] = 200;
                    }
                }

            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var command = input.Split(" - ",StringSplitOptions.RemoveEmptyEntries);
                string heroName = command[1];

                switch (command[0])
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(command[2]);
                        string spellName = command[3];
                        if (heroes[heroName][1] >= mpNeeded)
                        {
                            heroes[heroName][1] -= mpNeeded;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(command[2]);
                        string attacker = command[3];
                        heroes[heroName][0] -= damage;
                        if (heroes[heroName][0] > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroes.Remove(heroName);
                        }
                        break;
                    case "Recharge":
                        int amountOfCharge = int.Parse(command[2]);
                        
                        if ((heroes[heroName][1] + amountOfCharge) > 200)
                        {
                            int manaToRecharge = 200 - heroes[heroName][1];

                            heroes[heroName][1] = 200;
                            Console.WriteLine($"{heroName} recharged for {manaToRecharge} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} recharged for {amountOfCharge} MP!");
                            heroes[heroName][1] += amountOfCharge;
                        }
                        break;
                    case "Heal":
                        int ammountOfHeal = int.Parse(command[2]);
                       
                        if ((heroes[heroName][0] + ammountOfHeal) > 100)
                        {
                            int lifeToHeal = 100 - heroes[heroName][0];

                            heroes[heroName][0] = 100;
                            Console.WriteLine($"{heroName} healed for {lifeToHeal} HP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} healed for {ammountOfHeal} HP!");
                            heroes[heroName][0] += ammountOfHeal;
                        }
                        break;
                }
            }
            heroes = heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            foreach (var item in heroes)
            { 
                Console.WriteLine(item.Key);
                Console.WriteLine($"  HP: {item.Value[0]}");
                Console.WriteLine($"  MP: {item.Value[1]}");
            }
        }
    }
}
