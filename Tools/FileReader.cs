namespace Tools;

public static class FileReader
{

    public static List<string> ReadLines(string filename, bool excludeEmpty = true)
    {
        var list = new List<string>();
        var lines = File.ReadAllLines(filename);
        Console.WriteLine("lines: " + lines.Length);

        for (var i = 0; i < lines.Length; i += 1) {
            var line = lines[i];
            if (!excludeEmpty || !string.IsNullOrEmpty(line))
            {
                list.Add(line.Trim());
            }
        }

        return list;
    }
        
    
}