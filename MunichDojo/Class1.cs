using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MunichDojo
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void RollOneReturnResultOne()
        {
            var game = new Game();
            game.Roll(1);
            
            Assert.That(game.Score(), Is.EqualTo(1));
        }
    }

    public class Game
    {
        public void Roll(int i)
        {
            throw new NotImplementedException();
        }

        public int Score()
        {
        throw new NotImplementedException();
        }
    }
}
