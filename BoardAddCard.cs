using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class BoardAddCard
    {
        private static readonly int BOARD_SIZE = 12;

        [TestMethod]
        public void TestShouldAddCardAtValidIndexAtStartOfArray()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board(); 
            board.AddCard(card, 0);
            Assert.AreEqual(card, board.GetCards()[0], "Card should be added at valid index at start of array.");
        }

        [TestMethod]
        public void TestShouldAddCardAtValidIndexAtEndOfArray()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board();
            board.AddCard(card, BOARD_SIZE-1);
            Assert.AreEqual(card, board.GetCards()[BOARD_SIZE - 1], "Card should be added at valid index at end of array.");
        }

        [TestMethod]
        public void TestShouldAddCardAtValidIndexInMiddleOfArray()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board();
            board.AddCard(card, 5);
            Assert.AreEqual(card, board.GetCards()[5], "Card should be added at valid index in middle of array.");
        }

        [TestMethod]
        public void TestShouldThrowArgumentNullExceptionOnAddNullCard()
        {
            Card? card = null;
            Board board = new Board();
            try
            {
                board.AddCard(card, 0);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null (Parameter 'card')", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowArgumentOutOfRangeExceptionOnIndexTooLow()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board();
            try
            {
                board.AddCard(card, -1);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'The index must be within the range of the board')", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowArgumentOutOfRangeExceptionOnIndexTooHigh()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board();
            try
            {
                board.AddCard(card, BOARD_SIZE);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'The index must be within the range of the board')", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowArgumentExceptionWhenAddCardToIndexWithCard()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                board.AddCard(deck.DrawCard()!, i);
            }

            try
            {
                board.AddCard(deck.DrawCard()!, 0);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Cannot add card to board in spot that is already filled.", ex.Message);
            }
        }

    }
}
