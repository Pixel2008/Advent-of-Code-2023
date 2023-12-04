namespace AOC_01
{
    using System;
    using System.Collections.Generic;
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
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Empty line");
                    continue;
                }
                var num = this.FindNum(line);
                sum += num;
            }
            return sum;
        }

        private int FindNum(string line)
        {
            var gameLine = this.GetGame(line);
            var colorSets = this.GetColorSets(line);

            if (this.CheckColorsSets(colorSets))
            {
                return this.FindGameNum(gameLine);
            }

            return 0;
        }

        private string GetGame(string line)
        {
            var items = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
            return items[0];
        }

        private List<string> GetColorSets(string line)
        {
            var items = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
            return items[1].Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private int FindGameNum(string gameLine)
        {
            var items = gameLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(items[1]);
        }

        private bool CheckColorsSets(IList<string> colorSets)
        {
            foreach (var colorSet in colorSets)
            {
                var colors = colorSet.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var color in colors)
                {
                    if (this.CheckColorSet(color) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckColorSet(string colorSet)
        {
            var items = colorSet.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var quantity = int.Parse(items[0]);
            var color = items[1];
            if (color.Equals("red", StringComparison.InvariantCultureIgnoreCase))
            {
                if (quantity > 12)
                {
                    return false;
                }
            }
            if (color.Equals("green", StringComparison.InvariantCultureIgnoreCase))
            {
                if (quantity > 13)
                {
                    return false;
                }
            }
            if (color.Equals("blue", StringComparison.InvariantCultureIgnoreCase))
            {
                if (quantity > 14)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
