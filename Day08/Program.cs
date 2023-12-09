using Day08;
using System.Text.RegularExpressions;

var lines = File.ReadLines("input.txt").ToList();

var instructions = lines.First();

lines.RemoveRange(0, 2);

Dictionary<string, Network> graph = [];

lines.ForEach(line => {
    var match = Regex.Matches(line, "[A-Z]{3}");
    graph.Add(match[0].Value, new Network { Left = match[1].Value, Right = match[2].Value });
});


string currentNode = "AAA";
int steps = 0;
foreach (var instruction in instructions.IterateInfinitely())
{
    if (currentNode.Equals("ZZZ"))
        break;

    currentNode = instruction.Equals('L') ? graph[currentNode].Left : graph[currentNode].Right;
    steps++;
}
Console.WriteLine("Part one solution: " + steps);



public static class IEnumerableHelper
{
    public static IEnumerable<T> IterateInfinitely<T>(this IEnumerable<T> sequence)
    {
        while (true)
            foreach (var item in sequence)
                yield return item;
    }
}