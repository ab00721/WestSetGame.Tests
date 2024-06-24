using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class GameGetPoints
    {
        [TestMethod]
        public void TestShouldInitializePointsToZero()
        {
            Game game = new Game();
            int points = game.GetPoints();
            Assert.AreEqual(0, points);
        }

        [TestMethod]
        public void TestShouldIncreasePointsAfterValidSet()
        {
            Game game = new Game();
            Card?[] board = game.GetBoard();
            List<Card> validSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Red", "Diamond", 1, "Striped"),
                new Card("Red", "Diamond", 1, "Open"),
            };

            for (int i = 0; i < validSet.Count; i++)
            {
                board[i] = validSet[i];
            }

            int[] set = new int[] { 0, 1, 2 };

            bool result = game.TakeSet(set);

            Assert.IsTrue(result);
            Assert.AreEqual(1, game.GetPoints());

        }

        [TestMethod]
        public void TestShouldAccumulatePointsAfterMultipleValidSet()
        {
            Game game = new Game();
            Card?[] board = game.GetBoard();
            List<Card> validSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Red", "Diamond", 1, "Striped"),
                new Card("Red", "Diamond", 1, "Open"),

                new Card("Green", "Diamond", 1, "Solid"),
                new Card("Green", "Diamond", 1, "Striped"),
                new Card("Green", "Diamond", 1, "Open"),

                new Card("Purple", "Diamond", 1, "Solid"),
                new Card("Purple", "Diamond", 1, "Striped"),
                new Card("Purple", "Diamond", 1, "Open"),
            };

            for (int i = 0; i < validSet.Count; i++)
            {
                board[i] = validSet[i];
            }

            int[] set1 = new int[] { 0, 1, 2 };
            bool result1 = game.TakeSet(set1);
            Assert.IsTrue(result1);
            Assert.AreEqual(1, game.GetPoints());

            int[] set2 = new int[] { 3, 4, 5 };
            bool result2 = game.TakeSet(set2);
            Assert.IsTrue(result2);
            Assert.AreEqual(2, game.GetPoints());

            int[] set3 = new int[] { 6, 7, 8 };
            bool result3 = game.TakeSet(set3);
            Assert.IsTrue(result3);
            Assert.AreEqual(3, game.GetPoints());
        }

        [TestMethod]
        public void TestShouldNotIncreasePointsAfterInvalidSet()
        {
            Game game = new Game();
            Card?[] board = game.GetBoard();
            List<Card> invalidSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Green", "Diamond", 1, "Solid"),
                new Card("Red", "Diamond", 2, "Solid"),
            };

            for (int i = 0; i < invalidSet.Count; i++)
            {
                board[i] = invalidSet[i];
            }

            int[] set = new int[] { 0, 1, 2 };

            bool result = game.TakeSet(set);

            Assert.IsFalse(result);
            Assert.AreEqual(0, game.GetPoints());

        }

        [TestMethod]
        public void TestShouldKeepPointsAfterReplaceBoard()
        {
            Game game = new Game();
            Card?[] board = game.GetBoard();
            List<Card> validSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Red", "Diamond", 1, "Striped"),
                new Card("Red", "Diamond", 1, "Open"),
            };

            for (int i = 0; i < validSet.Count; i++)
            {
                board[i] = validSet[i];
            }

            int[] set = new int[] { 0, 1, 2 };

            bool result = game.TakeSet(set);
            Assert.IsTrue(result);

            game.ReplaceBoard();

            Assert.AreEqual(1, game.GetPoints());
        }

        [TestMethod]
        public void TestShouldResePointsWhenResetBoard()
        {
            Game game = new Game();
            Card?[] board = game.GetBoard();
            List<Card> validSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Red", "Diamond", 1, "Striped"),
                new Card("Red", "Diamond", 1, "Open"),
            };

            for (int i = 0; i < validSet.Count; i++)
            {
                board[i] = validSet[i];
            }

            int[] set = new int[] { 0, 1, 2 };

            bool result = game.TakeSet(set);
            Assert.IsTrue(result);

            game = Game.NewGame();

            Assert.AreEqual(0, game.GetPoints());
        }

    }
}
