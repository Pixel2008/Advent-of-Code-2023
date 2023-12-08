namespace AOC_01
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class PartOne
    {
        public long Handle()
        {
            long num = 1;
            var lines = File.ReadAllLines("input.txt");

            var hands = this.ReadHands(lines)
                .ToList();
            hands.Sort((x, y) => x.CompareTo(y));

            num = hands.Select((value, index) => new { value, index }).Sum(x => x.value.Bid * (x.index + 1));

            return num;
        }

        private IEnumerable<HandPartOne> ReadHands(string[] lines)
        {
            foreach (var line in lines)
            {
                var items = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                yield return new HandPartOne()
                {
                    Cards = items[0],
                    Bid = int.Parse(items[1])
                };

            }
        }
    }
}
