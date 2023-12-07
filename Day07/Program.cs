using Day07;

List<Play> plays = File.ReadLines("input.txt")
    .Select(line => new Play { Hand = line.Split(" ")[0], Bid = int.Parse(line.Split(" ")[1]) })
    .ToList();

plays.Sort();

int i = 1;
int result = 0;

foreach (Play p in plays)
    result += p.Bid * i++;


Console.Write("Part one solution: " + result);







