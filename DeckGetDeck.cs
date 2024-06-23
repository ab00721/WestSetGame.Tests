using Microsoft.IdentityModel.Tokens;
using WestSetGame.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WestSetGame.Tests
{
    [TestClass]
    public class DeckGetDeck
    {
        private static readonly int FULL_DECK = 81;

        [TestMethod]
        public void TestShouldCheckGetDeckReturnsFullDeck()
        {
            Deck deck = new Deck();
            Assert.AreEqual(deck.GetDeck().Count, FULL_DECK, "GetDeck should return all cards when deck is full.");
        }

        [TestMethod]
        public void TestShouldCheckGetDeckReturnsLessThanFullDeckIfOneCardIsRemoved()
        {
            Deck deck = new Deck();
            deck.DrawCard();
            Assert.AreEqual(deck.GetDeck().Count, FULL_DECK-1, "GetDeck should return less than all of the cards if deck is not full.");
        }

        [TestMethod]
        public void TestShouldCheckGetDeckCountIncreasesWhenCardsAreReturned()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Assert.AreEqual(deck.Count(), FULL_DECK - 1, "Deck should have one less card that the full deck after drawing one.");
            deck.ReturnToDeck(card);
            Assert.AreEqual(deck.Count(), FULL_DECK, "Deck should have full deck size after one card is drawn and returned.");
            Assert.IsTrue(deck.GetDeck().Contains(card), "GetDeck should include the card that was drawn and returned.");
        }

        [TestMethod]
        public void TestShouldCheckGetDeckReturnsEmptyListIfAllCardsAreRemoved()
        {
            Deck deck = new Deck();
            for (int i = 0; i < FULL_DECK; i++)
            {
                deck.DrawCard();
            }
            Assert.IsTrue(deck.GetDeck().IsNullOrEmpty(), "GetDeck should be empty after all cards are removed");
            Assert.IsNotNull(deck.GetDeck(), "GetDeck should not be null after all careds are removed.");
        }

        [TestMethod]
        public void TestShouldCheckGetDeckContainsCardsOnly()
        {
            Deck deck = new Deck();
            foreach (var card in deck.GetDeck())
            {
                Assert.IsInstanceOfType(card, typeof(Card), "All objects in deck are type Card.");
            }
        }

    }
}
