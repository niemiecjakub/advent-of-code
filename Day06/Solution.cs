using System;
using System.Linq;

namespace AdventOfCode.Day06;

public class Solution
{
  public static void PartOne()
  {
    string[] input = File.ReadAllLines("Day06/Input.txt");
    var operators = input[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

    //column - math result
    Dictionary<int, long> map = new();
    for (int i = 0; i < input.Length - 1; i++)
    {
      var lineArgs = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
      for (int j = 0; j < lineArgs.Count; j++)
      {
        var opeartor = operators[j];
        long value = long.Parse(lineArgs[j]);

        if (map.ContainsKey(j))
        {
          switch (opeartor)
          {
            case "+":
              map[j] += value;
              break;
            case "*":
              map[j] *= value;
              break;
          }
        }
        else
        {
          map[j] = value;
        }
      }
    }

    long total = map.Values.Sum();

    Console.WriteLine($"Total: {total}");
  }

  public static void PartTwo()
  {

  }

}