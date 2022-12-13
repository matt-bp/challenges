using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10.Helpers;
using _10.Models;

namespace _10.Parts;

public static class PartTwo
{
    public static void Run(string[] lines)
    {
        Console.WriteLine("===== PART TWO =====");
        
        var instructions = Parser.GetInstructions(lines).ToList();
        
        var cpu = new Cpu(instructions, 1);
        
        var currentCycle = 1; // Start at one, because we're on the "first" cycle.
        var currentCol = 0;

        var renderBuffer = new RenderBuffer(40, 6);
        var cycleLineEnd = renderBuffer.Width;
        var currentRow = 0;

        while (!cpu.DoneWithProgram)
        {
            cpu.RunCycle();

            if (cpu.XRegister - 1 <= currentCol && currentCol <= cpu.XRegister + 1)
            {
                renderBuffer.Pixels[currentRow][currentCol] = true;
            }
            
            currentCycle++;
            currentCol += 1;

            if (currentCycle == cycleLineEnd)
            {
                cycleLineEnd += renderBuffer.Width;
                currentCol = 0;
                currentRow += 1;
            }
            
            // Start
            
            // During
            
            // Draw
            
            // End
        }

        var screen = Renderer.RenderToString(renderBuffer);
        
        Console.WriteLine(screen);
    }
}
