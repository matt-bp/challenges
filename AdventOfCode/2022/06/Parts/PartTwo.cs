using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Parts;

public static class PartTwo
{
    public static void Run(string signal)
    {
        Console.WriteLine("===== PART TWO =====");

        const int requiredDistinctCharacters = 14;
        for (int i = requiredDistinctCharacters; i < signal.Length; i++)
        {
            var previous = signal.Substring(i - requiredDistinctCharacters, requiredDistinctCharacters);

            if (NoDuplicateCharacters(previous))
            {
                Console.WriteLine("Found start-of-message marker after processing {0} characters.", i);
                break;
            }
        }
    }

    private static bool NoDuplicateCharacters(string input)
    {
        return input.Distinct().Count() == input.Length;
    }
}
