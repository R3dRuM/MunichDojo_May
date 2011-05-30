namespace MunichDojo
{
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