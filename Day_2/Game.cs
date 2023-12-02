namespace Day_2;

public class Game
{
    private string line;
    public int Id;
    public CubeSet CubeSet = new CubeSet();

    public Game(string line)
    {
        this.line = line;
        var strings = line.Split(":");
        var prefix = strings[0];
        Id = int.Parse(prefix.Substring(prefix.IndexOf(" ", StringComparison.Ordinal)));
        var cubeSetsStr = strings[1];
        //Console.WriteLine(" subeset: " + cubeSetsStr);
        var cubeSets = cubeSetsStr.Split(";");
        foreach (var cubeSet in cubeSets)
        {
            //Console.WriteLine("  >" + cubeSet);
            var split = cubeSet.Trim().Split(",");
            foreach (var cubeSetInstance in split)
            {
                //Console.WriteLine("    >" + cubeSetInstance);
                var splitInstance = cubeSetInstance.Trim().Split(" ");
                CubeSet.Add(int.Parse(splitInstance[0].Trim()), CubeSet.ParseColor(splitInstance[1].Trim()));
            }
        }
        //Console.WriteLine(">>>> " + CubeSet.ToString());
        

        //Game 87: 9 red, 17 blue, 9 green; 4 green, 6 red, 2 blue; 6 red, 5 blue
    }

    public override string ToString()
    {
        return "Game: " + Id + " - CubeSets: " + CubeSet.ToString();
    }

    public bool Complies(List<CubeRule> rules)
    {
        Console.WriteLine("Complies [" + line + "] - " + CubeSet.ToString());
        foreach (var cubeRule in rules)
        {
            if (cubeRule.Judges(this))
            {
                Console.WriteLine(">>>> NO");
                return false;
            }
        }

        Console.WriteLine(">>>>> YES");
        return true;
    }

    public long PowerSum()
    {
        return CubeSet.PowerSum();
    }
}