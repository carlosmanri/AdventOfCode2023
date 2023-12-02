using System.Text.RegularExpressions;

const int MAX_RED = 12;
const int MAX_GREEN = 13;
const int MAX_BLUE = 14;

Console.WriteLine("Day 2 - Part one");


var lines = File.ReadLines("input.txt");
int total = 0;

foreach (var line in lines) {

    int reds = GetMax(line, "red");
    int blues = GetMax(line, "blue");
    int greens = GetMax(line, "green");

    if (reds <= MAX_RED && blues <= MAX_BLUE && greens <= MAX_GREEN) 
        total += int.Parse(Regex.Match(line, @"\d+").ToString());
    
}

Console.WriteLine(total);


int GetMax(string game, string color) { 
    return Regex.Matches(game, @"\d+ "+color)
        .Select(s => Regex.Match(s.ToString(), @"\d+").ToString())
        .Select(int.Parse)
        .Max();
}