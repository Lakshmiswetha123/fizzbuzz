using NUnit.Framework;
using System.Collections.Generic;

namespace TwistedFizzBuzz.Tests
{
    [TestFixture]
    public class TwistedFizzBuzzTests
    {
        private TwistedFizzBuzz _twistedFizzBuzz;

        [SetUp]
        public void Setup()
        {
            // Create a new instance of TwistedFizzBuzz before each test
            _twistedFizzBuzz = new TwistedFizzBuzz();
        }

        [Test]
        public void GetFizzBuzz_Returns_Number_For_Non_Multiples()
        {
            // Arrange
            int num = 7;

            // Act
            string result = _twistedFizzBuzz.GetFizzBuzz(num);

            // Assert
            Assert.AreEqual(num.ToString(), result);
        }

        [Test]
        public void GetFizzBuzz_Returns_FizzBuzz_For_Multiples_Of_Three_And_Five()
        {
            // Arrange
            int num = 15;

            // Act
            string result = _twistedFizzBuzz.GetFizzBuzz(num);

            // Assert
            Assert.AreEqual("FizzBuzz", result);
        }

        [Test]
        public void GetFizzBuzz_Returns_Correct_Tokens_For_Custom_Tokens()
        {
            // Arrange
            int num = 21;
            var tokens = new List<FizzBuzzToken>
            {
                new FizzBuzzToken { Multiple = 7, Word = "Poem" },
                new FizzBuzzToken { Multiple = 3, Word = "College" },
            };
            var expected = "PoemCollege";

            // Act
            string result = _twistedFizzBuzz.GetFizzBuzz(num, num, tokens);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetFizzBuzzFromAPI_Returns_Valid_Result()
        {
            // Act
            string result = _twistedFizzBuzz.GetFizzBuzzFromAPI().Result;

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
    }
}
