namespace TLM2_interpreter;
internal sealed class TLMProgram(List<TLMFunction> functions)
{
    private Dictionary<char, TLMFunction> _funcDict = functions.ToDictionary(f => f.Name);
    private TLMFunction _currentFunction = functions[0];
    
    private TLMProgram? _parent;
    private TLMProgram? _child;
    
    public void Step()
    {
        _currentFunction.Step();
        var i = _currentFunction.CurrentInstruction;
        
        // convert to actual instruction
        
        // execute instructions

    }
}