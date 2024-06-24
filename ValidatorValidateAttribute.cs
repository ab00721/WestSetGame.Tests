using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using WestSetGame.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WestSetGame.Tests
{
    [TestClass]
    public class ValidatorValidateAttribute
    {
        private Validator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new Validator();
        }

        [TestMethod]
        public void TestShouldValidateAllSameInts()
        {
            List<int> attribute = new List<int> { 1, 1, 1 };

            bool result = validator.ValidateAttribute(attribute);

            Assert.IsTrue(result, "All elements in the list are the same.");
        }

        [TestMethod]
        public void TestShouldValidateAllDifferentInts()
        {
            List<int> attribute = new List<int> { 1, 2, 3 };

            bool result = validator.ValidateAttribute(attribute);

            Assert.IsTrue(result, "All elements in the list are different.");
        }

        [TestMethod]
        public void TestShouldNotValidateInts()
        {
            List<int> attribute = new List<int> { 1, 1, 2 };

            bool result = validator.ValidateAttribute(attribute);

            Assert.IsFalse(result, "Attributes are not valid becuase some are the same and some are different");
        }

        [TestMethod]
        public void TestShouldValidateAllSameStrings()
        {
            List<string> attribute = new List<string> { "Red", "Red", "Red" };

            bool result = validator.ValidateAttribute(attribute);

            Assert.IsTrue(result, "All elements in the list are the same.");
        }

        [TestMethod]
        public void TestShouldValidateAllDifferentStrings()
        {
            List<string> attribute = new List<string> { "Red", "Green", "Purple" };

            bool result = validator.ValidateAttribute(attribute);

            Assert.IsTrue(result, "All elements in the list are different.");
        }

        [TestMethod]
        public void TestShouldNotValidateStrings()
        {
            List<string> attribute = new List<string> { "Red", "Green", "Red" };

            bool result = validator.ValidateAttribute(attribute);

            Assert.IsFalse(result, "Attributes are not valid becuase some are the same and some are different");
        }
    }
}
