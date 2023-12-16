using System.Text;

namespace Tools;

public class Map2D<T>
{
    private readonly T[,] map;
    private readonly int columns;
    private readonly int rows;
    
    public T[,] Map { get { return map;  } }
    public int Columns { get { return columns;  } }
    public int Rows { get { return rows;  } }

    public delegate T CreateType(int col, int row);
    public Map2D(int columns, int rows, CreateType createType)
    {
        this.columns = columns;
        this.rows = rows;
        map = new T[columns, rows];
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < columns; col++)
            {
                map[col, row] = createType(col, row);
            }
        }
        
    }
    
    public Map2D(List<string> lines, Dictionary<char, T> dict)
    {
        rows = lines.Count;
        var cols = -1;
        for (var row = 0; row < rows; row++)
        {
            if (cols < 0)
            {
                cols = lines[row].Length;
                map = new T[cols, rows];
            }
            
            for (var col = 0; col < cols; col++)
            {
                var key = lines[row][col];
                map[col, row] = dict[key];
            }
        }
        columns = cols;
    }

    private bool MoveDirectionSingle(Point2D spot, Point2D dir, T emptyArea, T movable)
    {
        var moved = false;
        var newSpot = new Point2D() { x = spot.x + dir.x, y = spot.y + dir.y };
        if (newSpot.x >= 0 && newSpot.x < columns && newSpot.y >= 0 && newSpot.y < rows)
        {
            if (map[spot.x, spot.y].Equals(movable) && map[newSpot.x, newSpot.y].Equals(emptyArea))
            {
                Console.WriteLine($"Moving {spot.x},{spot.y} to {newSpot.x},{newSpot.y}");
                map[newSpot.x, newSpot.y] = movable;
                map[spot.x, spot.y] = emptyArea;
                moved = true;
            }
        }

        return moved;
    }

    private bool MoveDirectionOnce(Point2D dir, T movable, T emptyAreas, T obstacle)
    {
        bool moved = false;
        for (var row = 0; row < map.GetLength(1); row++)
        {
            for (int col = 0; col < map.GetLength(0); col++)
            {
                var newPoint = new Point2D() { x = col, y = row };
                var movedSingle = MoveDirectionSingle(newPoint, dir, emptyAreas, movable);
                moved = moved || movedSingle;
            }
        }

        return moved;
    }

    public void MoveDirection(Point2D dir, T movable, T emptyAreas, T obstacle)
    {
        if (dir.x == 0 && dir.y == 0) return;
        if (movable == null || emptyAreas == null) return;
        if (dir.x != 0 && dir.y != 0) throw new Exception("Not support diagonal");

        bool moved = true;
        do
        {
            moved = MoveDirectionOnce(dir, movable, emptyAreas, obstacle);
        } while (moved);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        for (var row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                char c = '.';

                var foo = map[col, row];
                var f = foo.ToString()[0];
                if (f.Equals('R')) c = '0';
                if (f.Equals('E')) c = '.';
                if (f.Equals('C')) c = '#';
                builder.Append(c + "");
            }
            builder.Append(Environment.NewLine);
        }
        return builder.ToString();
    }
    
    public string ToString(Dictionary<T, char> dict)
    {
        var builder = new StringBuilder();
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < columns; col++)
            {
                var foo = map[col, row];
                builder.Append(dict[foo]);
            }
            builder.Append(Environment.NewLine);
        }
        return builder.ToString();
    }
}