using Day03;
using System.Text.RegularExpressions;

const string SYMBOL_REGEX = "[^.0-9]";
const string NUMBER_REGEX = "\\d+";

List<Symbol> symbols = [];
List<Number> numbers = [];
List<Number> partNumbers = [];

var lines = File.ReadLines("input.txt");


Console.WriteLine("Day 3 - Part one");

for (int i = 0; i < lines.Count(); i++)
{
    foreach (Match match in Regex.Matches(lines.ElementAt(i), SYMBOL_REGEX))
        symbols.Add(new Symbol { Row = i, Column = match.Index });

    foreach (Match match in Regex.Matches(lines.ElementAt(i), NUMBER_REGEX))
        numbers.Add(new Number { Value = int.Parse(match.Value), Row = i, StartIndex = match.Index, EndIndex = match.Index + match.Value.Count()-1 });
}

symbols.ForEach(s =>
{
    var adjacent = numbers.Where(n => s.Row == n.Row && (s.Column - 1 == n.EndIndex || s.Column + 1 == n.StartIndex))
        .Concat(numbers.Where(n => s.Row + 1 == n.Row && (n.StartIndex - 1) <= s.Column && s.Column <= (n.EndIndex + 1)))
        .Concat(numbers.Where(n => s.Row - 1 == n.Row && (n.StartIndex - 1) <= s.Column && s.Column <= (n.EndIndex + 1)));

    partNumbers.AddRange(adjacent);

    numbers = numbers.Except(adjacent).ToList();
});



Console.WriteLine(partNumbers.Select(n => n.Value).Sum());
