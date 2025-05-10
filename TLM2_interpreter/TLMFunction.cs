namespace TLM2_interpreter;
internal sealed class TLMFunction
{
    public char Name { get; private set; }
    public List<char> Modifiers { get; private set; }

    private string rawSignature;
    private List<string> rawBody;
    
    private Point inst = (-1, 0);
    private Point flow = ( 1, 0);

    public TLMFunction(List<string> sourceCode)
    {
        // signature
        rawSignature = sourceCode[0][1..];
        Name = rawSignature[0];
        Modifiers = [.. rawSignature[2..^1]];

        // body
        rawBody = sourceCode[1..^1];
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
