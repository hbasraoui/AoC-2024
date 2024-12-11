// Problem statement: https://adventofcode.com/2024/day/3

using System.Text.RegularExpressions;

const string inputFilePath = "input.txt";

var corruptedMemory = File.ReadAllText(inputFilePath);
Console.WriteLine($"Sum of the results: {EValuateMulInstructionsWithConditionals(corruptedMemory)}");

return;

// To solve part 2
int EValuateMulInstructionsWithConditionals(string input)
{
    var tokens = Regex.Split(input, @"(do\(\)|don't\(\))");
    // At the beginning of the program, mul instructions are enabled.
    var sum = EvaluateMulInstructions(tokens[0]);
    
    for (var i = 1; i < tokens.Length; i++)
    {
        if (tokens[i] == "don't()")
        {
            i++;
            continue;
        }
        sum += EvaluateMulInstructions(tokens[i]);
    }
    
    return sum;
}

// To solve part 1
int EvaluateMulInstructions(string input)
{
    var regexp = new Regex(@"mul\((\d+),(\d+)\)");
    var matches = regexp.Matches(input);
    var sum = 0;
    
    foreach (var match in matches)
    {
        var groups = regexp.Match(match.ToString());
        sum += int.Parse(groups.Groups[1].Value) * int.Parse(groups.Groups[2].Value); 
    }
    
    return sum;
}
