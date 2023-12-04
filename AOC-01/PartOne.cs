namespace AOC_01
{
    using System;
    using System.IO;

    class PartOne
    {
        public int Handle()
        {
            int sum = 0;
            var lines = File.ReadAllLines("test-input.txt");
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
            var left = this.FindLeft(line);
            var right = this.FindRight(line);
            var num = $"{left}{right}";
            return int.Parse(num);
        }

        private string FindLeft(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (Char.IsDigit(c))
                {
                    return Char.ToString(c);
                }
            }
            throw new Exception("Left not found");
        }

        private string FindRight(string line)
        {
            for (int i = line.Length - 1; i >= 0; i--)
            {
                var c = line[i];
                if (Char.IsDigit(c))
                {
                    return Char.ToString(c);
                }
            }
            throw new Exception("Left not found");
        }
    }
}
