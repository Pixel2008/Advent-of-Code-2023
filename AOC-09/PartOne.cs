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
            long num = 0;
            var lines = File.ReadAllLines("input.txt");
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                num += this.CalculateLine(line);
            }

            return num;
        }

        private long CalculateLine(string line)
        {
            var items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            var lastItems = new List<long>();
            while (!items.All(x => x == 0))
            {
                lastItems.Add(items.LastOrDefault());

                var list = new List<long>();
                for (int i = 0; i < items.Count - 1; i++)
                {
                    list.Add(items[i + 1] - items[i]);
                }

                items = list;
            }
            return lastItems.Sum();

        }
    }
}
