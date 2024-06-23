using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class DeckConstructor
    {
        private readonly static int FULL_DECK = 81;

        [TestMethod]
        public void TestDeckShouldNotBeNull()
        {
            Deck deck = new Deck();
            Assert.IsNotNull(deck, "The deck should not be null.");
        }

        [TestMethod]
        public void TestDeckShouldBeFull()
        {
            Deck deck = new Deck();
            Assert.AreEqual(FULL_DECK, deck.Count(), "The deck should be full.");
        }

        [TestMethod]
        public void TestDeckShouldHaveAllDistinctCards()
        {
            Deck deck = new Deck();
            Assert.AreEqual(FULL_DECK, deck.GetDeck().Distinct().Count(), "All cards in the deck should be distinct.");
        }
    }
}
