using Day_14;
using Tools;

bool example = false;
var lines = FileReader.ReadLines(example ? "Input_example.txt" : "Input.txt", false);

var dict = new Dictionary<char, Landscape>
{
    { '.', Landscape.Empty },
    { 'O', Landscape.RoundedRock },
    { '#', Landscape.CubeRock },
};

Map2D<Landscape> map = new Map2D<Landscape>(lines, dict);
Console.WriteLine(map.ToString());
Console.WriteLine("------------------");

map.MoveDirection(Point2D.North(false), Landscape.RoundedRock, Landscape.Empty, Landscape.CubeRock);

Console.WriteLine(map.ToString());

long sum = 0;
for (var i = 0; i < map.Rows; i++)
{
    for (int j = 0; j < map.Columns; j++)
    {
        if (map.Map[j, i] == Landscape.RoundedRock)
        {
            Console.WriteLine($"Adding {map.Rows - i} for pos {j},{i}");
            sum += (map.Rows - i);
        }
    }
}

Console.WriteLine("Sum: " + sum);


