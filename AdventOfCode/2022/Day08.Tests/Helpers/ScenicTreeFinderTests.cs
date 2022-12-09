using Day08.Helpers;

namespace Day08.Tests.Helpers;

public class ScenicTreeFinderTests
{
    [Test]
    public void GetScenicScores_WhenOnlyAnEdgeTree_ReturnsAScoreOfZero()
    {
        var grid = new List<List<int>>
        {
            new List<int> { 1 }
        };

        var scores = ScenicTreeFinder.GetScenicScores(grid).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(scores.Count(), Is.EqualTo(1));
            Assert.That(scores.Max(), Is.EqualTo(0));
        });
        
    }
}