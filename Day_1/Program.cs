
using Day_1;
using Tools;

Console.WriteLine("------ Start");

var lines = FileReader.ReadLines("Input.txt");


Console.WriteLine("Sum Part 1 = " + Part1.Calculate(lines));
Console.WriteLine("Sum Part 2 = " + Part2.Calculate(lines));

Console.WriteLine("------ End");

