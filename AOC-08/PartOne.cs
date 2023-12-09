namespace AOC_01
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class PartOne
    {
        public long Handle()
        {
            long num = 0;
            var lines = File.ReadAllLines("input.txt");
            var instructions = lines[0];
            var nodes = this.ReadNodes(lines);

            var key = "AAA";
            int i = 0;
            while (key != "ZZZ")
            {
                if(i>=instructions.Length)
                {
                    i = 0;
                }
                num++;
                var node = nodes[key];
                if (instructions[i] == 'L')
                {
                    key = node.left;
                }
                else
                {
                    key=node.right;
                }
                i++;
            }
            return num;
        }

        private Dictionary<string, (string left, string right)> ReadNodes(string[] lines)
        {
            return lines.Where(x => x.Contains("="))
                .Select(x => x.Replace("(", ""))
                .Select(x => x.Replace(")", ""))
                .Select(x =>
                {
                    var items = x.Split("=");
                    var values = items[1].Split(",");
                    return new KeyValuePair<string, (string left, string right)>(items[0].Trim(), (values[0].Trim(), values[1].Trim()));
                }).ToDictionary();
        }
    }
}
