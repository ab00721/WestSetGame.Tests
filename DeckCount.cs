using Microsoft.IdentityModel.Tokens;
using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class DeckCount
    {
        private static readonly int FULL_DECK = 81;

        [TestMethod]
        public void TestCountShouldReturnFullDeckSizeWhenDeckFull()
        {
            Deck deck = new Deck();
            Assert.AreEqual(deck.Count(), FULL_DECK, "Count should return full deck size when deck is full.");
        }

        [TestMethod]
        public void TestCountShouldReturnOneLessThenDeckSizeWhenOneCardDrawn()
        {
            Deck deck = new Deck();
            deck.DrawCard();
            Assert.AreEqual(deck.Count(), FULL_DECK-1, "Count should return one less than full deck size when one card has been drawn.");
        }

        [TestMethod]
        public void TestCountShouldReturnCorrectDeckSizeWhenManyCardsAreDrawn()
        {
            Deck deck = new Deck();
            for (int i = 0; i < 10; i++)
            {
                deck.DrawCard();
            }
            Assert.AreEqual(deck.Count(), FULL_DECK - 10, "Count should return correct deck size when many cards have been drawn.");
        }

        [TestMethod]
        public void TestCountShouldReturnZeroWhenAllCardsAreDrawn()
        {
            Deck deck = new Deck();
            for (int i = 0; i < FULL_DECK; i++)
            {
                deck.DrawCard();
            }
            Assert.AreEqual(deck.Count(), 0, "Count should return zero when all cards have been drawn.");
        }

    }
}
