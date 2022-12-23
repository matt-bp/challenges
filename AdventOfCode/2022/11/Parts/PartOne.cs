using _11.Helpers;
using _11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Parts;

public static class PartOne
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART ONE =====");

        // TODO: Create monkey list
        var parser = new Parser();
        var monkeys = parser.GetMonkeys(lines);

        Console.WriteLine("Starting Items:");
        foreach (var monkey in monkeys)
        {
            Console.WriteLine($"Monkey: {string.Join(",", monkey.ItemWorryLevels)}");
        }
        Console.WriteLine("");

        // Round
        foreach (var round in Enumerable.Range(1, 20))
        {
            // For each monkey
            foreach(var monkey in monkeys)
            {
                for(var i = 0; i < monkey.ItemWorryLevels.Count; i++)
                {
                    monkey.Inspect(i);

                    monkey.ItemWorryLevels[i] = monkey.ItemWorryLevels[i] / 3;

                    var targetMonkey = monkey.GetMonkeyToThrowTo(monkey.ItemWorryLevels[i]);

                    monkeys.ElementAt(targetMonkey).ItemWorryLevels.Add(monkey.ItemWorryLevels[i]);
                }

                monkey.ItemWorryLevels = new List<int>();
            }

            Console.WriteLine($"Round {round} with items:");
            foreach (var monkey in monkeys)
            {
                Console.WriteLine($"Monkey: {string.Join(",", monkey.ItemWorryLevels)}");
            }
            Console.WriteLine("");
        }

        var monkeyBusiness = monkeys.Select(m => m.NumTimesInspected).OrderByDescending(m => m);
        Console.WriteLine($"Monkey: {string.Join(",", monkeyBusiness)}");
        Console.WriteLine($"Monkey business: {monkeyBusiness.Take(2).Aggregate((a,x)=>a * x)}");
        Console.WriteLine("");
    }
}
