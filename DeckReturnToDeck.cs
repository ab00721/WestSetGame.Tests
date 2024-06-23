using WestSetGame.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WestSetGame.Tests
{
    [TestClass]
    public class DeckReturnToDeck()
    {
        private static readonly int FULL_DECK = 81;

        [TestMethod]
        public void TestShouldAddCardBackToDeck()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Assert.IsFalse(deck.GetDeck().Contains(card), "Card is not in deck after it is drawn.");
            deck.ReturnToDeck(card);
            Assert.IsTrue(deck.GetDeck().Contains(card), "Card is back in deck after it is returned.");
        }
        
        [TestMethod]
        public void TestShouldThrowErrorIfCardReturnedIsAlreadyInDeck()
        {
            Deck deck = new Deck();
            Card card = deck.GetDeck()[0];
            Assert.IsTrue(deck.GetDeck().Contains(card), "Card is is in deck.");
            try
            {
                deck.ReturnToDeck(card);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Card is already in deck", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowErrorIfCardReturnedIsNull()
        {
            Deck deck = new Deck();
            try
            {
                deck.ReturnToDeck(null);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'card')", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldIncreaseNumberOfCardsInDeck()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            int drawn = deck.Count();
            deck.ReturnToDeck(card);
            int returned = deck.Count();
            Assert.IsTrue(returned > drawn, "Deck count increases after card is returned");
            Assert.AreEqual(drawn + 1, returned, "Deck count is incremented by 1 when returned.");
        }
    }
}
