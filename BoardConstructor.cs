using Microsoft.IdentityModel.Tokens;
using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class BoardConstructor
    {
        private readonly static int BOARD_SIZE = 12;

        [TestMethod]
        public void TestShouldBeFullBoardSize()
        {
            Board board = new Board();
            Assert.AreEqual(BOARD_SIZE, board.GetCards().Count(), "The board should be the full size on initialization");
        }

        [TestMethod]
        public void TestShouldNotBeNullAfterInitialziation()
        {
            Board board = new Board();
            Assert.IsNotNull(board.GetCards(), "The BOARD_SIZE board array should not be null.");
            
        }

        [TestMethod]
        public void TestShouldHaveNullCardsOnInitialization()
        {
            Board board = new Board();

            foreach (Card? card in board.GetCards())
            {
                Assert.IsNull(card, "Each item in the BOARD_SIZE board array should be null.");
            }
        }
    }
}
