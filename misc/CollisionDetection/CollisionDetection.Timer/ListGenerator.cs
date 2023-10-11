using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionDetection.Timer
{
    internal class ListGenerator
    {
        private Random random = new();

        public int[][] Generate(int size, int min, int max)
        {
            Debug.Assert(min <= max);

            var list = new List<int[]>();

            for(var i = 0; i < size; i++)
            {
                var x = random.Next(min, max);
                var y = random.Next(min, max);
                list.Add(new int[] { x, y });
            }

            return list.ToArray();
        }
    }
}
