using System;
using System.Collections.Generic;

namespace Walls_and_Gates
{
  class Program
  {
    static void Main(string[] args)
    {
      var rooms = new int[4][] 
      { 
        new int[] { 2147483647, -1, 0, 2147483647 }, 
        new int[] { 2147483647, 2147483647, 2147483647, -1 }, 
        new int[] { 2147483647, -1, 2147483647, -1 }, 
        new int[] { 0, -1, 2147483647, 2147483647 } 
      };

      Program p = new Program();
      p.WallsAndGates(rooms);
      foreach (var room in rooms)
        Console.WriteLine(string.Join(",", room));
    }

    public void WallsAndGates(int[][] rooms)
    {
      int row = rooms.Length;
      int column = rooms[0].Length;

      Queue<(int, int)> q = new Queue<(int, int)>();
      // Traverse the entire matrix and insert gate positions into the queue.
      // Later for every gate position will find and update the distance to gate.
      for (int i = 0; i < row; i++)
      {
        for (int j = 0; j < column; j++)
        {
          if (rooms[i][j] == 0)
          {
            q.Enqueue((i, j));
          }
        }
      }

      List<int[]> directions = new List<int[]>();
      directions.Add(new int[] { 0, 1 });
      directions.Add(new int[] { 0, -1 });
      directions.Add(new int[] { 1, 0 });
      directions.Add(new int[] { -1, 0 });
      // DO BFS for each gate distance from empty cell.
      // When a empty cell is updated with new distance from the gate, add the position in q to perform BFS on that possition as well
      while (q.Count > 0)
      {
        var (r, c) = q.Dequeue();
        foreach (var direction in directions)
        {
          int newRow = r + direction[0];
          int newColumn = c + direction[1];

          if (newRow >= 0 && newRow < row &&
              newColumn >= 0 && newColumn < column &&
              rooms[newRow][newColumn] == int.MaxValue)
          {
            rooms[newRow][newColumn] = rooms[r][c] + 1;
            q.Enqueue((newRow, newColumn));
          }
        }

      }
    }
  }
}
