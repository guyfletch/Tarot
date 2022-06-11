using System.Text.Json;


namespace TarotFunctions
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public Card Back { get; set; }
        private Random random = new Random();

        public Deck()
        {
            Cards = new List<Card>();
            var names = (JsonSerializer.Deserialize<string[]>(File.ReadAllText("./cards.json")) ?? Array.Empty<string>()).ToList();
            if (names.IsNullOrEmpty()) throw new NotSupportedException("Card definition cards.json not found");
            foreach(var name in names)
            {
                Cards.Add(new Card(name));
            }
            Back = new Card("Back");
        }

        public IEnumerable<Card> Spread(int count)
        {
            var cardIds = new List<int>();
            while(cardIds.Count < count)
            {
                var next = random.Next(Cards.Count);
                if (!cardIds.Contains(next)) cardIds.Add(next);
            };
            var cards = new List<Card>();
            foreach(var id in cardIds)
            {
                cards.Add(Cards[id]);
                cards.Last().Reversed = random.Next(3) == 0;
            }
            return cards;
        }
    }
}