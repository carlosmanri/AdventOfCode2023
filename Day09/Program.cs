using System.Net;
using System.Text.RegularExpressions;

var lines = File.ReadLines("input.txt").ToList();

List<List<int>> reports = [];

lines.ForEach(line => {
    List<int> report = [];

    foreach (Match m in Regex.Matches(line, "-?\\d+"))
        report.Add(int.Parse(m.Value));

    reports.Add(report);

});

int solution1 = reports.AsParallel().Select(report =>
{
    List<List<int>> steps = [];
    steps.Add(report);

    while (!steps.Last().All(value => value == 0)) {
        var firstSlice = steps.Last().GetRange(1, steps.Last().Count() - 1);
        var secondSlice = steps.Last().GetRange(0, steps.Last().Count() - 1);
        steps.Add(firstSlice.Zip(secondSlice, (a, b) => a - b).ToList());
    }

    steps.Last().Add(0);

    for (int i = steps.Count() - 1; i > 0; i--)
        steps.ElementAt(i - 1).Add(steps.ElementAt(i-1).Last() + steps.ElementAt(i).Last());

    return steps.First().Last();

}).Sum();

Console.WriteLine("Part one solution: " + solution1);
