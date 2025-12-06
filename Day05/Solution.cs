namespace AdventOfCode.Day05;

public class Solution
{
  public static void PartOne()
  {
    string[] input = File.ReadAllText("Day05/input.txt").Split("\n");

    Dictionary<long, long[]> ranges = input
      .Where(s => s.Contains("-"))
      .Select(c =>
      {
        var range = c.Split("-");
        return (long.Parse(range[0]), long.Parse(range[1]));
      })
      .GroupBy(c => c.Item1)
      .OrderBy(t => t.Key)
      .ToDictionary(
        c => c.Key,
        c => c.Select(v => v.Item2).ToArray()
       );

    int counter = input
      .Where(s => !s.Contains("-") && !string.IsNullOrWhiteSpace(s))
      .Select(long.Parse)
      .Count(number => ranges.FirstOrDefault(kvp => number >= kvp.Key && number <= kvp.Value.Max()).Value != null);

    Console.WriteLine($"There are {counter} fresh ingredient IDs");
  }

  public static void PartTwo()
  {
  }
}
