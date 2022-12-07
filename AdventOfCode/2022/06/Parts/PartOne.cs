using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Parts;

public static class PartOne
{
    public static void Run(string signal)
    {
        Console.WriteLine("===== PART ONE =====");

        for (int i = 4; i < signal.Length; i++)
        { 
            var previous = signal.Substring(i - 4, 4);

            if (NoDuplicateCharacters(previous))
            {
                Console.WriteLine("Found start-of-packet marker after processing {0} characters.", i);
                break;
            }
        }
    }

    private static bool NoDuplicateCharacters(string input)
    {
        return input.Distinct().Count() == input.Length;
    }
}
