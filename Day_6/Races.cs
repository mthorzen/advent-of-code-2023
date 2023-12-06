namespace Day_6;

public class Races : List<Race>
{
    
    public Races(List<string> lines, bool part2)
    {
        var times= Array.Empty<string>();
        var distances = Array.Empty<string>();
        if (part2)
        {
            var time = lines[0].Split(":")[1].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries).Aggregate((s, s1) => s+s1);
            var distance = lines[1].Split(":")[1].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries).Aggregate((s, s1) => s+s1);
            times = new[] { time };
            distances = new[] { distance };
        }
        else
        {
            times = lines[0].Split(":")[1].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);
            distances = lines[1].Split(":")[1].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);
        }
        
        
        for (var i = 0; i < times.Length; i++)
        {
            Add(new Race
            {
                Time = long.Parse(times[i].Trim()),
                Distance = long.Parse(distances[i].Trim())
            });
        }
    }

    public long Part1()
    {
        long sum = 1;
        for (int i = 0; i < Count; i++)
        {
            sum *= Part1Calc(this[i]);
        }
        return sum;
    }

    private long Part1Calc(Race race)
    {
        long sum = 0;

        long lowerLimit = LowerLimit(race);
        long upperLimit = UpperLimit(race);
        
        sum = upperLimit - lowerLimit + 1;
        Console.WriteLine("Calc: " + lowerLimit + " - " + upperLimit + " = " + sum);
        return sum;
    }

    private static long LowerLimit(Race race)
    {
        long lowerLimit = 0;
        var startPoint = race.Time / 2;
        while (true)
        {
            var distance = startPoint * (race.Time - startPoint);

            if (distance > race.Distance)
            {
                lowerLimit = startPoint;
                startPoint--;
            }
            else
            {
                if (lowerLimit == (startPoint + 1))
                {
                    break;
                }

                startPoint++;
            }
        }

        return lowerLimit;
    }
    
    private static long UpperLimit(Race race)
    {
        long upperLimit = 0;
        var startPoint = race.Time / 2;
        while (true)
        {
            var distance = startPoint * (race.Time - startPoint);

            if (distance > race.Distance)
            {
                upperLimit = startPoint;
                startPoint++;
            }
            else
            {
                if (upperLimit == (startPoint - 1))
                {
                    break;
                }

                startPoint--;
            }
        }

        return upperLimit;
    }
}