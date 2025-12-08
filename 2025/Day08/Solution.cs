namespace AdventOfCode.Year2025.Day08;

public class Solution
{
  public static void PartOne()
  {
    var positions = File.ReadAllLines("2025/Day08/input.txt")
      .Select(l =>
      {
        var coords = l.Split(',');
        return new Position(int.Parse(coords[0]), int.Parse(coords[1]), int.Parse(coords[2]));
      })
      .ToList();

    var edges = new List<Edge>();
    for (int i = 0; i < positions.Count; i++)
    {
      for (int j = i + 1; j < positions.Count; j++)
      {
        var p1 = positions[i];
        var p2 = positions[j];
        var dist = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        edges.Add(new Edge(p1, p2, dist));
      }
    }

    var edgesSorted = edges.OrderBy(e => e.Distance).ToList();
    var unionFind = new UnionFind(positions);

    for (int i = 0; i < 1000; i++)
    {
      var edge = edgesSorted[i];
      unionFind.Union(edge.P1, edge.P2);
    }

    var circuits2 = positions
     .GroupBy(unionFind.Find);

    var circuits = positions
        .GroupBy(unionFind.Find)
        .Select(g => g.Count())
        .OrderByDescending(count => count)
        .ToList();

    var top3 = circuits.Take(3).ToList();
    long result = 1;
    foreach (var size in top3)
    {
      result *= size;
    }

    Console.WriteLine($"Result: {result}");
  }

  private record Edge(Position P1, Position P2, double Distance);
  private record Position(int X, int Y, int Z);
  private class UnionFind
  {
    private Dictionary<Position, Position> _parent = new();

    public UnionFind(List<Position> positions)
    {
      foreach (var p in positions)
      {
        _parent[p] = p;
      }
    }

    public Position Find(Position p)
    {
      if (_parent[p] != p)
      {
        _parent[p] = Find(_parent[p]);
      }
      return _parent[p];
    }

    public void Union(Position p1, Position p2)
    {
      var root1 = Find(p1);
      var root2 = Find(p2);

      if (root1 == root2)
      {
        return;
      }

      _parent[root1] = root2;
    }
  }
}