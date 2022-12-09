using _09.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _09.Parts;

public static class PartTwo
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART TWO =====");

        var moves = Parser.GetMoves(lines);
        var sim = new MultiBodySimulation(Vector2.Zero, 9);
        var locationsTailHasBeen = new List<Vector2>();

        foreach (var move in moves)
        {
            // Apply move to H
            for (var i = 0; i < move.Count; i++)
            {
                sim.Apply(move.Direction);
                locationsTailHasBeen.Add(sim.Body.Last());
            }
        }

        var numLocations = locationsTailHasBeen.Distinct().Count();

        Console.WriteLine("The number of places last tail has been is {0}", numLocations);
    }
}
