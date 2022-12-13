namespace _10.Models;

public class Add : IInstruction
{
    public int CyclesUntilExecution { get; set; }
    public int Value { get; set; }
    public override string ToString()
    {
        return string.Format("Cycles: {0}, Value: {1}", CyclesUntilExecution, Value);
    }
}