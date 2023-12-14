namespace Tools;

public struct Point2D
{
    public int x;
    public int y;

    public override string ToString()
    {
        return $"{x}, {y}";
    }

    public static Point2D North(bool downUp = true)
    {
        return new Point2D() { x = 0, y = downUp ? 1 : -1 };
    }
}