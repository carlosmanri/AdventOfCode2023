var lines = File.ReadLines("input.txt");

Console.WriteLine("Day 1 - Part one");

int total = 0;
foreach (var line in lines)
{
    var first = line.SkipWhile(char.IsAsciiLetter).First();
    var last = line.Reverse().SkipWhile(char.IsAsciiLetter).First();
    total += int.Parse(new string(new char[] { first, last }));
}
Console.WriteLine(total);


Console.WriteLine("Day 1 - Part two");

var numbers = new Dictionary<string, string>
{
    { "one", "o1e" },{ "two", "t2o" },{ "three", "t3e" },
    { "four", "f4r"},{ "five", "f5e"},{ "six", "s6x"},
    { "seven", "s7n"},{ "eight", "e8t"},{ "nine", "n9e"},
};

total = 0;
foreach (var line in lines)
{
    string replacedLine = line;

    foreach (var item in numbers)
        replacedLine = replacedLine.Replace(item.Key, item.Value);
    
    var first = replacedLine.SkipWhile(char.IsAsciiLetter).First();
    var last = replacedLine.Reverse().SkipWhile(char.IsAsciiLetter).First();
    total += int.Parse(new string(new char[] { first, last }));
}
Console.WriteLine(total);