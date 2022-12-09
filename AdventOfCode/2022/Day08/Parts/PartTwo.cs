using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day08.Helpers;

namespace Day08.Parts;

public static class PartTwo
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART TWO =====");
        
        // Parse the tree grid
        var grid = Parser.GetTreeHeightGridFromInput(lines);

        // For each cell, find if it's visible
        var maxScore = ScenicTreeFinder.GetScenicScores(grid).Max();

        // Get count of visible cells
        Console.WriteLine("Highest scenic score is {0}", maxScore);
    }
}
