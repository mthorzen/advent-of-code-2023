namespace Day_2;

public class CubeSet
{
    public List<CubeAmount> Handful = new List<CubeAmount>();
    private Dictionary<CubeColor, int> amountPerColor = new Dictionary<CubeColor, int>();
    

    public CubeColor ParseColor(string trim)
    {
        switch (trim)
        {
            case "red":
                return CubeColor.Red;
            case "blue":
                return CubeColor.Blue;
            case "green":
                return CubeColor.Green;
            default:
                return CubeColor.Red;
        }
    }

    public override string ToString()
    {
        string s = "";
        foreach (var keyValuePair in amountPerColor)
        {
            s += keyValuePair.Key + " = " + keyValuePair.Value + "; ";
        }
        return "Handfuls: " + s;
    }

    public bool HasMoreThanAmountOfColor(CubeColor color, int amount)
    {
        if (amountPerColor.TryGetValue(color, out var val))
        {
            if (val > amount)
            {
                return true;
            }
        }

        return false;
    }

    public void Add(int amount, CubeColor parseColor)
    {
        Handful.Add(new CubeAmount()
        {
            Amount = amount,
            Color = parseColor,
        });
        if (amountPerColor.TryGetValue(parseColor, out int val))
        {
            amountPerColor[parseColor] = Math.Max(val, amount);
        }
        else
        {
            amountPerColor[parseColor] = amount;
        }
    }

    public long PowerSum()
    {
        long l = 1;
        
        foreach (var keyValuePair in amountPerColor)
        {
            l *= keyValuePair.Value;
        }
        
        return l;
    }
}