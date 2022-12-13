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
                    CyclesUntilExecution = 0
                };
            }
            else
            {                
                yield return new Add
                {
                    CyclesUntilExecution = 1,
                    Value = int.Parse(line.Split(" ")[1])
                };
                
            }
        }
    }
}