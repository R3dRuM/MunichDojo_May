using System;
using NUnit.Framework;

namespace MunichDojo
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void RollOneReturnsResultOne()
        {
            var game = new Game();
            game.Roll(1);
            game.Roll(0);
            RollMany(game, 18, 0);
            
            Assert.That(game.Score(), Is.EqualTo(1));
        }

        [Test]
        public void RollAllOnesShouldReturn20()
        {
            var game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }
            Assert.That(game.Score(), Is.EqualTo(20));
        }

        [Test]
        public void SingleSpareShouldScore()
        {
            var game = new Game();
            game.Roll(1);
            game.Roll(9);

            game.Roll(1);
            game.Roll(0);
            
            RollMany(game, 16, 0);

            Assert.That(game.Score(), Is.EqualTo(12));
        }

        private void RollMany(Game game, int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        [Test]
        public void SingleStrikeShouldScore()
        {
            var game = new Game();
            game.Roll(10);

            game.Roll(1);
            game.Roll(1);

            RollMany(game, 16, 0);

            Assert.That(game.Score(), Is.EqualTo(14));
        }

        [Test]
        public void DoubleStrikeShouldScore()
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(10);
            game.Roll(1);
            game.Roll(2);

            RollMany(game, 14, 0);

            Assert.That(game.Score(), Is.EqualTo(21+13+3));
        }

        [Test]
        public void StrikeAtTheEndShouldScore()
        {
            var game = new Game();
            RollMany(game,18, 0);
            game.Roll(10);
            game.Roll(1);
            game.Roll(2);

            Assert.That(game.Score(), Is.EqualTo(16));
        }

        [Test]
        public void OnlyFiveRollsScores150()
        {
            var game = new Game();
            RollMany(game, 21, 5);

            Assert.That(game.Score(), Is.EqualTo(150));
        }
    }
}
