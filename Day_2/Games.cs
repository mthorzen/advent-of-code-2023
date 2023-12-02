namespace Day_2;

public class Games
{
    private List<Game> AllGames = new List<Game>();

    public Games(List<string> lines)
    {
        foreach (var line in lines)
        {
            AddGame(line);
        }
    }

    private void AddGame(string line)
    {
        AllGames.Add(new Game(line));
    }

    public List<Game> CalculatePossibleGames(List<CubeRule> rules)
    {
        List<Game> games = new List<Game>();
        //Console.WriteLine("CalculatePossibleGames: " + AllGames.Count());
        foreach (var game in AllGames)
        {
            //Console.WriteLine("Game: " + game.ToString());
            if (game.Complies(rules))
            {
                games.Add(game);
            }
        }

        return games;
    }

    public long CalculateMinimumPower()
    {
        long sum = 0;
        foreach (var game in AllGames)
        {
            sum += game.PowerSum();
        }

        return sum;
    }
}