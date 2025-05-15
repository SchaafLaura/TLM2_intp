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
        var instr = _currentFunction.CurrentInstruction;
        
        // convert to actual instruction
        /*
         kind of has to be here, because other Programs might have
         different instruction sets
         
         dict:
         char -> instruction
         
         BUT
         
         instruction might be some predefined function 
         OR
         instruction might be output of another program? (or however self-modification will work)
         
         maybe languageExt for either/or thingies?
         but what if its three things? four? probably not tho.
         
         
         */
        
        // execute instructions
        
    }
}