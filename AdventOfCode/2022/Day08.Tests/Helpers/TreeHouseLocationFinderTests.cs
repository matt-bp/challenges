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
}