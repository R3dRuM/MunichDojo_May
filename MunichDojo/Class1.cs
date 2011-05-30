using System;
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
            game.Roll(0);
            
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
        private List<Frame> frames = new List<Frame>();

        public Game()
        {
            frames.Add(new Frame());
        }

        private Frame CurrentFrame
        {
            get
            {
                var currentframe = frames.Last();
                if (currentframe.IsFull)
                {
                    frames.Add(new Frame());
                }
                return frames.Last();
            }
        }


        public void Roll(int i)
        {
            CurrentFrame.Roll(i);
        }


        public int Score( )
        {
            int result = 0;
            for (int i = 0; i < frames.Count; i++)
            {
                if (frames[i].IsSpare)
                {
                    if (i < frames.Count - 1)
                    {
                        result += frames[i + 1].FirstRoll.Value;
                    }                    
                }
                result += frames[i].Sum;
                
            }
            return result;


        }
    }

    internal class Frame
    {
        public int? FirstRoll { get; set; }
        public int? SecondRoll { get; set; }

        public bool IsFull
        {
            get { return (FirstRoll.HasValue && SecondRoll.HasValue); }
        }

        public void Roll(int i)
        {
            if (!FirstRoll.HasValue)
            {
                FirstRoll = i;
            }
            else
            {
                SecondRoll = i;
            }
        }

        public int Sum
        {
            get { return FirstRoll.Value + SecondRoll.Value; }
        }

        public bool IsSpare
        {
            get { return Sum == 10; }
        }
    }
}
