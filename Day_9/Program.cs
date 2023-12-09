using Tools;

Console.WriteLine("---- START");

var lines = FileReader.ReadLines("Input.txt");

bool CalcDiff(long[] numbers, out long[] output)
{
    var allZero = true;
    output = new long[numbers.Length - 1];
    for (var i = 1; i < numbers.Length; i++)
    {
        var number = numbers[i] - numbers[i - 1];
        //Console.WriteLine("Diff: " + number);
        allZero = allZero && number == 0;
        output[i - 1] = number;
    }

    return allZero;
}

long CalculateSum(string line)
{
    var numbers = StringUtils.SplitStringToNum(line, " ");
    var done = false;
    var numberSeries = new List<long[]>();
    numberSeries.Add(numbers);
    while (!done)
    {
        done = CalcDiff(numbers, out long[] output);
        numberSeries.Add(output);
        numbers = output;
    }

    var previousNumber = 0L;
    for (var i = numberSeries.Count - 2; i >= 0; i--)
    {
        var series = numberSeries[i];
        //Console.WriteLine(series.Select(l => l.ToString()).Aggregate((s1, s2) => s1 + ", " + s2));
        previousNumber = (series[^1] + previousNumber);
    }

    //Console.WriteLine("Previous: " + previousNumber);
    return previousNumber;
}

long sum = 0;
for (var i = 0; i < lines.Count; i++)
{
    var line = lines[i];
    sum += CalculateSum(line);
}

Console.WriteLine("sum: " + sum);