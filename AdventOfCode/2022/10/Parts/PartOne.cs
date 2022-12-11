using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10.Helpers;

namespace _10.Parts;

public static class PartOne
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART ONE =====");

        var instructions = Parser.GetInstructions(lines).ToList();

        var cpu = new Cpu(instructions);

        while (!cpu.DoneWithProgram)
        {
            cpu.NextCycle();
        }

        Console.WriteLine("Yup!");
    }
}
