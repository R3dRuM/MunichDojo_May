using System.Collections.Generic;
using System.Linq;

namespace MunichDojo
{
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


        public int Score()
        {
            int result = 0;
            for (int i = 0; i < frames.Count; i++)
            {
                if (i < frames.Count - 1)
                {
                    if (frames[i].IsStrike)
                    {
                        result += ScoreStrike(i);
                    }
                    else
                    {
                        if (frames[i].IsSpare)
                        {
                            result += NextFrame(i).FirstRoll.Value;
                        }
                    }
                }
                result += frames[i].Sum;

            }
            return result;
        }

        private int ScoreStrike(int i)
        {
            return NextFrame(i).IsStrike
                       ? 10 + NextFrame(i+1).FirstRoll.Value
                       : NextFrame(i).Sum;
        }

        private Frame NextFrame(int i)
        {
            return frames[i + 1];
        }
    }
}