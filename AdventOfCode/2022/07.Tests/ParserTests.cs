using _07.IO;

namespace _07.Tests;

public class ParserTests
{
    [Test]
    public void GetFileSystemStructure_WithRootAndOneFile_ReturnsCorrectStructure()
    {
        var input = new[]
        {
            "$ cd /",
            "$ ls",
            "100 b.at"
        };
        var parser = new Parser();

        var result = parser.GetFileSystemStructure(input);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Children, Has.Count.EqualTo(1));
        });
    }
}