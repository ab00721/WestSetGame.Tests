using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class CardConstructor
    {

        private static readonly string[] ColorsValid = { "Red", "Green", "Purple" };
        private static readonly string[] ShapesValid = { "Diamond", "Oval", "Squiggle" };
        private static readonly int[] NumbersValid = { 1, 2, 3 };
        private static readonly string[] FillsValid = { "Solid", "Striped", "Open" };

        string color = "Green";
        string shape = "Diamond";
        int number = 1;
        string fill = "Solid";


        [TestMethod]
        public void TestShouldSetCardAttributes()
        {
            Card card = new Card(color, shape, number, fill);

            Assert.AreEqual(color, card.Color, "Color attrubute not set correctly");
            Assert.AreEqual(shape, card.Shape, "Shape attrubute not set correctly");
            Assert.AreEqual(number, card.Number, "Number attrubute not set correctly");
            Assert.AreEqual(fill, card.Fill, "Fill attrubute not set correctly");
        }

        [TestMethod]
        public void TestShouldCheckAllValidCombinations()
        {
            foreach (string color in ColorsValid)
            {
                foreach (string shape in ShapesValid)
                {
                    foreach (int number in NumbersValid)
                    {
                        foreach (string fill in FillsValid)
                        {
                            Card card = new Card(color, shape, number, fill);

                            Assert.AreEqual(color, card.Color, "Color attrubute not set correctly");
                            Assert.AreEqual(shape, card.Shape, "Shape attrubute not set correctly");
                            Assert.AreEqual(number, card.Number, "Number attrubute not set correctly");
                            Assert.AreEqual(fill, card.Fill, "Fill attrubute not set correctly");
                        }
                    }
                }
            }

        }

        [TestMethod]
        public void TestShouldThrowArgumentNullExceptionForNullColor()
        {
            try
            {
                new Card(null, shape, number, fill);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'color')", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowArgumentNullExceptionForNullShape()
        {
            try
            {
                new Card(color, null, number, fill);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'shape')", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowArgumentNullExceptionForNullFill()
        {
            try
            {
                new Card(color, shape, number, null);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'fill')", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowArgumentExceptionForInvalidNumbers()
        {
            try
            {
                new Card(color, shape, 0, fill);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid number. Valid numbers include 1, 2, 3.", ex.Message);
            }

            try
            {
                new Card(color, shape, 4, fill);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid number. Valid numbers include 1, 2, 3.", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowArgumentExceptionForInvalidColor()
        {
            try
            {
                Card CardWithInvalidColor = new Card("Blue", shape, number, fill);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid color. Valid colors include Red, Green, Purple.", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowArgumentExceptionForInvalidShape()
        {
            try
            {
                Card CardWithInvalidShape = new Card(color, "Circle", number, fill);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid shape. Valid shapes include Diamond, Oval, Squiggle.", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldThrowArgumentExceptionForInvalidFill()
        {
            try
            {
                Card CardWithInvalidFill = new Card(color, shape, number, "Empty");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid fill. Valid fills include Solid, Striped, Open.", ex.Message);
            }
        }
    }
}