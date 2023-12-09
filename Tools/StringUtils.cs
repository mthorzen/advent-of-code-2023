namespace Tools;

public static class StringUtils
{

    public static IEnumerable<string> SplitString(string str, string separator)
    {
        return str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    }
    
    public static long[] SplitStringToNum(string str, string separator)
    {
        return SplitString(str, separator).Select(long.Parse).ToArray();
    }
    
}