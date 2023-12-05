using Day_5;
using Tools;

Console.WriteLine("---- START");

var lines = FileReader.ReadLines("Input.txt");

var seeds = new List<long>();
foreach (var seed in lines[0].Split(":")[1].Trim().Split(" "))
{
    seeds.Add(long.Parse(seed.Trim()));
}

Console.WriteLine("# of Seeds:" + seeds.Count);

Maps maps = new Maps();
Map currentMap = null;

for (var i = 1; i < lines.Count; i++)
{
    var line = lines[i];
    if (string.IsNullOrEmpty(line)) continue;

    if (line.Contains(':')) // mapping header
    {
        Console.WriteLine("New header:" + line);

        currentMap = new Map(MapUtils.MappingFromString(line.Split(":")[0].Split(" ")[0].Trim()));
        maps.Add(currentMap);
    }
    else
    {
        Console.WriteLine("Adding to map:" + line);
        currentMap.AddToMap(line);
    }
}

long lowestLocation = long.MaxValue;
foreach (var seed in seeds)
{
    //Console.WriteLine("seed: " + seed);
    var lowestForSeed = maps.Traverse(seed);
    lowestLocation = Math.Min(lowestForSeed, lowestLocation);
}

Console.WriteLine("Result: " + lowestLocation);
