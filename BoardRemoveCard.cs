using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class BoardRemoveCard
    {
        private static readonly int BOARD_SIZE = 12;

        [TestMethod]
        public void TestShouldAddCardAtValidIndexAtStartOfArray()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board();
            board.AddCard(card, 0);
            Assert.AreEqual(card, board.GetCards()[0], "The index of where the card was added has card before removing.");
            board.RemoveCard(0);
            Assert.IsNull(board.GetCards()[0], "The index of where the card was removed is null after removing.");
        }

        [TestMethod]
        public void TestShouldRemoveCardAtValidIndexAtEndOfArray()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board();
            board.AddCard(card, BOARD_SIZE-1);
            Assert.AreEqual(card, board.GetCards()[BOARD_SIZE - 1], "The index of where the card was added has card before removing.");
            board.RemoveCard(BOARD_SIZE - 1);
            Assert.IsNull(board.GetCards()[BOARD_SIZE - 1], "The index of where the card was removed is null after removing.");
        }

        [TestMethod]
        public void TestShouldRemoveCardAtValidIndexInMiddleOfArray()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board();
            board.AddCard(card, 5);
            Assert.AreEqual(card, board.GetCards()[5], "The index of where the card was added has card before removing.");
            board.RemoveCard(5);
            Assert.IsNull(board.GetCards()[5], "The index of where the card was removed is null after removing.");
        }

        [TestMethod]
        public void TestShouldThrowArgumentNullExceptionOnRemoveNullCard()
        {
            Board board = new Board();
            try
            {
                board.RemoveCard(0);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Cannot remove a null card.", ex.ParamName);
            }
        }

        [TestMethod]
        public void TestShouldThrowIndexOutOfRangeExceptionOnIndexTooLow()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board();
            try
            {
                board.RemoveCard(-1);
                Assert.Fail("An exception should have been thrown");
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Index was outside the bounds of the array.", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowIndexOutOfRangeExceptionOnIndexTooHigh()
        {
            Deck deck = new Deck();
            Card card = deck.DrawCard()!;
            Board board = new Board();
            try
            {
                board.RemoveCard(BOARD_SIZE);
                Assert.Fail("An exception should have been thrown");
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Index was outside the bounds of the array.", ex.Message);
            }
        }

    }
}
