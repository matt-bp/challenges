using _05.Parts;

namespace _05.Tests;

public class CraneTests
{
    [Test]
    public void ApplyMove_WhenMovingOneCrate_WorksAsIntended()
    {
        var stacks = Crate.CreateStack(2);
        stacks[0].Add("Z");
        var crane = new Crane();
        
        crane.ApplyMove(stacks, new Move { Count = 1, Source = 0, Destination = 1});
        
        Assert.Multiple(() =>
        {
            Assert.That(stacks[0], Has.Count.EqualTo(0));
            Assert.That(stacks[1], Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void ApplyMove_WhenMovingMultipleCrates_GetsTheOrderRight()
    {
        var stacks = Crate.CreateStack(2);
        stacks[0].Add("Z");
        stacks[0].Add("Y");
        stacks[1].Add("X");
        var crane = new Crane();
        
        crane.ApplyMove(stacks, new Move { Count = 2, Source = 0, Destination = 1});
        
        Assert.Multiple(() =>
        {
            Assert.That(stacks[0], Has.Count.EqualTo(0));
            Assert.That(stacks[1], Has.Count.EqualTo(3));
            var expectedOrdering = new List<string>
            {
                "X", "Y", "Z"
            };
            Assert.That(stacks[1], Is.EquivalentTo(expectedOrdering));
        });
    }

    [Test]
    public void GetTopCrates_WithOneCrateAndEmptyStacks_ReturnsThatOneCrate()
    {
        var stacks = Crate.CreateStack(2);
        stacks[0].Add("Z");
        var crane = new Crane();

        var result = crane.GetTopCrates(stacks);
        
        Assert.That(result, Is.EqualTo("Z"));
    }
    
}