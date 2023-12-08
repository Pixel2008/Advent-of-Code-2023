namespace AOC_01
{
    using System;
    using System.IO;
    using System.Linq;

    class PartTwo
    {
        public long Handle()
        {
            long num = 1;
            var lines = File.ReadAllLines("input.txt");

            var race = this.LoadRaces(lines);

            race.Calculate();
            num = race.NumberOfWays;

            return num;
        }

        private Race LoadRaces(string[] lines)
        {
            var time = lines[0].Split(":", StringSplitOptions.RemoveEmptyEntries)
                .Last().Replace(" ", "");
            var distance = lines[1].Split(":", StringSplitOptions.RemoveEmptyEntries)
                .Last().Replace(" ", "");

            return new Race()
            {
                Time = long.Parse(time),
                Distance = long.Parse(distance)
            };
        }
    }
}
