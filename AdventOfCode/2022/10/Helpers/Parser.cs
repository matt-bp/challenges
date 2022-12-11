using _10.Models;

namespace _10.Helpers;

public class Parser
{
    public static IEnumerable<IInstruction> GetInstructions(string[] lines)
    {
        foreach(var line in lines)
        {
            if (line.StartsWith("noop"))
            {
                yield return new Noop
                {
                    CyclesUntilExecution = 1
                };
            }
            else
            {                
                yield return new Add
                {
                    CyclesUntilExecution = 2,
                    Value = int.Parse(line.Split(" ")[1])
                };
                
            }
        }
    }
}