namespace Day_2;

public class CubeRule
{
    public CubeColor Color;
    public int Amount;

    public bool Judges(Game game)
    {
        return game.CubeSet.HasMoreThanAmountOfColor(Color, Amount);
    }
}