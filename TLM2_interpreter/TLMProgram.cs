namespace TLM2_interpreter;
internal sealed class TLMProgram(List<TLMFunction> functions)
{
    private Dictionary<char, TLMFunction> funcDict = functions.ToDictionary(f => f.Name);
    private TLMFunction currentFunction = functions[0];
    
    private TLMProgram? parent;
    private TLMProgram? child;
    
    public void Step()
    {
        currentFunction.Step();
        var i = currentFunction.GetInstruction();
        
        // convert to actual instruction
        
        // execute instructions

    }
}
