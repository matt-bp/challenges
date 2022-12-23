using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Models
{
    internal class Monkey
    {
        public List<int> ItemWorryLevels { get; set; }
        public Func<int, int> Operation { get; set; }
        public Func<int, int> GetMonkeyToThrowTo { get; set; }
        public int NumTimesInspected { get; private set; }

        public void Inspect(int currentItem)
        {
            NumTimesInspected++;

            var newWorryLevel = Operation(ItemWorryLevels[currentItem]);

            ItemWorryLevels[currentItem] = newWorryLevel;
        }

        public int Test(int currentItem)
        {
            return GetMonkeyToThrowTo(currentItem);
        }
    }
}
