using System.Collections.Generic;
using System.Linq;
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
            
            RollMany(game, 16);

            Assert.That(game.Score(), Is.EqualTo(12));
        }

        private void RollMany(Game game, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(0);
            }
        }
    }

    public class Game
    {
        private List<int> rolls = new List<int>();

        public void Roll(int i)
        {
        rolls.Add(i);
        }

        public int Score()
        {
            return rolls.Sum();
        }
    }
}
