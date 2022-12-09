using _09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _09.Helpers
{
    public static class Parser
    {
        public static IEnumerable<Move> GetMoves(IEnumerable<string> input)
        {
            foreach (var move in input)
            {
                var parts = move.Split(' ');

                yield return new Move
                {
                    Direction = GetDirection(parts[0]),
                    Count = int.Parse(parts[1])
                };
            }
        }

        public static Vector2 GetDirection(string dir) => dir switch
        {
            "R" => Vector2.UnitX,
            "L" => -Vector2.UnitX,
            "U" => Vector2.UnitY,
            "D" => -Vector2.UnitY,
            _ => throw new ArgumentException("{0} is not a recognized direction", dir)
        };
    }
}
