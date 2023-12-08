namespace AOC_01
{
    internal class Race
    {
        public long Time { get; set; }
        public long Distance { get; set; }
        public long NumberOfWays = 0;


        internal void Calculate()
        {
            for (long i = 1; i <= Time; i++)
            {
                var distance = i * (Time - i);
                if (distance > Distance)
                {
                    NumberOfWays++;
                }
            }
        }
    }
}
