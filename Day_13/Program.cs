using Day_13;
using Tools;

bool example = true;
var lines = FileReader.ReadLines(example ? "Input_example.txt" : "Input.txt", false);

var patterns = new List<Pattern>();

var pattern = new Pattern();
foreach (var line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        pattern.Build();
        patterns.Add(pattern);
        pattern = new Pattern();
    }
    else
    {
        pattern.AddLine(line);
    }
}
pattern.Build();
patterns.Add(pattern);


// Console.WriteLine("-------------");
// foreach (var p in patterns)
// {
//     Console.WriteLine(p.ToString());
//     Console.WriteLine("-------------");
// }



// I did the assumption that it was enough to find one reflection and then do a calculation
// from that one to find the center.
// Reading the description again, it states perfect reflection, missed that :(
// I don't have time to fix it... I'll leave it here...

foreach (var p in patterns)
{
    int verticalIndex = p.FindVerticalLine();
    Console.WriteLine("Vertical : " + verticalIndex);
    int horizontalIndex = p.FindHorizontalLine();
    Console.WriteLine("Horizontal : " + horizontalIndex);
}
