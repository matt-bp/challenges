using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionDetection.Library
{
    public class Solution
    {
        public int NumberOfCollisions(int[][] positions)
        {
            var numCollisions = 0;

            for(var i  = 0; i < positions.Length; i++)
            {
                for (var j = i + 1; j < positions.Length; j++)
                {
                    if (DidCollide(positions[i], positions[j]))
                    {
                        numCollisions++;
                    }
                }
            }

            return numCollisions;
        }

        public int NumberOfCollisionsDivide(int[][] positions)
        {
            var ordered = positions.OrderBy(x => x[0]).ToList();

            return SubListCheck(ordered).Count;
        }

        public (int Count, int MinX, int MaxX) SubListCheck(List<int[]> positions)
        {
            if (positions.Count == 1)
                return (0, positions[0][0], positions[0][0]);

            // Find middle,
            var middleIndex = positions.Count / 2;
            var lower = positions.Take(middleIndex).ToList();
            var upper = positions.Skip(middleIndex).ToList();

            // Pass lower half to sub
            var resultLower = SubListCheck(lower);

            // Pass upper half to sub
            var resultUpper = SubListCheck(upper);

            var subCount = resultLower.Count + resultUpper.Count;

            // Find the min and max
            var min = resultLower.MinX;
            var max = resultUpper.MaxX;

            // If max of lower and min of upper cross, start doing collision detection
            var currentCount = 0;
            if (resultLower.MaxX + 2 >= resultUpper.MinX)
            {
                for(var i = lower.Count - 1; i >= 0; i--)
                {
                    for(var j = 0; j < upper.Count; j++)
                    {
                        if (lower[i][0] + 2 >= upper[j][0])
                        {
                            if (DidCollide(lower[i], upper[j]))
                            {
                                currentCount++;
                            }
                        }
                        else
                        {
                            // No more possible overlap, so exit!
                            return (currentCount + subCount, min, max);
                        }
                    }
                }
            }

            return (currentCount + subCount, min, max);
        }

        private static bool DidCollide(int[] p1, int[] p2)
        {
            return Math.Abs(p2[0] - p1[0]) <= 2 && Math.Abs(p2[1] - p1[1]) <= 2;
        }
    }
}
