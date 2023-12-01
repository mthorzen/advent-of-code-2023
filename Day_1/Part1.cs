namespace Day_1;

public static class Part1
{
    public static int Calculate(List<string> lines)
    {
        int counter = 1;
        int sum = 0;
        foreach (var line in lines)
        {
            var enumerable = line.Where(Char.IsDigit);
            if (enumerable.Any())
            {
                var firstDigit = enumerable.First();
                var lastDigit = enumerable.Last();
                //Console.WriteLine(counter++ + ":" + firstDigit + lastDigit);
                var completeDigit = firstDigit.ToString() + lastDigit.ToString();
                var value = int.Parse(completeDigit);
                sum += value;
            }
    

        }

        return sum;
    }
}