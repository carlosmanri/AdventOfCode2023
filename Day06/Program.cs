using Day06;
using System.Text.RegularExpressions;

var lines = File.ReadLines("input.txt");

var times = Regex.Matches(lines.First(), "\\d+").Select(m => int.Parse(m.Value));
var distances = Regex.Matches(lines.ElementAt(1), "\\d+").Select(m => int.Parse(m.Value));

var races = times.Zip(distances, (t, d) => new Race { MaxTime = t, RecordDistance = d });

var result = races.Select(r =>
    {
        var sqrt = Math.Sqrt(Math.Pow(r.MaxTime, 2) - 4 * r.RecordDistance);
        var x1 = (r.MaxTime + sqrt) / 2;
        var x2 = (r.MaxTime - sqrt) / 2;

        return (int)x1 - (int)x2;

    }).Aggregate((x, y) => x * y);

Console.WriteLine("Part one solution: " + result);




var time = double.Parse(Regex.Match(lines.First().Replace(" ", ""), "\\d+").Value);
var distance = double.Parse(Regex.Match(lines.ElementAt(1).Replace(" ", ""), "\\d+").Value);

var sqrt = Math.Sqrt(Math.Pow(time, 2) - 4 * distance);
var x1 = (time + sqrt) / 2;
var x2 = (time - sqrt) / 2;
result =  (int)x1 - (int)x2;

Console.WriteLine("Part two solution: " + result);
