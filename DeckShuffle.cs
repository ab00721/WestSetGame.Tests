using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class DeckShuffle
    {
        [TestMethod]
        public void TestShouldChangeDeckOrder()
        {
            Deck deck = new Deck();
            List<Card> original = deck.GetDeck().ToList();
            deck.Shuffle();
            List<Card> shuffled = deck.GetDeck().ToList();

            CollectionAssert.AreNotEqual(original, shuffled, "The order should change after shuffling.");
        }

        [TestMethod]
        public void TestShouldNotChangeDeckCount()
        {
            Deck deck = new Deck();
            int original = deck.Count();
            deck.Shuffle();
            int shuffled = deck.Count();

            Assert.AreEqual(original, shuffled, "The number of cards should not change after shuffling.");
        }

        [TestMethod]
        public void TestShouldNotChangeCardsInDeckWhenDeckFull()
        {
            Deck deck = new Deck();
            List<Card> original = deck.GetDeck().ToList();
            deck.Shuffle();
            List<Card> shuffled = deck.GetDeck().ToList();

            CollectionAssert.AreEquivalent(original, shuffled, "The deck should contain the same cards after being shuffled when the deck is full.");
        }

        [TestMethod]
        public void TestShouldNotChangeCardsInDeckWhenDeckNotFull()
        {
            Deck deck = new Deck();
            deck.DrawCard();
            List<Card> afterDraw = deck.GetDeck().ToList();
            deck.Shuffle();
            List<Card> shuffledAfterDraw = deck.GetDeck().ToList();

            CollectionAssert.AreEquivalent(afterDraw, shuffledAfterDraw, "The deck should contain the same cards after being shuffled when the deck is not full.");
        }
    }
}
