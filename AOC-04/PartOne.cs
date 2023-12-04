namespace AOC_01
{
    using System;
    using System.IO;
    using System.Linq;

    class PartOne
    {
        public int Handle()
        {
            int sum = 0;
            var lines = File.ReadAllLines("input.txt");

           

            foreach (var line in lines)
            {
                var winningCards = this.GetWinningsCards(line);
                var cards = this.GetCards(line);
                var existed = cards.Count(x => winningCards.Contains(x));
                var points = this.CountPoints(existed);
                sum += points;
            }


            return sum;
        }

        private int[] GetWinningsCards(string line)
        {
            var items = line.Split(new[] { ":", "|" }, StringSplitOptions.RemoveEmptyEntries);
            return items[1]
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => int.Parse(x))
                     .ToArray();
        }

        private int[] GetCards(string line)
        {
            var items = line.Split(new[] { ":", "|" }, StringSplitOptions.RemoveEmptyEntries);
            return items[2]
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => int.Parse(x))
                     .ToArray();
        }

        private int CountPoints(int num)
        {
            if(num == 0) return 0;
            int c = 1;
            for (int i = 0; i < num - 1; i++)
            {
                c *= 2;
            }
            return c;
        }
    }
}
