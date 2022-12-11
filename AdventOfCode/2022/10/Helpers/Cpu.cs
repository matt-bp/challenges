using _10.Models;

namespace _10.Helpers;

public class Cpu
{
    public int XRegister { get; private set; }
    public int CurrentInstruction { get; private set; }
    private List<IInstruction> _instructions;
    public bool DoneWithProgram { get; private set; }

    public Cpu(List<IInstruction> instructions)
    {
        _instructions = instructions;
    }

    public void NextCycle()
    {
        if (CurrentInstruction > _instructions.Count)
        {
            DoneWithProgram = true;
        }

        if (_instructions[CurrentInstruction].CyclesUntilExecution != 0)
        {
            _instructions[CurrentInstruction].CyclesUntilExecution -= 1;
            return;
        }
        
        if (_instructions[CurrentInstruction] is Add add)
        {
            XRegister += add.Value;
            return;
        }
    }
}