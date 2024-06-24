using Microsoft.VisualStudio.TestTools.UnitTesting;
using WestSetGame.Models;

namespace WestSetGame.Tests
{
    [TestClass]
    public class ValidatorValidateSet
    {
        private Validator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new Validator();
        }

        [TestMethod]
        public void TestValidateSetOneAttributeAllDifferentAndTheRestAllTheSame()
        {
            List<Card> validSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Red", "Diamond", 1, "Striped"),
                new Card("Red", "Diamond", 1, "Open"),
            };

            bool result = validator.ValidateSet(validSet);

            Assert.IsTrue(result, "Set is valid.");
        }

        [TestMethod]
        public void TestValidateSetTwoAttributesAllDifferentTwoAllTheSame()
        {
            List<Card> validSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Red", "Diamond", 2, "Striped"),
                new Card("Red", "Diamond", 3, "Open"),
            };

            bool result = validator.ValidateSet(validSet);

            Assert.IsTrue(result, "Set is valid.");
        }

        [TestMethod]
        public void TestValidateSetThreeAttributesAllDifferentOneAllTheSame()
        {
            List<Card> validSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Red", "Oval", 2, "Striped"),
                new Card("Red", "Squiggle", 3, "Open"),
            };

            bool result = validator.ValidateSet(validSet);

            Assert.IsTrue(result, "Set is valid.");
        }

        [TestMethod]
        public void TestValidateSetAllFourAttributesAllDifferent()
        {
            List<Card> validSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Green", "Oval", 2, "Striped"),
                new Card("Purple", "Squiggle", 3, "Open"),
            };

            bool result = validator.ValidateSet(validSet);

            Assert.IsTrue(result, "Set is valid.");
        }

        [TestMethod]
        public void TestShouldNotValidateSetWhereColorInvalid()
        {
            List<Card> invalidSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Red", "Oval", 2, "Striped"),
                new Card("Purple", "Squiggle", 3, "Open"),
            };

            bool result = validator.ValidateSet(invalidSet);

            Assert.IsFalse(result, "Set is not valid due to color.");
        }

        [TestMethod]
        public void TestShouldNotValidateSetWhereShapeInvalid()
        {
            List<Card> invalidSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Green", "Oval", 2, "Striped"),
                new Card("Purple", "Oval", 3, "Open"),
            };

            bool result = validator.ValidateSet(invalidSet);

            Assert.IsFalse(result, "Set is not valid due to shape.");
        }

        [TestMethod]
        public void TestShouldNotValidateSetWhereNumberInvalid()
        {
            List<Card> invalidSet = new List<Card>
            {
                new Card("Red", "Diamond", 3, "Solid"),
                new Card("Green", "Oval", 2, "Striped"),
                new Card("Purple", "Squiggle", 3, "Open"),
            };

            bool result = validator.ValidateSet(invalidSet);

            Assert.IsFalse(result, "Set is not valid due to number.");
        }

        [TestMethod]
        public void TestShouldNotValidateSetWhereFillInvalid()
        {
            List<Card> invalidSet = new List<Card>
            {
                new Card("Red", "Diamond", 1, "Solid"),
                new Card("Green", "Oval", 2, "Open"),
                new Card("Purple", "Squiggle", 3, "Open"),
            };

            bool result = validator.ValidateSet(invalidSet);

            Assert.IsFalse(result, "Set is not valid due to fill.");
        }

        [TestMethod]
        public void TestShouldNotValidateSetWhereMultipleInvalidAttributes()
        {
            List<Card> invalidSet = new List<Card>
            {
                new Card("Red", "Diamond", 3, "Solid"),
                new Card("Green", "Oval", 2, "Open"),
                new Card("Purple", "Squiggle", 3, "Open"),
            };

            bool result = validator.ValidateSet(invalidSet);

            Assert.IsFalse(result, "Set is not valid due to number and fill.");
        }

        [TestMethod]
        public void TestShouldNotValidateSetWhereListIsNull()
        {
            List<Card> invalidSet = null;
            try
            {
                validator.ValidateSet(invalidSet);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'The set to validate can not be null or empty')", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldNotValidateSetWhereListIsEmpty()
        {
            List<Card> invalidSet = new List<Card>();
            try
            {
                validator.ValidateSet(invalidSet);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'The set to validate can not be null or empty')", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldNotValidateSetWhenNotEnoughCards()
        {
            List<Card> invalidSet = new List<Card>
            {
                new Card("Red", "Diamond", 3, "Solid"),
                new Card("Green", "Oval", 2, "Open"),
            };
            try
            {
                validator.ValidateSet(invalidSet);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The set to validate can not be null or empty", ex.Message);
            }
        }

        [TestMethod]
        public void TestShouldNotValidateSetWhenTooManyCards()
        {
            List<Card> invalidSet = new List<Card>
            {
                new Card("Red", "Oval", 1, "Solid"),
                new Card("Red", "Oval", 2, "Solid"),
                new Card("Red", "Oval", 3, "Solid"),
                new Card("Red", "Oval", 1, "Solid"),
            };
            try
            {
                validator.ValidateSet(invalidSet);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The set to validate can not be null or empty", ex.Message);
            }

        }
    }
}
