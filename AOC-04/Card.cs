namespace AOC_01
{
    internal class Card
    {
        public int CardId { get; set; }
        public int[] WinningNumbers { get; set; }
        public int[] Numbers { get; set; }
        public int Founds { get; set; }
        public int Points { get; set; }
        public int NumberOfCopies { get; set; }

        internal static Card Create(int cardId, int[] winningCards, int[] allCards, int existed, int points)
        {
            return new Card
            {
                CardId = cardId,
                WinningNumbers = winningCards,
                Numbers = allCards,
                Founds = existed,
                Points = points,
                NumberOfCopies = 1
            };
        }
    }
}
