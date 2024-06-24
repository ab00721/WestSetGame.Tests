using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class GameConstructor
    {

        [TestMethod]
        public void TestShouldInitializeBoard()
        {
            Game game = new Game();

            Card[]? board = game.GetBoard();
            Assert.IsNotNull(board, "Board should not be null on game initialization.");
            Assert.AreEqual(12, board.Length, "Board should initialize to 12 cards on game initialization");
        }

        [TestMethod]
        public void TestShouldInitializePointsToZero()
        {
            Game game = new Game();
            Assert.AreEqual(0, game.GetPoints(), "Deck should initialize points to 0.");
        }


    }
}