namespace kata_array_diff.lib;

using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        var bList = b.ToList();
        return a.ToList().Where(v => !bList.Any(bv => bv == v)).ToList().ToArray();
    }
}