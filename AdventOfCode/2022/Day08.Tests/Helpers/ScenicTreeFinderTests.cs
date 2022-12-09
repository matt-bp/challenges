using Day08.Helpers;
using static System.Formats.Asn1.AsnWriter;

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
            Assert.That(scores, Has.Count.EqualTo(1));
            Assert.That(scores.Max(), Is.EqualTo(0));
        });
    }

    [Test]
    public void GetScenicScores_WithMiddleMostScenic_ReturnsScoresWithMiddleHighest()
    {

        var grid = new List<List<int>>
        {
            new List<int> { 2, 2, 2 },
            new List<int> { 2, 3, 2 },
            new List<int> { 2, 2, 2 }
        };

        var scores = ScenicTreeFinder.GetScenicScores(grid).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(scores, Has.Count.EqualTo(9));
            Assert.That(scores.Max(), Is.EqualTo(1));
        });
    }

    [Test]
    public void GetScenicScores_UsingSampleInput_ReturnsEightMax()
    {
        var grid = new List<List<int>>
        {
            new List<int> { 3, 0, 3, 7, 3 },
            new List<int> { 2, 5, 5, 1, 2 },
            new List<int> { 6, 5, 3, 3, 2 },
            new List<int> { 3, 3, 5, 4, 9 },
            new List<int> { 3, 5, 3, 9, 0 },
        };

        var scores = ScenicTreeFinder.GetScenicScores(grid).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(scores, Has.Count.EqualTo(25));
            Assert.That(scores.Max(), Is.EqualTo(8));
        });
    }
}