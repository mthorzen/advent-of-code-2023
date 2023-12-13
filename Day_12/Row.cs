using System.Text;
using System.Text.RegularExpressions;

namespace Day_12;

public class Row
{
    public readonly List<Group> Groups = new List<Group>();
    public readonly int[] Specs;

    public override string ToString()
    {
        var output = new StringBuilder();
        foreach (var group in Groups)
        {
            output.Append($"{group.Type}: {group.Count} ");
        }
        return output.ToString().Trim(' ', ',');
    }

    public Row(string line)
    {
        var strings = line.Split(' ');
        var firstPart = strings[0];
        Specs = strings[1].Trim().Split(",").Select(s => int.Parse(s)).ToArray();
        var matches = Regex.Matches(firstPart, @"((\?)+|(\.)+|(#+))");

        foreach (Match match in matches)
        {
            Groups.Add(new Group(match.Value));
        }
    }

    public enum Type
    {
        Unknown,
        Dot,
        Broken
    };

    public struct Group
    {
        public Type Type;
        public int Count;

        public Group(string val)
        {
            if (val[0] == '?')
            {
                Type = Type.Unknown;
            }
            else if (val[0] == '.')
            {
                Type = Type.Dot;
            }
            else if (val[0] == '#')
            {
                Type = Type.Broken;
            }
            else
            {
                throw new Exception("Unknown group: " + val[0]);
            }

            Count = val.Length;
        }
    };


    public long Calculate()
    {
        // TODO... stopped here
        return 0;
    }
}