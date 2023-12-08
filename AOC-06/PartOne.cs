namespace AOC_01
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class PartOne
    {
        public long Handle()
        {
            long num = 1;
            var lines = File.ReadAllLines("input.txt");

            var races = this.LoadRaces(lines);

            foreach(var race in races)
            {
                race.Calculate();
                num *= race.NumberOfWays;
            }




            return num;
        }

        private List<Race> LoadRaces(string[] lines)
        {
            var times = lines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var distances = lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var races = new List<Race>();
            for (int i = 1; i < times.Length; i++)
            {
                races.Add(new Race()
                {
                    Time = int.Parse(times[i]),
                    Distance = int.Parse(distances[i])
                });
            }
            return races;
        }
    }
}
