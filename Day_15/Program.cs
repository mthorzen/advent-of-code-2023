using System.Text.RegularExpressions;
using Day_15;
using Tools;

bool example = false;
var line = FileReader.ReadLines(example ? "Input_example.txt" : "Input.txt", false)[0];
var sequences = line.Split(",");

int Hash(string str)
{
    int v = 0;
    for (var i = 0; i < str.Length; i++)
    {
        v += str[i];
        v = (v * 17) % 256;
    }
    return v;
}

void Part1()
{
    long sum = 0;
    for (var i = 0; i < sequences.Length; i++)
    {
        sum += Hash(sequences[i]);
    }

    Console.WriteLine("Sum: " + sum);
}

//Part1();

Box[] boxes = new Box[256];
for (var i = 0; i < boxes.Length; i++)
{
    boxes[i] = new Box();
}

for (var i = 0; i < sequences.Length; i++)
{
    var groupCollection = Regex.Matches(sequences[i], "(\\w*)(\\=|\\-)(\\d?)")[0].Groups;
    var label = groupCollection[1].Value;
    var op = groupCollection[2].Value[0] == '=' ? 1 : 0;

    var boxPos = Hash(label);
    boxes[boxPos].LensOperation(label, op, op == 1 ? groupCollection[3].Value : null);
}

// Debugging boxes
// for (var i = 0; i < boxes.Length; i++)
// {
//     boxes[i].Print(i);
// }

long sum = 0;
for (var boxIndex = 0; boxIndex < boxes.Length; boxIndex++)
{
    for (var lensPos = 0; lensPos < boxes[boxIndex].Lenses.Count; lensPos++)
    {
        var focalLength = ((boxIndex + 1) * (lensPos + 1) * boxes[boxIndex].Lenses[lensPos].FocalLength);
        // Console.WriteLine($"{boxIndex}+1 * {lensPos}+1 * {boxes[boxIndex].Lenses[lensPos].FocalLength} = {focalLength}");
        sum += focalLength;
    }
}

Console.WriteLine("Sum: " + sum);
