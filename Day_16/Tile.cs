using Tools;

namespace Day_16;

public enum TileType
{
    // Looking at it from left to right
    Empty, // .
    SplitterVer, // |
    SplitterHor, // -
    MirrorUp, // /
    MirrorDown // \
}



public class Tile
{
    public static readonly Dictionary<char, TileType> CharToType = new()
    {
        {'.', TileType.Empty},
        {'-', TileType.SplitterHor},
        {'|', TileType.SplitterVer},
        {'/', TileType.MirrorUp},
        {'\\', TileType.MirrorDown}
    };
    
    public static readonly Dictionary<TileType, char> TypeToChar = new()
    {
        {TileType.Empty,'.'}, 
        {TileType.SplitterHor, '-'},
        {TileType.SplitterVer, '|'},
        {TileType.MirrorUp, '/'},
        { TileType.MirrorDown, '\\'}
    };
    
    public TileType TileType;
    public bool Energized;
    public int PassedThrough;

    public List<Beam> HandleBeam(Beam beam, out bool switchedEnergized)
    {
        var newBeams = new List<Beam>();
        PassedThrough++;
        switchedEnergized = !Energized;
        Energized = true;
        
        if (TileType == TileType.Empty)
        {
            var continueBeam = new Beam() { Row = beam.Row + beam.Direction.y, Column = beam.Column + beam.Direction.x, Direction = beam.Direction };
            newBeams.Add(continueBeam);
        }
        else if (TileType == TileType.MirrorUp)
        {
            var beamMirrorUp = HandleMirrorUp(beam);
            newBeams.Add(beamMirrorUp);
        }
        else if (TileType == TileType.MirrorDown)
        {
            newBeams.Add(HandleMirrorDown(beam));
        }
        else if (TileType == TileType.SplitterHor)
        {
            if (beam.Direction.y == 0)
            {
                var continueBeam = new Beam() { Row = beam.Row + beam.Direction.y, Column = beam.Column + beam.Direction.x, Direction = beam.Direction };
                newBeams.Add(continueBeam);
            }
            else
            {
                // dir: x=0, y=1   ==> b1: r=r, c=c-1, b2: r=r, c=c+1
                // dir: x=0, y=-1 ==> b1: r=r, c=c-1, b2: r=r, c=c+1
                var leftBeam = new Beam() { Row = beam.Row, Column = beam.Column - 1, Direction = new Point2D() { x = -1, y = 0 } };
                var rightBeam = new Beam() { Row = beam.Row, Column = beam.Column + 1, Direction = new Point2D() { x = 1, y = 0 } };
                newBeams.Add(leftBeam);
                newBeams.Add(rightBeam);
            }
        }
        else if (TileType == TileType.SplitterVer)
        {
            if (beam.Direction.x == 0)
            {
                var continueBeam = new Beam() { Row = beam.Row + beam.Direction.y, Column = beam.Column + beam.Direction.x, Direction = beam.Direction };
                newBeams.Add(continueBeam);
            }
            else
            {
                var upBeam = new Beam() { Row = beam.Row - 1, Column = beam.Column, Direction = new Point2D() { x = 0, y = -1 } };
                var downBeam = new Beam() { Row = beam.Row + 1, Column = beam.Column, Direction = new Point2D() { x = 0, y = 1 } };
                newBeams.Add(upBeam);
                newBeams.Add(downBeam);
            }
        }

        return newBeams;
    }

    private Beam HandleMirrorDown(Beam beam) // \
    {
        var newDirection = new Point2D() { x = beam.Direction.y, y = beam.Direction.x };
        return new Beam() { Row = beam.Row + newDirection.y, Column = beam.Column + newDirection.x, Direction = newDirection };
    }

    private Beam HandleMirrorUp(Beam beam) // /
    {
        // current tile: x=2,y=4
        // 1, 0 ==> new direction : x=0, y=-1 ... beam: x=2, y=3
        // -1, 0 ==> new direction : x=0, y=1 ... beam: x=2, y=5
        // 0, 1 ==> new direction : x=-1, y=0 ... beam: x=1, y=4
        // 0, -1 ==> new direction : x=1, y=0 ... beam: x=3, y=4
        var newDirection = new Point2D() { x = -beam.Direction.y, y = -beam.Direction.x };
        return new Beam() { Row = beam.Row + newDirection.y, Column = beam.Column + newDirection.x, Direction = newDirection };
    }
}