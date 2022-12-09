using _09.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Parts;

public static class PartOne
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART ONE =====");

        var moves = Parser.GetMoves(lines);

        foreach(var move in moves)
        {
            // Apply move to H

            // With given state, where should T move?

            // Record where T has moved
        }
    }
}
