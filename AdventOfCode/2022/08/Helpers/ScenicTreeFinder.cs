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

                var scoreNorth = ViewingDistanceGoingNorth(row, col, treeGrid, currentHeight);
                var scoreSouth = ViewingDistanceGoingSouth(row, col, treeGrid, currentHeight);
                var scoreEast = ViewingDistanceGoingEast(row, col, treeGrid, currentHeight);
                var scoreWest = ViewingDistanceGoingWest(row, col, treeGrid, currentHeight);

                yield return scoreNorth * scoreSouth * scoreEast * scoreWest;
            }
        }
    }

    public static int ViewingDistanceGoingNorth(int row, int col, List<List<int>> treeGrid, int originalHeight)
    {
        if (row == 0)
            return 0;

        return originalHeight > treeGrid[row - 1][col] ? 1 + ViewingDistanceGoingNorth(row - 1, col, treeGrid, originalHeight) : 1;        
    }

    public static int ViewingDistanceGoingSouth(int row, int col, List<List<int>> treeGrid, int originalHeight)
    {
        if (row == treeGrid.Count - 1) 
            return 0;

        return originalHeight > treeGrid[row + 1][col] ? 1 + ViewingDistanceGoingSouth(row + 1, col, treeGrid, originalHeight) : 1;
    }

    public static int ViewingDistanceGoingEast(int row, int col, List<List<int>> treeGrid, int originalHeight)
    {
        if (col == 0)
            return 0;

        return originalHeight > treeGrid[row][col - 1] ? 1 + ViewingDistanceGoingEast(row, col - 1, treeGrid, originalHeight) : 1;
    }

    public static int ViewingDistanceGoingWest(int row, int col, List<List<int>> treeGrid, int originalHeight)
    {
        if (col == treeGrid[0].Count - 1)
            return 0;

        return originalHeight > treeGrid[row][col + 1] ? 1 + ViewingDistanceGoingWest(row, col + 1, treeGrid, originalHeight) : 1;
    }
}