namespace AOC_01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class HandPartOne : IComparable<HandPartOne>
    {
        private string allCards = "23456789TJQKA";
        public string Cards { get; set; }
        public int Bid { get; set; }

        public int CompareTo(HandPartOne other)
        {
            var thisType = this.FindType(this.CheckCards(this.Cards));
            var otherType = this.FindType(this.CheckCards(other.Cards));
            if(thisType!=otherType)
            {
                return thisType.CompareTo(otherType);
            }
            return this.CompareCards(this.Cards, other.Cards);
        }

        private Dictionary<char, int> CheckCards(string cards)
        {
            var dict = new Dictionary<char, int>();
            foreach (var card in cards)
            {
                if (!dict.ContainsKey(card))
                {
                    dict.Add(card, 0);
                }
                dict[card]++;
            }
            return dict;
        }
        private int FindType(Dictionary<char, int> dict)
        {
            if(dict.Count==1)
            {
                return 7;
            }
            if(dict.Count==2)
            {
                if (dict.Values.Any(x => x == 4))
                {
                    return 6;
                }
                return 5;
            }
            if(dict.Count==3)
            {
                if(dict.Values.Any(x=>x == 3))
                {
                    return 4;
                }
                return 3;
            }
            if(dict.Count==4)
            {
                return 2;
            }
            return 1;
        }
        private int CompareCards(string cardsA, string cardsB)
        {
            for(int i=0;i<cardsA.Length;i++)
            {
                var cardA = this.allCards.IndexOf(cardsA[i]);
                var cardB = this.allCards.IndexOf(cardsB[i]);
                var cmp = cardA.CompareTo(cardB);
                if(cmp!=0)
                {
                    return cmp;
                }
            }
            return 0;
        }
    }
}
