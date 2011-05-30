using System;

namespace MunichDojo
{
    internal class Frame
    {
        public int? FirstRoll { get; set; }
        public int? SecondRoll { get; set; }

        public bool IsFull
        {
            get
            {
                return IsStrike?true:(FirstRoll.HasValue && SecondRoll.HasValue);
            }
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
            get
            {
                if (IsStrike) return FirstRoll??0;

                if (SecondRoll.HasValue) 
                    return FirstRoll??0 + SecondRoll??0;
                
                return FirstRoll??0;
            }
        }

        public bool IsSpare
        {
            get { return Sum == 10; }
        }

        public bool IsStrike
        {
            get { return (FirstRoll.HasValue?FirstRoll.Value == 10:false); }
        }
    }
}