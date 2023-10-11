using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionDetection.Tests
{
    internal class SolutionTests
    {
        [Test]
        public void NumberOfCollisions_WithThreeSquares_ReturnsTwo()
        {
            var positions = new int[][]
            {
                new int[] { 1, 1 },
                new int[] { 2, 2 },
                new int[] { 0, 4 },
                new int[] { 5, 5 },
            };
            var runner = new Library.Solution();

            var result = runner.NumberOfCollisions(positions);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void NumberOfCollisionsDivide_WithThreeSquares_ReturnsTwo()
        {
            var positions = new int[][]
            {
                new int[] { 1, 1 },
                new int[] { 2, 2 },
                new int[] { 0, 4 },
            };
            var runner = new Library.Solution();

            var result = runner.NumberOfCollisionsDivide(positions);

            Assert.That(result, Is.EqualTo(2));
        }
    }
}
