var lines = File.ReadLines("input.txt");

Console.WriteLine("Day 1 - Part one");

var total = lines.Select(line =>
{
    var first = line.SkipWhile(char.IsAsciiLetter).First();
    var last = line.Reverse().SkipWhile(char.IsAsciiLetter).First();
    return int.Parse(new string(new char[] { first, last }));
}).Sum();

Console.WriteLine(total);


Console.WriteLine("Day 1 - Part two");

var numbers = new Dictionary<string, string>
{
    { "one", "o1e" },{ "two", "t2o" },{ "three", "t3e" },
    { "four", "f4r"},{ "five", "f5e"},{ "six", "s6x"},
    { "seven", "s7n"},{ "eight", "e8t"},{ "nine", "n9e"},
};

total = lines.Select(line =>
        numbers.Aggregate(line, (x, number) => x.Replace(number.Key, number.Value)))
    .Select(line =>
    {
        var first = line.SkipWhile(char.IsAsciiLetter).First();
        var last = line.Reverse().SkipWhile(char.IsAsciiLetter).First();
        return int.Parse(new string(new char[] { first, last }));
    }).Sum();

Console.WriteLine(total);