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

        var size = 30000000;
        var directories = DirectoryFinder.GetDirectoriesWithAtLeastSize(root, size);

        var sumOfSizes = directories.Sum(d => d.GetSize());

        Console.WriteLine("The total sum of directories with at most size {0} is {1}", size, sumOfSizes);
    }
}
