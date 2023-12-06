using Day05;
using System.Text.RegularExpressions;

const string NUMBER_REGEX = "\\d+";

Console.WriteLine("Day 5 - Part one");

var lines = File.ReadLines("input.txt").ToList();

var seeds = Regex.Matches(lines.First(), NUMBER_REGEX).Select(m => double.Parse(m.Value));

lines.RemoveRange(0, 2);
lines.RemoveAll(l => l.Equals(""));
lines.Reverse();

var stack = new Stack<string>(lines);

List<List<Map>> maps = new();

while (stack.Count > 0) { 
    var line = stack.Pop();

    if (line.EndsWith("map:"))
        maps.Add([]);
    
    else
    {
        var numbers = Regex.Matches(line, NUMBER_REGEX).Select(m => double.Parse(m.Value)).ToArray();
        maps.Last().Add(new Map { Start = numbers[1], End = numbers[1] + numbers[2] - 1, Step = numbers[1] - numbers[0] });
    }
}

var locations = seeds.AsParallel()
    .WithDegreeOfParallelism(16)
    .Select(s =>
        maps.Aggregate(s, (x, stepMaps) => 
            {
                var m = stepMaps.Find(m => m.Start <= x && x <= m.End);
                return m == null ? x : x-m.Step;
            }));

Console.WriteLine(locations.Min());



