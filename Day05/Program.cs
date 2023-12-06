using Day05;
using System.Collections.Generic;
using System.Text.RegularExpressions;

const string NUMBER_REGEX = "\\d+";

var lines = File.ReadLines("input.txt").ToList();

var partOneSeeds = Regex.Matches(lines.First(), NUMBER_REGEX).Select(m => double.Parse(m.Value));
var partTwoSeeds = new List<double>();

for (int i = 0; i < partOneSeeds.Count(); i+=2)
    partTwoSeeds.AddRange(Range(partOneSeeds.ElementAt(i), partOneSeeds.ElementAt(i+1)));


lines.RemoveRange(0, 2);
lines.RemoveAll(l => l.Equals(""));
lines.Reverse();

var stack = new Stack<string>(lines);

List<List<Map>> maps = new();

while (stack.Count > 0)
{
    var line = stack.Pop();

    if (line.EndsWith("map:"))
        maps.Add([]);

    else
    {
        var numbers = Regex.Matches(line, NUMBER_REGEX).Select(m => double.Parse(m.Value)).ToArray();
        maps.Last().Add(new Map { Start = numbers[1], End = numbers[1] + numbers[2] - 1, Step = numbers[1] - numbers[0] });
    }
}

var solution1 = partOneSeeds.AsParallel()
    .WithDegreeOfParallelism(16)
    .Select(s =>
        maps.Aggregate(s, (x, stepMaps) =>
            {
                var m = stepMaps.Find(m => m.Start <= x && x <= m.End);
                return m == null ? x : x - m.Step;
            })).Min();

var solution2 = partTwoSeeds.AsParallel()
    .WithDegreeOfParallelism(16)
    .Select(s =>
        maps.Aggregate(s, (x, stepMaps) =>
        {
            var m = stepMaps.Find(m => m.Start <= x && x <= m.End);
            return m == null ? x : x - m.Step;
        })).Min();

Console.WriteLine("Part one solution: " + solution1);
Console.WriteLine("Part two solution: " + solution2);



static IEnumerable<double> Range(double start, double count)
{
    var max = start + count - 1;
    if (count < 0 || max > double.MaxValue)
        throw new ArgumentOutOfRangeException();

    for (double i = start; i <= max; i++)
        yield return i;
} 