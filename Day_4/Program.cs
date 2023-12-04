using Day_4;
using Tools;

Console.WriteLine("---- Start");

var lines = FileReader.ReadLines("Input.txt");

Cards cards = new Cards();
var sum = 0;
for (var i = 0; i < lines.Count; i++)
{
    var card = new Card(i + 1, lines[i]);
    cards.AddCard(card);
    //Console.WriteLine(card.ToString());
    sum += card.CalculateSum();
}

Console.WriteLine("Result part 1 = " + sum);
Console.WriteLine("Result part 2 = " + cards.CalculateCards());

