namespace Day_5;

public class Maps : List<Map>
{
    public long Traverse(long seed)
    {
        long l = seed;
        foreach (var map in this)
        {
            var doMap = map.DoMap(l);
            //Console.WriteLine("Going through map: " + map.ToString() + " - " + l + " > " + doMap);
            l = doMap;
        }

        return l;
    }
}