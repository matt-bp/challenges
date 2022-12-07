using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.Models;
using _07.Helpers;

namespace _07.Parts;

public static class PartOne
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART ONE =====");

        var parser = new Parser();

        var root = parser.GetFileSystemStructure(lines);

        var size = 100000;
        var directories = DirectoryFinder.GetDirectoriesWithAtMostSize(root, size);

        var sumOfSizes = directories.Sum(d => d.GetSize());

        Console.WriteLine("The total sum of directories with at most size {0} is {1}", size, sumOfSizes);
    }
}

