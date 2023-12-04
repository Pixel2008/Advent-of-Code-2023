namespace AOC_01
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class PartTwo
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
            var colors = this.GetColors(line);

            var maxRed = this.GetMax("red", colors);
            var maxGreen = this.GetMax("green", colors);
            var maxBlue = this.GetMax("blue", colors);


            return maxRed * maxGreen * maxBlue;
        }


        private List<string> GetColors(string line)
        {
            var items = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
            return items[1].Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private int GetMax(string colorString, List<string> colors)
        {
            int max = 0;
            foreach (var color in colors)
            {
                var items = color.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var n = int.Parse(items[0]);
                if (items[1].Equals(colorString, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (n > max)
                    {
                        max = n;
                    }
                }
            }
            return max;
        }

    }
}
