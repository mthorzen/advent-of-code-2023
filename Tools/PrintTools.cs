namespace Tools;

public static class PrintTools
{
    
    public static void PrintBoolArr(bool[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i]) Console.WriteLine((i + 1) + ". " + arr[i]);
        }
    }
    
    public static void PrintGrid2D(int[,] grid)
    {
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            string str = (i + 1) + ". ";
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                str += grid[i, j];
            }
            Console.WriteLine(str);
        }
    }
}