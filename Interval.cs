namespace Intervals
{
    public struct Interval
    {
        private Random random = new Random();
        public int Min { get; }
        public int Max { get; }
        public float Get => (float)(random.NextDouble() * (Max - Min) + Min);


        public Interval(int minValue, int maxValue)
        {
            if(minValue > maxValue) 
            {
                (minValue, maxValue) = (maxValue, minValue);
                Console.WriteLine("incorrect value");
            }

            if (minValue < 0 || maxValue < 0)
            {
                if(minValue < 0) { minValue = 0; }
                if(maxValue < 0) { maxValue = 0; }
                Console.WriteLine("incorrect value");
            }

            if (minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("incorrect value");
            }

            Min = minValue;
            Max = maxValue;
        }
    }

   
}
