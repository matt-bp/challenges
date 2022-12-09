using System;
using System.Collections;
using System.Data;

namespace Day08.Helpers;

public class TreeHouseLocationFinder
{
    //public static int CountOfVisibleTrees(List<List<int>> treeGrid)
    //{
    //    var count = 0;
        
    //    for (var row = 0; row < treeGrid.Count; row++)
    //    {
    //        for (var col = 0; col < treeGrid[row].Count; col++)
    //        {
    //            count += IsVisible(row, col, treeGrid) ? 1 : 0;
    //        }
    //    }

    //    return count;
    //}

    public static int CountOfVisibleTrees(List<List<int>> treeGrid)
    {
        var count = 0;

        var grid =  Enumerable.Range(0, treeGrid.Count)
            .Select(x => new List<int>()).ToList();

        for (var row = 0; row < treeGrid.Count; row++)
        {
            for (var col = 0; col < treeGrid[row].Count; col++)
            {
                if (IsVisibleGoingNorth(row, col, treeGrid) || IsVisibleGoingSouth(row, col, treeGrid) || IsVisibleGoingEast(row, col, treeGrid) || IsVisibleGoingWest(row, col, treeGrid))
                {
                    count += 1;
                }
            }
        }

        return count;
    }

    private static bool IsVisibleGoingNorth(int row, int col, List<List<int>> treeGrid)
    {
        if (row == 0)
        {
            return true;
        }

        return treeGrid[row][col] > treeGrid[row - 1][col] && IsVisibleGoingNorth(row - 1, col, treeGrid);
    }

    private static bool IsVisibleGoingSouth(int row, int col, List<List<int>> treeGrid)
    {
        if (row == treeGrid.Count - 1)
        {
            return true;
        }

        return treeGrid[row][col] > treeGrid[row + 1][col] && IsVisibleGoingSouth(row + 1, col, treeGrid);
    }

    private static bool IsVisibleGoingEast(int row, int col, List<List<int>> treeGrid)
    {
        if (col == 0)
        {
            return true;
        }

        return treeGrid[row][col] > treeGrid[row][col - 1] && IsVisibleGoingEast(row, col - 1, treeGrid);
    }

    private static bool IsVisibleGoingWest(int row, int col, List<List<int>> treeGrid)
    {
        if (col == treeGrid[0].Count - 1)
        {
            return true;
        }

        return treeGrid[row][col] > treeGrid[row][col + 1] && IsVisibleGoingWest(row, col + 1, treeGrid);
    }
}