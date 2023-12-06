namespace Day_6;

public class Races : List<Race>
{
    
    public Races(List<string> lines)
    {
        var times = lines[0].Split(":")[1].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);
        var distances = lines[1].Split(":")[1].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);
        
        for (var i = 0; i < times.Length; i++)
        {
            Add(new Race
            {
                Time = int.Parse(times[i].Trim()),
                Distance = int.Parse(distances[i].Trim())
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