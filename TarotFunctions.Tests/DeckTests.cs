namespace TarotFunctions.Tests
{
    public class DeckTests
    {
        private Deck _deck;
        [SetUp]
        public void Setup()
        {
            _deck = new Deck();            
        }

        [Test]
        public void DeckExists()
        {
            Assert.That(_deck.Cards, Has.Count.EqualTo(78));
            foreach(var card in _deck.Cards)
            {
                Assert.That(card.Image, Is.Not.Null);
            }
        }

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(78)]
        public void Spread_Count_ReturnsCorrectCount(int count)
        {
            var draw = _deck.Spread(count).ToList();

            Assert.That(draw, Has.Count.EqualTo(count));
            if(count > 0)
                Assert.That(draw, Is.Not.EqualTo(_deck.Cards.Take(count).ToList()));
        }
    }
}