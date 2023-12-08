using Day_8;
using Tools;

Console.WriteLine("---- START");

var lines = FileReader.ReadLines("Input.txt");

var leftRight = lines[0].Trim().ToCharArray();

var map = new Dictionary<string, DesertMap>();
for (var i = 1; i < lines.Count; i++)
{
    var line = lines[i];
    if (!string.IsNullOrEmpty(line))
    {
        var split = line.Split("=");
        map[split[0][..3]] = new DesertMap
        {
            Left = split[1].Substring(2, 3),
            Right = split[1].Substring(7, 3),
        };
    }
}

foreach (var (key, value) in map)
{
    Console.WriteLine(key + " = " + value.Left + " - " + value.Right);
}

var currLoc = "AAA";
var index = 0;
var steps = 0;

while (true)
{
    steps++;
    if (index >= leftRight.Length) index = 0;
    var c = leftRight[index];
    var desertMap = map[currLoc];
    currLoc = c == 'L' ? desertMap.Left : desertMap.Right;
    Console.WriteLine(steps + " i=" + index + " - " + c + " = " + currLoc);
    if (currLoc == "ZZZ") break;
    index++;
} 

Console.WriteLine("Steps: " + steps);
