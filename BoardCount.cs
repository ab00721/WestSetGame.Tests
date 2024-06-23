using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class BoardCount
    {
        private static readonly int BOARD_SIZE = 12;

        [TestMethod]
        public void TestShouldReturnZeroForEmptyBoard()
        {
            Deck deck = new Deck();
            Board board = new Board();
            Assert.AreEqual(0, board.Count(), "Empty board should have zero cards.");
        }

        [TestMethod]
        public void TestShouldReturnBoardSizeForFullBoard()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                board.AddCard(deck.DrawCard()!, i);
            }
            Assert.AreEqual(BOARD_SIZE, board.Count(), "Full board should have board size of cards.");

        }

        [TestMethod]
        public void TestShouldReturnCorrectCountForPartiallyFilledBoard()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE/2; i++)
            {
                board.AddCard(deck.DrawCard()!, i);
            }
            Assert.AreEqual(BOARD_SIZE/2, board.Count(), "Full board should have board size of cards.");

        }

        [TestMethod]
        public void TestShouldReturnCorrectCountAfterRemovingCards()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                board.AddCard(deck.DrawCard()!, i);
            }
            board.RemoveCard(3);
            board.RemoveCard(4);
            board.RemoveCard(5);

            Assert.AreEqual(BOARD_SIZE - 3, board.Count(), "Full board should have board size of cards.");

        }

        [TestMethod]
        public void TestShouldReturnZeroAfterClearingBoard()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE / 2; i++)
            {
                board.AddCard(deck.DrawCard()!, i);
            }
            board.Clear();
            Assert.AreEqual(0, board.Count(), "Cleared board should have 0 cards.");

        }
    }
}
