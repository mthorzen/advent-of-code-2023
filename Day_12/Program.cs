using Day_12;
using Tools;

bool example = true;
var lines = FileReader.ReadLines(example ? "Input_example.txt" : "Input.txt");

List<Row> rows = new List<Row>();
foreach (var line in lines)
{
    Row row = new Row(line);
    rows.Add(row);
}

long combos = 0;
foreach (var row in rows)
{
    var calculateCombinations = row.Calculate();
    Console.WriteLine(row + " = " + calculateCombinations);
    combos += calculateCombinations;
}