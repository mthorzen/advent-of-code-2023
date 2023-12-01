using System.Reflection.Metadata;

namespace Day_1;

public class Part2
{
    public static readonly Dictionary<string, int> Ones = new Dictionary<string, int>
    {
        {
            "zero",0
        },{
            "one",1
        },{
            "two",2
        },{
            "three",3
        },{
            "four",4
        },
        {
            "five",5
        },{
            "six",6
        },{
            "seven",7
        },{
            "eight",8
        },{
            "nine",9
        }
    };

    

    public static int Calculate(List<string> lines)
    {
        int counter = 1;
        int sum = 0;
        foreach (var line in lines)
        {
            var firstDigit = FindValue(line).ToString();
            var lastDigit = FindValueLast(line).ToString();
            var completeDigit = firstDigit + lastDigit;
            var value = int.Parse(completeDigit);
            Console.WriteLine(counter++ + ". "+ line + " = " + firstDigit + "+" + lastDigit + " : " + completeDigit);
            sum += value;
        }

        return sum;
    }

    private static int FindValue(string line)
    {
        var firstDigitIndex = line.IndexOfAny("0123456789".ToCharArray());
        
        var letterIndex = 10000;
        var lastLetterValue = 0;
        foreach (var one in Ones)
        {
            var indexOf = line.IndexOf(one.Key);
            if (indexOf >= 0 && indexOf < letterIndex)
            {
                letterIndex = indexOf;
                lastLetterValue = one.Value;
            }
        }

        var firstValue = 0;
        if (letterIndex < firstDigitIndex)
        {
            firstValue = lastLetterValue;
        }
        else
        {
            firstValue = int.Parse(line.ToCharArray()[firstDigitIndex].ToString());
        }
        
        Console.WriteLine("Digit=" + firstDigitIndex + " Letter=" + letterIndex);

        return firstValue;
    }
    
    private static int FindValueLast(string line)
    {
        var firstDigitIndex = line.LastIndexOfAny("0123456789".ToCharArray());
        var letterIndex = -1;
        var lastLetterValue = 0;
        foreach (var one in Ones)
        {
            var indexOf = line.LastIndexOf(one.Key);
            if (indexOf >= 0 && indexOf > letterIndex)
            {
                letterIndex = indexOf;
                lastLetterValue = one.Value;
            }
        }

        var firstValue = 0;
        if (letterIndex > firstDigitIndex)
        {
            firstValue = lastLetterValue;
        }
        else
        {
            firstValue = int.Parse(line.ToCharArray()[firstDigitIndex].ToString());
        }

        return firstValue;
    }
}