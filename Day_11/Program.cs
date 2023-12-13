using Tools;

bool example = true;
var lines = FileReader.ReadLines(example ? "Input_example.txt" : "Input.txt");

bool[] emptyRows = new bool[lines.Count];
bool[] emptyCols = new bool[lines.Count];
for (var i = 0; i < lines.Count; i++)
{
    emptyCols[i] = true;
    emptyRows[i] = true;
}
int[,] fullGrid = new int[lines.Count, example ? 10 : 140];
Dictionary<int, Point2D> planets = new Dictionary<int, Point2D>();

void ReadInput(ref bool[] rows, ref bool[] cols, ref int[,] grid)
{
    int count = 1;
    for (var i = 0; i < lines.Count; i++)
    {
        var line = lines[i];
        for (var j = 0; j < line.Length; j++)
        {
            if (line[j] == '#')
            {
                rows[i] = false;
                cols[j] = false;
                planets[count] = new Point2D()
                {
                    x = i,
                    y = j,
                };
                grid[i, j] = count++;
            }
            else
            {
                grid[i, j] = 0;
            }
        }
    }
}



ReadInput(ref emptyRows, ref emptyCols, ref fullGrid);

PrintTools.PrintBoolArr(emptyRows);
PrintTools.PrintBoolArr(emptyCols);
PrintTools.PrintGrid2D(fullGrid);

foreach (var (key, value) in planets)
{
    Console.WriteLine(key + " = "  + value.x + ", " + value.y);
}

var combos = NumberTools.Combos(planets.Keys.ToArray());
foreach (var point2D in combos)
{
    Console.WriteLine("Combo: " + point2D.x + " - " + point2D.y);
}


// Stopped here...
