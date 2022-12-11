namespace _10.Models;

public class Add : IInstruction
{
    public int CyclesUntilExecution { get; set; }
    public int Value { get; set; }
}