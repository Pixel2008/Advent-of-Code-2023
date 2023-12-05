namespace AOC_01
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    class PartTwo
    {
        public long Handle()
        {
            var locker = new object();
            long num = -1;
            var lines = File.ReadAllLines("test-input.txt");

            var seed2soil = this.ReadSection("seed-to-soil map", lines);
            var soil2fertilizer = this.ReadSection("soil-to-fertilizer map", lines);
            var fertilizer2water = this.ReadSection("fertilizer-to-water map", lines);
            var water2light = this.ReadSection("water-to-light map", lines);
            var light2temperature = this.ReadSection("light-to-temperature map", lines);
            var temperature2humidity = this.ReadSection("temperature-to-humidity map", lines);
            var humidity2location = this.ReadSection("humidity-to-location map", lines);
             
            var seeds = this.ReadSeeds(lines);
            int counter = 0;
             
            var options = new ParallelOptions { CancellationToken = CancellationToken.None, MaxDegreeOfParallelism = Environment.ProcessorCount * 2 };

            Parallel.ForEachAsync(seeds, options, async (seed, token) =>
            {
                counter++;
                long from = seed.Key;
                long quantity = seed.Value;

                Console.WriteLine($"Checking {counter} from {from} quantity={quantity}");
                for (long i = from; i < from + quantity - 1; i++)
                {
                    var soil = this.FindFromSection(seed2soil, i);
                    var fertilizer = this.FindFromSection(soil2fertilizer, soil);
                    var water = this.FindFromSection(fertilizer2water, fertilizer);
                    var light = this.FindFromSection(water2light, water);
                    var temperature = this.FindFromSection(light2temperature, light);
                    var humidity = this.FindFromSection(temperature2humidity, temperature);
                    var location = this.FindFromSection(humidity2location, humidity);

                    lock (locker)
                    {
                        if (num == -1 || num > location)
                        {
                            num = location;
                        }
                    }

                }
                Console.WriteLine($"Checking {counter} Done");
            }).Wait();

            return num;
        }

        private List<SectionValue> ReadSection(string section, string[] lines)
        {
            var items = this.GetLinesForSection(section, lines);
            var list = new List<SectionValue>();
            foreach (var item in items)
            {
                var it = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                list.Add(new SectionValue
                {
                    Destination = long.Parse(it[0]),
                    Source = long.Parse(it[1]),
                    Range = long.Parse(it[2])
                });
            }
            return list;
        }

        private Dictionary<long, long> ReadSeeds(string[] lines)
        {
            var line = lines[0];
            var items = line.Split(":");
            var allItems = items[1].Trim()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse).ToList();

            var pairs = new Dictionary<long, long>();
            int i = 0;
            while (i < allItems.Count)
            {
                long from = allItems[i];
                long quantity = allItems[i + 1];
                pairs.Add(from, quantity);
                i += 2;
            }


            return pairs;
        }
        private List<string> GetLinesForSection(string section, string[] lines)
        {
            var list = new List<string>();
            bool properSection = false;
            foreach (var line in lines)
            {
                if (line.StartsWith(section))
                {
                    properSection = true;
                    continue;
                }
                if (string.IsNullOrWhiteSpace(line))
                {
                    properSection = false;
                    continue;
                }
                if (properSection)
                {
                    list.Add(line);
                }
            }
            return list;
        }
        private long FindFromSection(List<SectionValue> ranges, long value)
        {
            var range = ranges.Where(x => value >= x.Source && value < (x.Source + x.Range)).FirstOrDefault();
            if (range != null)
            {
                return value + (range.Destination - range.Source);
            }
            return value;

        }
    }
}
