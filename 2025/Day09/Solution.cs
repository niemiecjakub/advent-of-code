namespace AdventOfCode.Year2025.Day09;

public class Solution
{
  public static void PartOne()
  {
    var coordinates = File.ReadAllLines("2025/Day09/input.txt")
          .Select(l =>
          {
            var coords = l.Split(',');
            return new Point(int.Parse(coords[0]), int.Parse(coords[1]));
          })
          .ToList();
    long area = long.MinValue;
    for (int i = 0; i < coordinates.Count; i++)
    {

      for (int j = i + 1; j < coordinates.Count; j++)
      {
        var rectangle = new Rectangle(coordinates[i], coordinates[j]);
        if (rectangle.Area > area)
        {
          area = rectangle.Area;
        }
      }
    }

    Console.WriteLine($"Max area is: {area}");
  }

  public static void PartTwo()
  {

  }

  private readonly record struct Rectangle
  {
    public long Area { get; }
    public Rectangle(Point p1, Point p2)
    {
      long width = Math.Abs(p1.X - p2.X) + 1;
      long height = Math.Abs(p1.Y - p2.Y) + 1;
      Area = width * height;
    }
  }

  private record struct Point(int X, int Y);
}