using _11.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Parts;

public static class PartOne
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART ONE =====");

        // TODO: Create monkey list
        var monkeys = Parser.GetMonkeys(lines);

        // Round
        foreach(var round in Enumerable.Range(1, 20))
        {
            // For each monkey
            foreach(var monkey in monkeys)
            {
                for(var i = 0; i < monkey.ItemWorryLevels.Count; i++)
                {
                    monkey.Inspect(i);

                    monkey.ItemWorryLevels[i] = monkey.ItemWorryLevels[i] / 3;

                    monkey.Test(i);
                }
            }
        }
    }
}
