using _09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _09.Helpers;

public class Simulation
{
    public Vector2 HeadPosition { get; private set; }
    public Vector2 TailPosition { get; private set; }

    public Simulation(Vector2 startingPositon)
    {
        HeadPosition = startingPositon;
        TailPosition = startingPositon;
    }

    public Simulation(Vector2 headPosition, Vector2 tailPosition)
    {
        HeadPosition = headPosition;
        TailPosition = tailPosition;
    }

    public void Apply(Move move)
    {
        for (var i = 0; i < move.Count; i++)
        {
            MoveHead(move.Direction);
            MoveTail();
        }
    }

    public void MoveHead(Vector2 direction)
    {
        HeadPosition += direction;
    }

    public void MoveTail()
    {
        var dirToHead = HeadPosition - TailPosition;

        if (dirToHead.Length() <= 1)
        {
            return;
        }

        if (dirToHead.X == 0 || dirToHead.Y == 0)
        {
            TailPosition += Vector2.Normalize(dirToHead);
            return;
        }

        // If diagonal, don't move
        if (dirToHead.LengthSquared() == 2)
        {
            return;
        }

        var diagDirection = dirToHead switch
        {
            { X: > 0, Y: > 0 } => new Vector2 { X = 1, Y = 1 },
            { X: < 0, Y: > 0 } => new Vector2 { X = -1, Y = 1 },
            { X: > 0, Y: < 0 } => new Vector2 { X = 1, Y = -1 },
            { X: < 0, Y: < 0 } => new Vector2 { X = -1, Y = -1 },
            _ => Vector2.Zero
        };

        TailPosition += diagDirection;
    }
}
