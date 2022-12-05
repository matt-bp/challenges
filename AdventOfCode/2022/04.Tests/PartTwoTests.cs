using _04.Parts;

namespace _04.Tests
{
    public class PartTwoTests
    {
        [Test]
        public void Run_WithNoOverlap_ReturnsZero()
        {
            var assignmentPairs = new[] { "2-4,6-8" };

            var count = PartTwo.Run(assignmentPairs);

            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void Run_WithStartEquals_ReturnsOne()
        {
            var assignmentPairs = new[] { "5-7,7-9" };

            var count = PartTwo.Run(assignmentPairs);

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void Run_WithFirstTotallyOverlappingSecond_ReturnsOne()
        {
            var assignmentPairs = new[] { "2-8,3-7" };

            var count = PartTwo.Run(assignmentPairs);

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void Run_WithEndsEqual_ReturnsOne()
        {
            var assignmentPairs = new[] { "6-6,4-6" };

            var count = PartTwo.Run(assignmentPairs);

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void Run_WithHalfOverlap_ReturnsOne()
        {
            var assignmentPairs = new[] { "2-6,4-8" };

            var count = PartTwo.Run(assignmentPairs);

            Assert.That(count, Is.EqualTo(1));
        }
    }
}