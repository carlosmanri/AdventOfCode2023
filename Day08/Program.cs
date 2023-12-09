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



lines = File.ReadLines("input.txt").ToList();

instructions = lines.First();

lines.RemoveRange(0, 2);

graph = [];

lines.ForEach(line => {
    var match = Regex.Matches(line, "[A-Z0-9]{3}");
    graph.Add(match[0].Value, new Network { Left = match[1].Value, Right = match[2].Value });
});

var currentNodes = graph.Keys.Where(k => k.EndsWith('A')).ToList();

var allSteps = currentNodes.Select(node => {
    long step = 0;
    while (true)
    {
        if (node.EndsWith('Z')) break;

        node = instructions[(int)step % instructions.Length].Equals('L') ? graph[node].Left : graph[node].Right;
        step++;
    }
    return step;
});

Console.WriteLine("Part two solution: " + LCM(allSteps.ToArray()));




static long LCM(long[] numbers)
{
    return numbers.Aggregate(lcm);
}
static long lcm(long a, long b)
{
    return Math.Abs(a * b) / GCD(a, b);
}
static long GCD(long a, long b)
{
    return b == 0 ? a : GCD(b, a % b);
}


public static class IEnumerableHelper
{
    public static IEnumerable<T> IterateInfinitely<T>(this IEnumerable<T> sequence)
    {
        while (true)
            foreach (var item in sequence)
                yield return item;
    }
}

