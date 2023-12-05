using System.Text.RegularExpressions;

const string NUMBER_REGEX = "\\d+";

var lines = File.ReadLines("input.txt");
double total = 0;


Console.WriteLine("Day 4 - Part one");

foreach (var line in lines) 
{
    var cards = line.Substring(line.IndexOf(":")+1);
    var winning = Regex.Matches(cards.Split('|')[0], NUMBER_REGEX).Select(m => int.Parse(m.Value));
    var hand = Regex.Matches(cards.Split('|')[1], NUMBER_REGEX).Select(m => int.Parse(m.Value));

    int winnerCards = winning.Intersect(hand).Count();

    if (winnerCards == 0) continue; 

    total +=  Math.Pow(2, winnerCards-1);

}
Console.WriteLine(total);



Console.WriteLine("Day 4 - Part two");

IDictionary<int, int> scratchcards = new Dictionary<int, int>(); // card, quantity
for (int j = 1; j <= lines.Count(); j++)
    scratchcards.Add(j,1);

int i = 1;
foreach (var line in lines) 
{
    var cards = line.Substring(line.IndexOf(":")+1);
    var winning = Regex.Matches(cards.Split('|')[0], NUMBER_REGEX).Select(m => int.Parse(m.Value));
    var hand = Regex.Matches(cards.Split('|')[1], NUMBER_REGEX).Select(m => int.Parse(m.Value));
    int winnerCards = winning.Intersect(hand).Count();

    for (int j = i+1; j < i+winnerCards+1 && j<= lines.Count(); j++)
        scratchcards[j] += scratchcards[i];
    i++;
}

Console.WriteLine(scratchcards.Values.Sum());