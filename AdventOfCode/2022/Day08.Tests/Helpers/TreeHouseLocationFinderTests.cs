using Day08.Helpers;

namespace Day08.Tests.Helpers;

public class TreeHouseLocationFinderTests
{
    [Test]
    public void CountOfVisibleTrees_WithOnlyEdgesVisible_ReturnsEight()
    {
        var grid = new List<List<int>>
        {
            new List<int> { 2, 2, 2 },
            new List<int> { 2, 1, 2 },
            new List<int> { 2, 2, 2 }
        };

        var count = TreeHouseLocationFinder.CountOfVisibleTrees(grid);

        Assert.That(count, Is.EqualTo(8));
    }

    [Test]
    public void CountOfVisibleTrees_WithCenterNotVisible_ReturnsAllButOne()
    {
        var grid = new List<List<int>>
        {
            new List<int> { 2, 2, 2, 2, 2 },
            new List<int> { 2, 3, 3, 3, 2 },
            new List<int> { 2, 3, 2, 3, 2 },
            new List<int> { 2, 3, 3, 3, 2 },
            new List<int> { 2, 2, 2, 2, 2 },
        };

        var count = TreeHouseLocationFinder.CountOfVisibleTrees(grid);

        Assert.That(count, Is.EqualTo(grid.Count * grid.Count - 1));
    }

    [Test]
    public void CountOfVisibleTrees_WithSampleInputGrid_ReturnsCorrectCount()
    {
        var grid = new List<List<int>>
        {
            new List<int> { 3, 0, 3, 7, 3 },
            new List<int> { 2, 5, 5, 1, 2 },
            new List<int> { 6, 5, 3, 3, 2 },
            new List<int> { 3, 3, 5, 4, 9 },
            new List<int> { 3, 5, 3, 9, 0 },
        };

        var count = TreeHouseLocationFinder.CountOfVisibleTrees(grid);

        Assert.That(count, Is.EqualTo(21));
    }
}