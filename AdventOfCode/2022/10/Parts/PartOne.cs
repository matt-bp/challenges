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
        
        var cpu = new Cpu(instructions, 1);

        var currentCycle = 1; // Start at one, because we're on the "first" cycle.
        var checkAtCycle = 20;
        var sumAtCheck = 0;

        while (!cpu.DoneWithProgram)
        {
            cpu.RunCycle();
            
            currentCycle++;
            
            if (currentCycle == checkAtCycle)
            {
                checkAtCycle += 40;
                sumAtCheck += currentCycle * cpu.XRegister;
                // Console.Write($" ({currentCycle})\n");
            }
        }

        Console.WriteLine("End");
        Console.WriteLine("Number of cycles: {0}", currentCycle);
        Console.WriteLine("Value in X Register: {0}", cpu.XRegister);
        Console.WriteLine("Sum: {0}", sumAtCheck);
    }
}
