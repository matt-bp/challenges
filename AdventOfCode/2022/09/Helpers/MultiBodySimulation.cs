using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _09.Helpers;

public class MultiBodySimulation
{
    public List<Vector2> Body { get; private set; }

    public MultiBodySimulation(Vector2 startingPositon, int bodyLength)
    {
        Body = new List<Vector2>();
        for (var i = 0; i < bodyLength + 1; i++)
        {
            Body.Add(new Vector2 { X = startingPositon.X, Y = startingPositon.Y });
        }
    }

    public void Apply(Vector2 direction)
    {
        MoveHead(direction);

        for(var i = 1; i < Body.Count; i++)
        {
            MoveTail(i);
        }
    }

    private void MoveHead(Vector2 direction)
    {
        Body[0] += direction;
    }

    private void MoveTail(int index)
    {
        var dirToHead = Body[index - 1] - Body[index];

        if (dirToHead.Length() <= 1)
        {
            return;
        }

        if (dirToHead.X == 0 || dirToHead.Y == 0)
        {
            Body[index] += Vector2.Normalize(dirToHead);
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

        Body[index] += diagDirection;
    }
}

