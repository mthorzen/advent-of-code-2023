using Day_6;
using Tools;

Console.WriteLine("---- START");

var lines = FileReader.ReadLines("Input.txt");

var races = new Races(lines);

Console.WriteLine("---- Part 1: " + races.Part1());