using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.Models;
using _07.Helpers;

namespace _07.Parts;

public static class PartTwo
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART TWO =====");

        var parser = new Parser();

        var root = parser.GetFileSystemStructure(lines);

        var directories = DirectoryFinder.GetAllDirectories(root);
        var totalAvailableSpace = 70_000_000;
        var requiredUnusedSpace = 30_000_000;

        var biggestToSmallest = directories.OrderByDescending(d => d.GetSize());

        var biggest = biggestToSmallest.First();

        var requiredDeletedForUpdate = requiredUnusedSpace - (totalAvailableSpace - biggest.GetSize());

        var directoryToDelete = biggestToSmallest.Skip(1)
            .Where(d => d.GetSize() >= requiredDeletedForUpdate)
            .OrderBy(d => d.GetSize())
            .First();

        Console.WriteLine("The directory to delete has a size of {0}", directoryToDelete.GetSize());
    }
}
