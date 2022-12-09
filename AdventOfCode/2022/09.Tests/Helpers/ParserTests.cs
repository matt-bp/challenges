using _09.Helpers;
using _09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Numerics;

namespace _09.Tests.Helpers
{
    internal class ParserTests
    {
        [Test]
        public void GetMoves_WithOneMove_ReturnsThatMoveCorrectlyParsed()
        {
            var input = new[]
            {
                "R 1"
            };
            var expected = new Move
            {
                Direction = Vector2.UnitX,
                Count = 1,
            };

            var moves = Parser.GetMoves(input).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(moves, Has.Count.EqualTo(1));
                moves.First().Should().BeEquivalentTo(expected);
            });

        }
    }
}
