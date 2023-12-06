using Day_6;
using Tools;

Console.WriteLine("---- START");

var lines = FileReader.ReadLines("Input.txt");

var races = new Races(lines, false);
Console.WriteLine("---- Part 1: " + races.Part1());

races = new Races(lines, true);
Console.WriteLine("---- Part 2: " + races.Part1());