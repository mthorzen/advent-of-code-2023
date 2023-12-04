namespace Day_4;

public class Card
{
    public readonly int LineNumber;
    private readonly string _line;
    private List<int> _winningNumbers = new List<int>();
    private List<int> _numbers = new List<int>();

    public Card(int lineNumber, string line)
    {
        LineNumber = lineNumber;
        _line = line;
        ParseInput(line);
    }

    private void ParseInput(string line)
    {
        var strings = line.Split("|");
        if (strings.Length != 2)
        {
            throw new Exception(LineNumber + "splitted spring is not 2");
        }

        ParseWinningNumbers(strings);
        ParseNumbers(strings[1]);
    }

    private void ParseNumbers(string s)
    {
        var winningNumbers = s.Trim().Split(" ").Where(s => !string.IsNullOrEmpty(s)).ToArray();
        if (winningNumbers.Length != 25)
        {
            throw new Exception(_line + " numbers not 25, was " + winningNumbers.Length);
        }

        foreach (var winningNumber in winningNumbers)
        {
            _numbers.Add(int.Parse(winningNumber.Trim()));
        }
    }

    private void ParseWinningNumbers(string[] strings)
    {
        var firstPartSplit = strings[0].Split(":");
        if (firstPartSplit.Length != 2)
        {
            throw new Exception(LineNumber + "firstPartSplit spring is not 2");
        }

        var winningNumbers = firstPartSplit[1].Trim().Split(" ").Where(s => !string.IsNullOrEmpty(s)).ToArray();
        if (winningNumbers.Length != 10)
        {
            throw new Exception(_line + " winningNumbers not 10, was " + winningNumbers.Length);
        }

        foreach (var winningNumber in winningNumbers)
        {
            _winningNumbers.Add(int.Parse(winningNumber.Trim()));
        }
    }


    public int CalculateSum()
    {
        var sum = 0;
        List<int> won = new List<int>();
        foreach (var winningNumber in _winningNumbers)
        {
            foreach (var number in _numbers)
            {
                if (number == winningNumber)
                {
                    if (won.Contains(number))
                    {
                        throw new Exception(LineNumber + "Already added number");
                    }
                    won.Add(number);

                    if (sum == 0)
                    {
                        sum = 1;
                    }
                    else
                    {
                        sum *= 2;
                    }
                }
            }
        }

        return sum;
    }

    public override string ToString()
    {
        return LineNumber  + ": " + _line
            + "\n > " + _winningNumbers.Select(i => new string(""+i)).Aggregate((i, i1) => i + ", " + i1)
            + "\n > " + _numbers.Select(i => new string(""+i)).Aggregate((i, i1) => i + ", " + i1);
    }

    public int WinningNumbers()
    {
        List<int> won = new List<int>();
        foreach (var winningNumber in _winningNumbers)
        {
            foreach (var number in _numbers)
            {
                if (number == winningNumber)
                {
                    if (won.Contains(number))
                    {
                        throw new Exception(LineNumber + "Already added number");
                    }
                    won.Add(number);

                }
            }
        }

        return won.Count;
    }

    public Card Copy()
    {
        return new Card(LineNumber, _line)
        {
            _winningNumbers =  this._winningNumbers,
            _numbers =  this._numbers,
        };
    }
}