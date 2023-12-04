namespace Day_4;

public class Cards
{
    private readonly List<Card> _cards = new List<Card>();

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }
    
    public int CalculateCards()
    {

        Dictionary<int, int> dict = new Dictionary<int, int>(); 

        foreach (var card in _cards)
        {
            dict[card.LineNumber] = 1;
        }
        
        foreach (var keyValuePair in dict)
        {
            var card = _cards[keyValuePair.Key - 1];
            int wins = card.WinningNumbers();
            var nrOfCards = keyValuePair.Value;
            for (int j = 0; j < wins; j++)
            {
                dict[card.LineNumber + 1 + j] += nrOfCards;
            }
        }

        var sum = 0;
        foreach (var keyValuePair in dict)
        {
            Console.WriteLine(keyValuePair.Key + " = " + keyValuePair.Value);
            sum += keyValuePair.Value;
        }

        return sum;
    }
}