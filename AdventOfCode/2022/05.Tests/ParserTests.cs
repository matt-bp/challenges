using _05.Parts;

namespace _05.Tests;

public class ParserTests
{
    [Test]
    public void GetInitialConfiguration_WhenPassedSmallGrid_CorrectlyParsesGrid()
    {
        var lines = new[]
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            ""
        };

        var output = Parser.GetInitialCrateConfiguration(lines);

        Assert.Multiple(() =>
        {
            Assert.That(output[0], Has.Count.EqualTo(2));
            Assert.That(output[1], Has.Count.EqualTo(3));
            Assert.That(output[2], Has.Count.EqualTo(1));
        });
    }
}