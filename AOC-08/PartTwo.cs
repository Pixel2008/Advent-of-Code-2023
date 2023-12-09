namespace AOC_01
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class PartTwo
    {
        public long Handle()
        {
            long num = 1;
            var lines = File.ReadAllLines("input.txt");
            var instructions = lines[0];
            var nodes = this.ReadNodes(lines);
            var currentNodes = nodes.Keys.Where(x => x.EndsWith("A")).Select(x => new KeyValuePair<string, int>(x, 0)).ToDictionary();


            foreach (var n in currentNodes)
            {
                int i = 0;
                var key = n.Key;
                while (!key.EndsWith("Z"))
                {
                    if (i >= instructions.Length)
                    {
                        i = 0;
                    }
                    currentNodes[n.Key]++;
                    var node = nodes[key];
                    if (instructions[i] == 'L')
                    {
                        key = node.left;
                    }
                    else
                    {
                        key = node.right;
                    }
                    i++;
                }
                
            }
            num = lcm_of_array_elements(currentNodes.Values.ToArray());
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

        public static long lcm_of_array_elements(int[] element_array)
        {
            long lcm_of_array_elements = 1;
            int divisor = 2;

            while (true)
            {

                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < element_array.Length; i++)
                {

                    // lcm_of_array_elements (n1, n2, ... 0) = 0.
                    // For negative number we convert into
                    // positive and calculate lcm_of_array_elements.
                    if (element_array[i] == 0)
                    {
                        return 0;
                    }
                    else if (element_array[i] < 0)
                    {
                        element_array[i] = element_array[i] * (-1);
                    }
                    if (element_array[i] == 1)
                    {
                        counter++;
                    }

                    // Divide element_array by devisor if complete
                    // division i.e. without remainder then replace
                    // number with quotient; used for find next factor
                    if (element_array[i] % divisor == 0)
                    {
                        divisible = true;
                        element_array[i] = element_array[i] / divisor;
                    }
                }

                // If divisor able to completely divide any number
                // from array multiply with lcm_of_array_elements
                // and store into lcm_of_array_elements and continue
                // to same divisor for next factor finding.
                // else increment divisor
                if (divisible)
                {
                    lcm_of_array_elements = lcm_of_array_elements * divisor;
                }
                else
                {
                    divisor++;
                }

                // Check if all element_array is 1 indicate 
                // we found all factors and terminate while loop.
                if (counter == element_array.Length)
                {
                    return lcm_of_array_elements;
                }
            }
        }

    }
}
