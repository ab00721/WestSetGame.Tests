using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class DeckDrawCard
    {
        private static readonly int FULL_DECK = 81;

        [TestMethod]
        public void TestShouldReturnCardWhenDeckIsFull()
        {
            Deck deck = new Deck();
            Card? card = deck.DrawCard();
            Assert.IsNotNull(card, "Card drawn from full deck should not be null.");
        }

        [TestMethod]
        public void TestShouldReturnCardWhenDeckIsNotFull()
        {
            Deck deck = new Deck();
            for (int i = 0; i < 10; i++)
            {
                deck.DrawCard();
            }
            Card? card = deck.DrawCard();
            Assert.IsNotNull(card, "Card drawn from parial deck is not null.");
        }

        [TestMethod]
        public void TestShouldReturnNullWhenDeckIsEmpty()
        {
            Deck deck = new Deck();
            for (int i = 0; i < FULL_DECK; i++)
            {
                deck.DrawCard();
            }
            Card? card = deck.DrawCard();
            Assert.IsNull(card, "Card drawn from empty deck is null.");
        }

        [TestMethod]
        public void TestShouldDecreaseDeckCount()
        {
            Deck deck = new Deck();
            int initDeckSize = deck.Count();
            deck.DrawCard();
            int newDeckSize = deck.Count();
            Assert.IsTrue(newDeckSize < initDeckSize);
        }

        [TestMethod]
        public void TestShuoldReturnDifferentCardsInEachDraw()
        {
            Deck deck = new Deck();
            List<Card> cards = new List<Card>();
            for (int i = 0; i < FULL_DECK; i++)
            {
                Card? nextCard = deck.DrawCard(); ;
                Assert.IsNotNull(nextCard, "Next card should not be null.");
                Assert.IsFalse(cards.Contains(nextCard));
                cards.Add(nextCard);
            }
        }

    }
}
