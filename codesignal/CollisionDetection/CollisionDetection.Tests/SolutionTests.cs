namespace CollisionDetection.Tests;

public class SolutionTests
{
    [Test]
    public void Solution_WithExampleInput_Returns4()
    {
        var input = new[]
        {
            new[] { 1, 1 },
            new[] { 2, 2 },
            new[] { 0, 4 },
            new[] { 1, 1 }
        };
        var runner = new Solution();

        var result = runner.NumberOfCollisions(input);

        Assert.That(result, Is.EqualTo(4));
    }
}