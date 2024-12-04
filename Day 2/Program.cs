// Problem statement: https://adventofcode.com/2024/day/2
const string inputFilePath = "input.txt";

var safeReports = File.ReadLines(inputFilePath)
    .Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList())
    .Count(IsSafeReportWithProblemDampener);

Console.WriteLine(safeReports);
return;

// To solve part 2
bool IsSafeReportWithProblemDampener(IReadOnlyList<int> levels)
{
    if (IsSafeReport(levels))
    {
        return true;
    }

    for (var i = 0; i < levels.Count; i++)
    {
        var copy = levels.ToList();
        copy.RemoveAt(i);
        if (IsSafeReport(copy))
        {
            return true;
        }
    }
    
    return false;
}

// To solve part 1
bool IsSafeReport(IReadOnlyList<int> levels)
{
    var possibleValues = new HashSet<int> { 1, 2, 3 };
    var trend = levels[0] < levels[^1] ? 1 : -1;
    var isSafe = true;
    for (var i = 1; i < levels.Count; i++)
    {
        if (!possibleValues.Contains((levels[i] - levels[i - 1]) * trend))
        {
            isSafe = false;
            break;
        }
    }
    return isSafe;
}
