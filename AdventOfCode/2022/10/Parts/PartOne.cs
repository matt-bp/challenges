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

        Console.WriteLine("Instructions:");
        foreach(var instruction in instructions )
        {
            Console.WriteLine("\t{0}", instruction);
        }

        var cpu = new Cpu(instructions, 1);

        var numCycles = 0;
        var checkAtCycle = 20;
        var sumAtCheck = 0;

        while (!cpu.DoneWithProgram)
        {
            cpu.NextCycle();
            numCycles++;

            if (numCycles == checkAtCycle)
            {
                checkAtCycle += 40;
                sumAtCheck += numCycles * cpu.XRegister;
            }

            Console.WriteLine("Current Cycle State:");
            Console.WriteLine($"\t{numCycles} cycles");
            Console.WriteLine($"\t{cpu.GetState()}");
        }

        Console.WriteLine("End");
        Console.WriteLine("Number of cycles: {0}", numCycles);
        Console.WriteLine("Value in X Register: {0}", cpu.XRegister);
        Console.WriteLine("Sum: {0}", sumAtCheck);
    }
}
