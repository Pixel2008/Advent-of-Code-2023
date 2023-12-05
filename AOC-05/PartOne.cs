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


            var seeds = this.ReadSeeds(lines);

            foreach (var seed in seeds)
            {
                seed.Soil = this.FindFromSection("seed-to-soil map", seed.SeedId, lines);
                seed.Fertilizer = this.FindFromSection("soil-to-fertilizer map", seed.Soil, lines);
                seed.Water = this.FindFromSection("fertilizer-to-water map", seed.Fertilizer, lines);
                seed.Light = this.FindFromSection("water-to-light map", seed.Water, lines);
                seed.Temperature = this.FindFromSection("light-to-temperature map", seed.Light, lines);
                seed.Humidity = this.FindFromSection("temperature-to-humidity map", seed.Temperature, lines);
                seed.Location = this.FindFromSection("humidity-to-location map", seed.Humidity, lines);

            }

            num = seeds.Min(x => x.Location);

            return num;
        }

        private List<Seed> ReadSeeds(string[] lines)
        {
            var line = lines[0];
            var items = line.Split(":");
            return items[1].Trim()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => new Seed() { SeedId = long.Parse(x) })
                        .ToList();
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
        private long FindFromSection(string section, long value, string[] lines)
        {
            var ranges = this.GetLinesForSection(section, lines);
            foreach (var range in ranges)
            {
                var items = range.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                var dest = items[0];
                var src = items[1];
                var quantity = items[2];

                if (value >= src && value <= src + quantity)
                {
                    return value + (dest - src);
                }

            }
            return value;
        }
    }
}
