using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kata_array_diff.lib
{
    public class Others
    {
        public static int[] SolutionArrayDiff(int[] a, int[] b)
        {
            // With a hashset, we won't have to iterate over b for every item in a.
            // Instead, we can check if an item exists in constant time
            HashSet<int> bSet = new HashSet<int>(b);

            return a.Where(v => !bSet.Contains(v)).ToArray();
        }

        public static int[] ArrayContainsArrayDiff(int[] a, int[] b)
        {
            return a.Where(n => !b.Contains(n)).ToArray();
        }

        public static int[] FindAllArrayDiff(int[] a, int[] b)
        {
            var sb = new HashSet<int>(b);
            return Array.FindAll(a, x => !sb.Contains(x));
        }
    }
}
