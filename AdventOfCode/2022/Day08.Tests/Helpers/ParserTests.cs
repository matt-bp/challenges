using Day08.Helpers;

namespace Day08.Tests.Helpers;

public class ParserTests
{
    [Test]
    public void GetTreeHeightGridFromInput_WhenPassedA3by3_ReturnsMatchingShapedGrid()
    {
        var input = new[]
        {
            "111",
            "111",
            "111"
        };

        var grid = Parser.GetTreeHeightGridFromInput(input);
        
        Assert.Multiple(() =>
        {
            Assert.That(grid, Has.Count.EqualTo(3));
            Assert.That(grid[0], Has.Count.EqualTo(3));
        });
    }
}