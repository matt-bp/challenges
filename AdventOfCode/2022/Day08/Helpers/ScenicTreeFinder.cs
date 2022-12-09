namespace Day08.Helpers;

public static class ScenicTreeFinder
{
    public static IEnumerable<int> GetScenicScores(List<List<int>> treeGrid)
    {
        for (var row = 0; row < treeGrid.Count; row++)
        {
            for (var col = 0; col < treeGrid[row].Count; col++)
            {
                var currentHeight = treeGrid[row][col];
                // if (IsVisibleGoingNorth(row, col, treeGrid, currentHeight) || IsVisibleGoingSouth(row, col, treeGrid, currentHeight) ||
                //     IsVisibleGoingEast(row, col, treeGrid, currentHeight) || IsVisibleGoingWest(row, col, treeGrid, currentHeight))

                yield return 1;
            }
        }
        
        // return Enumerable.Empty<int>();
    }
}