using Day_2;
using Tools;

Console.WriteLine("---- Start");

var lines = FileReader.ReadLines("Input.txt");
var games = new Games(lines);

var rule1 = new CubeRule() { Color = CubeColor.Red, Amount = 12 };
var rule2 = new CubeRule() { Color = CubeColor.Green, Amount = 13 };
var rule3 = new CubeRule() { Color = CubeColor.Blue, Amount = 14 };
var rules = new List<CubeRule>() {rule1, rule2, rule3};

List<Game> possibleGames = games.CalculatePossibleGames(rules);

Console.WriteLine($"Part 1 Sum: {possibleGames.Sum(game => game.Id)}");

Console.WriteLine($"Part 2 sum: {games.CalculateMinimumPower()}");



