namespace TLM2_interpreter;
internal sealed class TLMFunction
{
    public char Name { get; private set; }
    public List<char> Modifiers { get; private set; }    
    private string _rawSignature;
    private Block _body;
    
    private Point _ptr = (-1, 0);
    private Point _flw = ( 1, 0);

    public TLMFunction(List<string> sourceCode)
    {
        // signature
        _rawSignature = sourceCode[0][1..];
        Name = _rawSignature[0];
        Modifiers = [.. _rawSignature[2..^1]];

        // body
        _body = new Block(sourceCode[1..^1]);
    }

    public TLMFunction(Block sourceCode)
    {
        // signature
        _rawSignature = new string(sourceCode[0, 1..]);
        Name = _rawSignature[0];
        Modifiers = [.. _rawSignature[2..^1]]; // TODO: just check from '[' to ']' instead of to the end of the string
        
        // body
        _body = new Block(sourceCode[1..^1]);
    }
    
    public char CurrentInstruction => _body[_ptr];
    public void Step()
    {
        _ptr += _flw;
    }
}
