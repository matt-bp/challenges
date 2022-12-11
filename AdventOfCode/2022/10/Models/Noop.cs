namespace _10.Models;

public class Noop : IInstruction
{
    public int CyclesUntilExecution { get; set; }
}