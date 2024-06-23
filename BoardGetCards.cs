using Microsoft.IdentityModel.Tokens;
using WestSetGame.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WestSetGame.Tests
{
    [TestClass]
    public class BoardGetCards
    {
        private static readonly int BOARD_SIZE = 12;

        [TestMethod]
        public void TestShouldReturnEmptyBoardAfterInitialization()
        {
            Board board = new Board();
            Card?[] cards = board.GetCards();
            Assert.AreEqual(BOARD_SIZE, cards.Length, "The board should have the correct size.");
            foreach (var card in cards)
            {
                Assert.IsNull(card, "All spots on the board should be null on initialization.");
            }
        }

        [TestMethod]
        public void TestShouldReturnFullBoardIfBoardFull()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                Card nextCard = deck.DrawCard()!;
                board.AddCard(nextCard, i);
            }
            Assert.AreEqual(board.GetCards().Count(), BOARD_SIZE, "GetCards should have the correct size.");
        }

        [TestMethod]
        public void TestShouldReturnBoardWithNullValuesIfSomeCardsAreRemoved()
        {
            Deck deck = new Deck();
            Board board = new Board();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                Card nextCard = deck.DrawCard()!;
                board.AddCard(nextCard, i);
            }
            board.RemoveCard(3);
            board.RemoveCard(5);
            board.RemoveCard(7);
            Assert.AreEqual(board.GetCards().Count(), BOARD_SIZE, "Board should still be full size with some empty values.");
            Assert.AreEqual(board.Count(), BOARD_SIZE - 3, "Board should still be 3 less than full size after 3 cards are removed.");
            Assert.IsNotNull(board.GetCards()[0], "Card at index 0 was added and not removed");
            Assert.IsNotNull(board.GetCards()[1], "Card at index 1 was added and not removed");
            Assert.IsNotNull(board.GetCards()[2], "Card at index 2 was added and not removed");
            Assert.IsNotNull(board.GetCards()[11], "Card at index 11 was added and not removed");
            Assert.IsNull(board.GetCards()[3], "Card at index 3 was added and removed");
            Assert.IsNull(board.GetCards()[5], "Card at index 5 was added and removed");
            Assert.IsNull(board.GetCards()[7], "Card at index 7 was added and removed");

        }
    }
}
