using Point = System.Drawing.Point;

namespace TLM2_interpreter;
internal sealed class TLMProgram
{
    private TLMProgram parent;
    private TLMProgram child;
    private Point inst;
    private Point flow;
    private List<TLMFunction> functions;

    public TLMProgram(List<TLMFunction> functions)
    {
        this.functions = functions;
    }




}
