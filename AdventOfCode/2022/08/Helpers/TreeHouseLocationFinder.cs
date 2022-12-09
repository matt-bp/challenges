using System;
using System.Collections;
using System.Data;

namespace Day08.Helpers;

public static class TreeHouseLocationFinder
{
    public static int CountOfVisibleTrees(List<List<int>> treeGrid)
    {
        var count = 0;

        var grid =  Enumerable.Range(0, treeGrid.Count)
            .Select(x => new List<int>()).ToList();

        for (var row = 0; row < treeGrid.Count; row++)
        {
            for (var col = 0; col < treeGrid[row].Count; col++)
            {
                var currentHeight = treeGrid[row][col];
                if (IsVisibleGoingNorth(row, col, treeGrid, currentHeight) || IsVisibleGoingSouth(row, col, treeGrid, currentHeight) ||
                    IsVisibleGoingEast(row, col, treeGrid, currentHeight) || IsVisibleGoingWest(row, col, treeGrid, currentHeight))
                {
                    count += 1;
                }
                //else
                //{
                //    Console.WriteLine("Not visible from ({0}, {1})", row, col);
                //}
            }
        }

        return count;
    }

    private static bool IsVisibleGoingNorth(int row, int col, List<List<int>> treeGrid, int originalHeight)
    {
        if (row == 0)
        {
            return true;
        }

        return originalHeight > treeGrid[row - 1][col] && IsVisibleGoingNorth(row - 1, col, treeGrid, originalHeight);
    }

    private static bool IsVisibleGoingSouth(int row, int col, List<List<int>> treeGrid, int originalHeight)
    {
        if (row == treeGrid.Count - 1)
        {
            return true;
        }

        return originalHeight > treeGrid[row + 1][col] && IsVisibleGoingSouth(row + 1, col, treeGrid, originalHeight);
    }

    private static bool IsVisibleGoingEast(int row, int col, List<List<int>> treeGrid, int originalHeight)
    {
        if (col == 0)
        {
            return true;
        }

        return originalHeight > treeGrid[row][col - 1] && IsVisibleGoingEast(row, col - 1, treeGrid, originalHeight);
    }

    private static bool IsVisibleGoingWest(int row, int col, List<List<int>> treeGrid, int originalHeight)
    {
        if (col == treeGrid[0].Count - 1)
        {
            return true;
        }

        return originalHeight > treeGrid[row][col + 1] && IsVisibleGoingWest(row, col + 1, treeGrid, originalHeight);
    }
}