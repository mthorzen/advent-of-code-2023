namespace Day_5;

public class MapInstance
{
    private readonly long _sourceStart;
    private readonly long _destinationStart;
    private readonly long _range;

    public MapInstance(long source, long dest, long r)
    {
        _sourceStart = source;
        _destinationStart = dest;
        _range = r;
    }

    public long? DoMap(long val)
    {
        if (val < _sourceStart) return null;
        if (val > (_sourceStart + _range)) return null;
        return (_destinationStart + _range) - (_sourceStart + _range - val);
    }
}

public class Map
{
    private Mapping _mapping;
    private List<MapInstance> _mapInstances = new List<MapInstance>();

    public Map(Mapping mapping)
    {
        _mapping = mapping;
    }

    public void AddToMap(string line)
    {
        // destination source range
        var strings = line.Split(" ");
        var destinationStart = long.Parse(strings[0].Trim());
        var sourceStart = long.Parse(strings[1].Trim());
        var range = long.Parse(strings[2].Trim());
        _mapInstances.Add(new MapInstance(sourceStart, destinationStart, range));
    }

    public long DoMap(long l)
    {
        long min = long.MaxValue;
        foreach (var mapInstance in _mapInstances)
        {
            long? mapped = mapInstance.DoMap(l);
            if (mapped.HasValue)
            {
                min = Math.Min(min, mapped.Value);
            }
        }

        if (min < long.MaxValue)
        {
            return min;
        }

        return l;
    }

    public override string ToString()
    {
        return _mapping.ToString();
    }
}
