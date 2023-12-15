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

long sum = 0;
for (var i = 0; i < sequences.Length; i++)
{
    sum += Hash(sequences[i]);
}

Console.WriteLine("Sum: " + sum);