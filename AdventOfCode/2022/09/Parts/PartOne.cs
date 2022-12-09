using _09.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _09.Parts;

public static class PartOne
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART ONE =====");

        var moves = Parser.GetMoves(lines);
        var sim = new Simulation(Vector2.Zero);
        var locationsTailHasBeen = new List<Vector2>();

        foreach(var move in moves)
        {
            // Apply move to H
            for(var i = 0; i < move.Count; i++)
            {
                sim.Apply(move.Direction);
                locationsTailHasBeen.Add(sim.TailPosition);
            }
        }

        var numLocations = locationsTailHasBeen.Distinct().Count();

        Console.WriteLine("The number of places tails has been is {0}", numLocations);
    }
}
