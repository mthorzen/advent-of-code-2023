namespace Tools;

public static class NumberTools
{
    
    public static List<Point2D> Combos(int[] values, bool oneWay = true)
    {
        List<Point2D> pairs = new List<Point2D>();

        for (var x = 0; x < values.Length - 1; x++)
        {
            for (var y = x + 1; y < values.Length; y++)
            {
                int firstValue = values[x];
                int secondValue = values[y];
                if (firstValue > secondValue)
                {
                    (firstValue, secondValue) = (secondValue, firstValue);
                }
                
                pairs.Add(new Point2D()
                {
                    x = firstValue, y = secondValue,
                });
                if (!oneWay)
                {
                    pairs.Add(new Point2D()
                    {
                        x = secondValue, y = firstValue,
                    });
                }
            }
        }
        return pairs;
    }
    public static void Variations(List<int> list)
    {
        double count = Math.Pow(2, list.Count);
        for (int i = 1; i <= count - 1; i++)
        {
            string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == '1')
                {
                    Console.Write(list[j]);
                }
            }
            Console.WriteLine();
        }
    }
}