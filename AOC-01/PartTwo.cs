namespace AOC_01
{
    using System;
    using System.IO;

    class PartTwo
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
            var word = "";
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (Char.IsDigit(c))
                {
                    return Char.ToString(c);
                }
                word += c.ToString();
                var digit = this.IsDigit(word);
                if (digit > 0)
                {
                    return digit.ToString();
                }
            }
            throw new Exception("Left not found");
        }

        private string FindRight(string line)
        {
            var word = "";
            for (int i = line.Length - 1; i >= 0; i--)
            {
                var c = line[i];
                if (Char.IsDigit(c))
                {
                    return Char.ToString(c);
                }
                word = c.ToString() + word;
                var digit = this.IsDigit(word);
                if (digit > 0)
                {
                    return digit.ToString();
                }
            }
            throw new Exception("Right not found");
        }

        private int IsDigit(string word)
        {
            if (word.Contains("one", StringComparison.InvariantCultureIgnoreCase))
            {
                return 1;
            }

            if (word.Contains("two", StringComparison.InvariantCultureIgnoreCase))
            {
                return 2;
            }
            if (word.Contains("three", StringComparison.InvariantCultureIgnoreCase))
            {
                return 3;
            }
            if (word.Contains("four", StringComparison.InvariantCultureIgnoreCase))
            {
                return 4;
            }
            if (word.Contains("five", StringComparison.InvariantCultureIgnoreCase))
            {
                return 5;
            }
            if (word.Contains("six", StringComparison.InvariantCultureIgnoreCase))
            {
                return 6;
            }
            if (word.Contains("seven", StringComparison.InvariantCultureIgnoreCase))
            {
                return 7;
            }
            if (word.Contains("eight", StringComparison.InvariantCultureIgnoreCase))
            {
                return 8;
            }

            if (word.Contains("nine", StringComparison.InvariantCultureIgnoreCase))
            {
                return 9;
            }
            return 0;
        }
    }
}
