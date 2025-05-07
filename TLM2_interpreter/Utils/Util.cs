namespace TLM2_interpreter.Utils;
internal static class Util
{
    public static string ConcatWithSystemPathSeparator(params string[] strings)
    {
        var slash = Path.DirectorySeparatorChar;
        var ret = "";
        foreach (var str in strings)
            ret += str + slash;
        return ret.Substring(0, ret.Length - 1);
    }
}
