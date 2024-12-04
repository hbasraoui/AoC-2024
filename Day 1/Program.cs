// Problem statement: https://adventofcode.com/2024/day/1
const string inputFilePath = "input.txt";

Console.WriteLine($"Distance: {ComputeDistance()}");
Console.WriteLine($"Similarity: {ComputeSimilarity()}");

// For part 2
int ComputeSimilarity()
{
    var left = new List<int>();
    var occurrences = new Dictionary<int, int>();
    
    foreach (var line in File.ReadLines(inputFilePath))
    {
        var split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        left.Add(int.Parse(split[0]));
        if (occurrences.ContainsKey(int.Parse(split[1])))
        {
            occurrences[int.Parse(split[1])]++;
        }
        else
        {
            occurrences[int.Parse(split[1])] = 1;
        }
    }

    return left.Sum(l => l * occurrences.GetValueOrDefault(l, 0));
}

// For part 1
int ComputeDistance()
{
    var left = new List<int>();
    var right = new List<int>();
    
    foreach (var line in File.ReadLines(inputFilePath))
    {
        var split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        left.Add(int.Parse(split[0]));
        right.Add(int.Parse(split[1]));
    }
    
    left.Sort();
    right.Sort();
    
    return left.Select((t, i) => Math.Abs(t - right[i])).Sum();
}