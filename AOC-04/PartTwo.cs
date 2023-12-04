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

            var cards = new List<Card>();

            foreach (var line in lines)
            {
                var cardId = this.GetCardId(line);
                var winningCards = this.GetWinningsCards(line);
                var allCards = this.GetCards(line);
                var existed = allCards.Count(x => winningCards.Contains(x));
                var points = this.CountPoints(existed);

                cards.Add(Card.Create(cardId, winningCards, allCards, existed, points));
            }

            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];
                int repeat = card.NumberOfCopies;
                while (repeat-- > 0)
                {
                    int max = i + 1 + card.Founds;
                    if (max >= cards.Count)
                    {
                        max = cards.Count;
                    }
                    for (int j = i + 1; j < max; j++)
                    {
                        cards[j].NumberOfCopies++;
                    }
                }
            }

            sum = cards.Sum(x => x.NumberOfCopies);

            return sum;
        }

        private int GetCardId(string line)
        {
            var items = line.Split(new[] { ":", "|" }, StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(items[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
        }

        private int[] GetWinningsCards(string line)
        {
            var items = line.Split(new[] { ":", "|" }, StringSplitOptions.RemoveEmptyEntries);
            return items[1]
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => int.Parse(x))
                     .ToArray();
        }

        private int[] GetCards(string line)
        {
            var items = line.Split(new[] { ":", "|" }, StringSplitOptions.RemoveEmptyEntries);
            return items[2]
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => int.Parse(x))
                     .ToArray();
        }

        private int CountPoints(int num)
        {
            if (num == 0) return 0;
            int c = 1;
            for (int i = 0; i < num - 1; i++)
            {
                c *= 2;
            }
            return c;
        }
    }
}

