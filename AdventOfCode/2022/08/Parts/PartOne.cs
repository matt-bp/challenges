using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day08.Helpers;

namespace Day08.Parts;

public static class PartOne
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART ONE =====");
        
        // Parse the tree grid
        var grid = Parser.GetTreeHeightGridFromInput(lines);

        // For each cell, find if it's visible
        var count = TreeHouseLocationFinder.CountOfVisibleTrees(grid);

        // Get count of visible cells
        Console.WriteLine("The number of visible trees are {0}", count);
    }
}
