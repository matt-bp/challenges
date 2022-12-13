using _10.Models;

namespace _10.Helpers;

public class Cpu
{
    public int XRegister { get; private set; }
    public int CurrentInstruction { get; private set; }
    private List<IInstruction> _instructions;
    public bool DoneWithProgram { get; private set; }

    public Cpu(List<IInstruction> instructions, int initialXRegisterValue)
    {
        _instructions = instructions;
        XRegister= initialXRegisterValue;
    }

    public void RunCycle()
    {
        if (_instructions[CurrentInstruction].CyclesUntilExecution != 0)
        {
            _instructions[CurrentInstruction].CyclesUntilExecution -= 1;
            return;
        }
        
        if (_instructions[CurrentInstruction] is Add add)
        {
            Console.Write(add.Value < 0 ? add.Value.ToString() : $"+{add.Value.ToString()}");
            XRegister += add.Value;
        }

        CurrentInstruction++;

        if (CurrentInstruction >= _instructions.Count)
        {
            DoneWithProgram = true;
            return;
        }
    }

    public string GetState()
    {
        return DoneWithProgram ? "Done" : $"CI: {_instructions[CurrentInstruction]}, X: {XRegister}";
    }
}