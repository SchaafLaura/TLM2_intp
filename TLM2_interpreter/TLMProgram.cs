using LanguageExt;

namespace TLM2_interpreter;
internal sealed class TLMProgram(List<TLMFunction> functions)
{
    private Dictionary<char, TLMFunction> _funcDict = functions.ToDictionary(f => f.Name);
    private TLMFunction _currentFunction = functions[0];
    
    private TLMProgram? _parent;
    private TLMProgram? _child;
    
    // initial instruction-set is hardcoded
    // during program execution, new things can get bound or old things overridden
    private readonly Dictionary<char, Either<Action<TLMProgram>, TLMProgram>> _instructionSet = new()
    {
        {'A', (Action<TLMProgram>) CoolMethod},
        {'B', (Action<TLMProgram>) AnotherCoolMethod},
        {'C', (Action<TLMProgram>) AnotherOne},
    };
    
    public void Step()
    {
        // get next instruction
        _currentFunction.Step();
        var i = _currentFunction.CurrentInstruction;
        
        // convert to actual instruction
        var instr = GetInstruction(i);

        // execute instructions
        instr.Match(
            some => some.Match(
                a => a(this),
                p => p.DoSomething()),
            ()   => { /* do nothing */ });
    }

    private Option<Either<Action<TLMProgram>, TLMProgram>> GetInstruction(char c)
    {
        return _instructionSet[c] switch
        {
            null        => Option<Either<Action<TLMProgram>, TLMProgram>>.None,
            var instr   => instr
        };
    }
    
    public void DoSomething()
    {
        
    }
    
    private static void CoolMethod(TLMProgram p)
    {
        
    }

    private static void AnotherCoolMethod(TLMProgram p)
    {
        
    }

    private static void AnotherOne(TLMProgram p)
    {
        
    }
}