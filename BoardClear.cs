using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class BoardClear
    {
        private static readonly int BOARD_SIZE = 12;

        [TestMethod]
        public void TestShouldEmptyAFullBoard()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                board.AddCard(deck.DrawCard()!, i);
            }
            board.Clear();
            foreach (var card in board.GetCards())
            {
                Assert.IsNull(card, "All spots on the board should be null after clearing.");
            }
        }

        [TestMethod]
        public void TestShouldEmptyAPartiallyFullBoard()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                board.AddCard(deck.DrawCard()!, i);
            }
            board.RemoveCard(0);
            board.RemoveCard(1);
            board.RemoveCard(2);
            board.Clear();
            foreach (var card in board.GetCards())
            {
                Assert.IsNull(card, "All spots on the board should be null after clearing.");
            }
        }

        [TestMethod]
        public void TestShouldResetTheBoardCount()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                board.AddCard(deck.DrawCard()!, i);
            }
            board.Clear();
            Assert.AreEqual(0, board.Count(), "There should be zero non-null cards after clear.");
        }

        [TestMethod]
        public void TestShouldClearAlreadyEmptyBoard()
        {
            Deck deck = new Deck();
            Board board = new Board();
            board.Clear();
            Assert.AreEqual(0, board.Count(), "There should be zero non-null cards after 'clear' empty board.");
        }
    }
}
