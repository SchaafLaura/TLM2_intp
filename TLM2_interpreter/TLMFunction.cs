namespace TLM2_interpreter;
internal sealed class TLMFunction
{
    public char Name { get; private set; }
    public List<char> Modifiers { get; private set; }    
    private string _rawSignature;
    private Block _body;
    
    private Point inst = (-1, 0);
    private Point flow = ( 1, 0);

    public TLMFunction(List<string> sourceCode)
    {
        // signature
        _rawSignature = sourceCode[0][1..];
        Name = _rawSignature[0];
        Modifiers = [.. _rawSignature[2..^1]];

        // body
        _body = new Block(sourceCode[1..^1]);
    }
    public char GetInstruction()
    {
        return rawBody[inst.X][inst.Y];
    }
    public void Step()
    {
        inst += flow;
    }
}
