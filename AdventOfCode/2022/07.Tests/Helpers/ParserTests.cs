using _07.Helpers;

namespace _07.Tests.Helpers;

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

    [Test]
    public void GetFileSystemStructure_WithAdditionalEmptyDirectory_ReturnsCorrectStructure()
    {
        var input = new[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "100 b.at"
        };
        var parser = new Parser();

        var result = parser.GetFileSystemStructure(input);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Children, Has.Count.EqualTo(2));
        });
    }

    [Test]
    public void GetFileSystemStructure_WithANonEmptyDirectory_ReturnsCorrectStructure()
    {
        var input = new[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "100 b.at",
            "$ cd a",
            "$ ls",
            "101 a.at"
        };
        var parser = new Parser();

        var result = parser.GetFileSystemStructure(input);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Children, Has.Count.EqualTo(2));
            Assert.That((result.Children[0] as Models.Directory).Children, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void GetFileSystemStructure_WithTwoNonEmptyDirectories_ReturnsCorrectStructure()
    {
        var input = new[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "dir b",
            "$ cd a",
            "$ ls",
            "101 a.at",
            "$ cd ..",
            "$ cd b",
            "$ ls",
            "100 b.at"
        };
        var parser = new Parser();

        var result = parser.GetFileSystemStructure(input);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Children, Has.Count.EqualTo(2));
            Assert.That((result.Children[0] as Models.Directory).Children, Has.Count.EqualTo(1));
            Assert.That((result.Children[1] as Models.Directory).Children, Has.Count.EqualTo(1));
        });
    }
}