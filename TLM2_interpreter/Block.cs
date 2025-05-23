namespace TLM2_interpreter;
internal sealed class Block
{
    private char[][] _data;

    public char this[Point p]
    {
        get => this[p.X, p.Y];
        set => this[p.X, p.Y] = value;
    }
    public char this[int i, int j]
    {
        get => _data[i][j];
        set => _data[i][j] = value;
    }

    public char[] this[int i, Range r] => _data[i][r];
    public char[][] this[Range r] => _data[r];

    public Block(Point size) : this(size.X, size.Y) { }
    public Block(int w, int h)
    {
        _data = new char[h][];
        for (var i = 0; i < h; i++)
            _data[i] = new char[w];
    }
    public Block(char[][] data)
    {
        _data = data;
    }
    public Block(List<string> data) : this(data[0].Length, data.Count)
    {
        for(var i = 0; i < data.Count; i++)
            for (var j = 0; j < data[i].Length; j++)
                this[i, j] = data[i][j];
    }
}