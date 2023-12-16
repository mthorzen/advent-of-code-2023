using Day_16;
using Tools;

bool example = false;
var lines = FileReader.ReadLines(example ? "Input_example.txt" : "Input.txt");

Map2D<Tile> CreateMap(List<string> lines)
{
    var map2D = new Map2D<TileType>(lines, Tile.CharToType);
    //Console.WriteLine(map2D.ToString(Tile.TypeToChar));
    return new Map2D<Tile>(map2D.Columns, map2D.Rows, (col, row) => new Tile() { TileType = map2D.Map[col, row] });
}

var map = CreateMap(lines);
var beams = new List<Beam>();
beams.Add(new Beam() { Row = 0, Column = 0, Direction = new Point2D() { x = 1, y = 0 }});

long CountEnergized()
{
    long count = 0;
    for (var row = 0; row < map.Map.GetLength(1); row++)
    {
        for (var col = 0; col < map.Map.GetLength(0); col++)
        {
            count += map.Map[col, row].Energized ? 1 : 0;
        }
    }

    return count;
}

int counts = 100;
while (beams.Count > 0)
{
    Console.WriteLine("-------------");
    var newBeams = new List<Beam>();
    bool energized = false;
    foreach (var beam in beams)
    {
        if (beam.Column < 0 || beam.Row < 0 || beam.Column >= map.Columns || beam.Row >= map.Rows) continue;
        //Console.WriteLine("  Beam: " + beam.Column + ", " + beam.Row);
        var currentTile = map.Map[beam.Column, beam.Row];
        newBeams.AddRange(currentTile.HandleBeam(beam, out bool e));
        energized = energized || e;
    }

    if (!energized) counts--;// 7956
    if (counts <= 0) break;
    beams = newBeams;
}


Console.WriteLine("Energized: " + CountEnergized());
