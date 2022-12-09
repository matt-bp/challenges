using _09.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using _09.Models;
using FluentAssertions;

namespace _09.Tests.Helpers
{
    internal class SimulationTests
    {
        [Test]
        public void Apply_OnStartingPosition_OnlyMovesHead()
        {
            var sim = new Simulation(new Vector2 { X = 0, Y = 0 });
            var direction = new Vector2 { X = 1, Y = 0 };

            sim.Apply(direction);

            Assert.Multiple(() =>
            {
                sim.HeadPosition.Should().BeEquivalentTo(new Vector2 { X = 1, Y = 0 });
                sim.TailPosition.Should().BeEquivalentTo(new Vector2 { X = 0, Y = 0 });
            });
        }

        [Test]
        public void Apply_WhenHeadIsRightOfTails_MovesTails()
        {
            var sim = new Simulation(new Vector2 { X = 1, Y = 0 }, new Vector2 { X = 0, Y = 0 });
            var direction = new Vector2 { X = 1, Y = 0 };

            sim.Apply(direction);

            Assert.Multiple(() =>
            {
                sim.HeadPosition.Should().BeEquivalentTo(new Vector2 { X = 2, Y = 0 });
                sim.TailPosition.Should().BeEquivalentTo(new Vector2 { X = 1, Y = 0 });
            });
        }

        [Test]
        public void Apply_WhenHeadIsLeftOfTails_MovesTails()
        {
            var sim = new Simulation(new Vector2 { X = -1, Y = 0 }, new Vector2 { X = 0, Y = 0 });
            var direction = new Vector2 { X = -1, Y = 0 };

            sim.Apply(direction);

            Assert.Multiple(() =>
            {
                sim.HeadPosition.Should().BeEquivalentTo(new Vector2 { X = -2, Y = 0 });
                sim.TailPosition.Should().BeEquivalentTo(new Vector2 { X = -1, Y = 0 });
            });
        }

        [Test]
        public void Apply_WhenHeadIsAboveTails_MovesTails()
        {
            var sim = new Simulation(new Vector2 { X = 0, Y = 1 }, new Vector2 { X = 0, Y = 0 });
            var direction = new Vector2 { X = 0, Y = 1 };

            sim.Apply(direction);

            Assert.Multiple(() =>
            {
                sim.HeadPosition.Should().BeEquivalentTo(new Vector2 { X = 0, Y = 2 });
                sim.TailPosition.Should().BeEquivalentTo(new Vector2 { X = 0, Y = 1 });
            });
        }

        [Test]
        public void Apply_WhenHeadIsBelowTails_MovesTails()
        {
            var sim = new Simulation(new Vector2 { X = 0, Y = -1 }, new Vector2 { X = 0, Y = 0 });
            var direction = new Vector2 { X = 0, Y = -1 };

            sim.Apply(direction);

            Assert.Multiple(() =>
            {
                sim.HeadPosition.Should().BeEquivalentTo(new Vector2 { X = 0, Y = -2 });
                sim.TailPosition.Should().BeEquivalentTo(new Vector2 { X = 0, Y = -1 });
            });
        }

        [Test]
        public void Apply_WhenHeadDiagonallyAboveTails_DontMoveTails()
        {
            var sim = new Simulation(headPosition: new Vector2 { X = 1, Y = 0 }, tailPosition: new Vector2 { X = 0, Y = 0 });
            var direction = new Vector2 { X = 0, Y = 1 };

            sim.Apply(direction);

            Assert.Multiple(() =>
            {
                sim.HeadPosition.Should().BeEquivalentTo(new Vector2 { X = 1, Y = 1 });
                sim.TailPosition.Should().BeEquivalentTo(new Vector2 { X = 0, Y = 0 });
            });
        }

        [Test]
        public void Apply_WhenHeadDiagonallyAboveAndMoves_MoveTails()
        {
            var sim = new Simulation(headPosition: new Vector2 { X = 1, Y = 1 }, tailPosition: new Vector2 { X = 0, Y = 0 });
            var direction = new Vector2 { X = 0, Y = 1 };

            sim.Apply(direction);

            Assert.Multiple(() =>
            {
                sim.HeadPosition.Should().BeEquivalentTo(new Vector2 { X = 1, Y = 2 });
                sim.TailPosition.Should().BeEquivalentTo(new Vector2 { X = 1, Y = 1 });
            });
        }
    }
}
