namespace TLM2_interpreter;
internal sealed class TLMFunction
{
    public char Name { get; private set; }
    public List<char> Modifiers { get; private set; }

    private string rawSignature;
    private List<string> rawBody;

    public TLMFunction(List<string> sourceCode)
    {
        // signature
        rawSignature = sourceCode[0][1..];
        Name = rawSignature[0];
        Modifiers = [.. rawSignature[2..^1]];

        // body
        rawBody = sourceCode[1..^1];
    }
}
