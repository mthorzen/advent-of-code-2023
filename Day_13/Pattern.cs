using System.Text;
using Tools;

namespace Day_13;

public class Pattern
{
    private List<string> lines = new List<string>();

    private bool[,] map;
    
    public void AddLine(string line)
    {
        lines.Add(line);
    }

    public void Build()
    {
        map = new bool[lines.Count, lines[0].Length];
        for (var i = 0; i < lines.Count; i++)
        {
            for (var j = 0; j < lines[i].Length; j++)
            {
                map[i, j] = lines[i][j] == '#';
            }
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        
        for (var i = 0; i < map.GetLength(0); i++)
        {
            for (var j = 0; j < map.GetLength(1); j++)
            {
                sb.Append(map[i, j] ? '#' : '.');
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public int FindVerticalLine()
    {
        var columns = map.GetLength(1);
        var rows = map.GetLength(0);

        var reflectionColumns = FindReflection(columns, rows);
        
        Console.WriteLine("Reflection vertical: " + reflectionColumns);
        return 1 + reflectionColumns.x + (reflectionColumns.y - reflectionColumns.x) / 2;
    }
    
    public int FindHorizontalLine()
    {
        var columns = map.GetLength(0);
        var rows = map.GetLength(1);

        var reflectionColumns = FindReflection(columns, rows, true);
        
        Console.WriteLine("Reflection horizontal: " + reflectionColumns);
        return 1 + reflectionColumns.x + (reflectionColumns.y - reflectionColumns.x) / 2;
    }

    private bool GetMapPoint(int x, int y, bool horizontal)
    {
        if (horizontal)
        {
            return map[y, x];
        }
        else
        {
            return map[x, y];
        }
    }

    private Point2D FindReflection(int columns, int rows, bool horizontal = false)
    {
        Point2D reflection = new Point2D();

        // we go through all columns from left to right
        for (var x = 0; x < columns; x++)
        {
            Console.WriteLine("Outer column: " + x + " / " + columns);
            reflection.x = x; // this is the possible reflection on the left side
            
            // map of possible matches with current x column
            var possibleMatches = new bool[columns];
            for (var i = 0; i < columns; i++)
            {
                possibleMatches[i] = i > x;
            }
            
            for (var y = rows - 1; y >= 0; y--)
            {
                var yToXMap = GetMapPoint(y, x, horizontal); // map[y, x];
                Console.WriteLine("Going through row: " + y + "/" + rows + " = " + yToXMap);
                // loop through columns to the right
                for (var x2 = x + 1; x2 < columns; x2++)
                {
                    // check whether x2 columns is equal to x column
                    var yToX2Map = GetMapPoint(y, x2, horizontal); // map[y, x2];
                    possibleMatches[x2] = possibleMatches[x2] && yToX2Map == yToXMap;
                    Console.Write("   " + y + "," + x2 + ":" + (yToX2Map ? "1" : "0") + " = " +(possibleMatches[x2] ? "1":"0"));
                }

                Console.WriteLine();
            }
            
            for (var i = possibleMatches.Length - 1; i >= 0; i--)
            {
                if (possibleMatches[i])
                {
                    reflection.y = i;
                    return reflection;
                }
            }
        }

        throw new Exception("No reflection found");
    }
}