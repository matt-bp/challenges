using System;
using System.Collections;
using System.Data;

namespace Day08.Helpers;

public class TreeHouseLocationFinder
{
    public static int CountOfVisibleTrees(List<List<int>> treeGrid)
    {
        var count = 0;
        
        for (var row = 0; row < treeGrid.Count; row++)
        {
            for (var col = 0; col < treeGrid[row].Count; col++)
            {
                count += IsVisible(row, col, treeGrid) ? 1 : 0;
            }
        }

        return count;
    }

    private static bool IsVisible(int row, int col, List<List<int>> treeGrid)
    {
        return row == 0 || col == 0 || row == treeGrid.Count - 1 || col == treeGrid[0].Count - 1;
    }
}