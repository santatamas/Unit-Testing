using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        ///<summary>
        /// This is the summary
        ///</summary>
        [Test]
        public void Test_Add_Should_ReturnZero_When_CalledWithEmptyString()
        {
            // Arrange
            StringCalculator calc = new StringCalculator();

            // Act
            var result = calc.Add(String.Empty);

            // Assert
            Assert.AreEqual(0, result, "Result should be zero!");
        }

        ///<summary>
        /// this is the summary
        ///</summary>
        [Test]
        public void Test_Add_Should_ReturnSingleNumber_When_CalledWithSingleNumber()
        {
            // Arrange
            StringCalculator calc = new StringCalculator();

            // Act
            var result = calc.Add("1");

            // Assert
            Assert.AreEqual(1, result, "Result should be 1.");
        }

        ///<summary>
        /// Summary
        ///</summary>
        [Test]
        public void Test_Add_Should_ReturnSum_When_CalledWithTwoNumbers()
        {
            // Arrange
            StringCalculator calc = new StringCalculator();

            // Act
            var result = calc.Add("1,2");

            // Assert
            Assert.AreEqual(3, result, "Result should be 3.");
        }

        ///<summary>
        /// Summary
        ///</summary>
        [Test]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("4,5,6,100", 115)]
        public void Test_Add_Should_ReturnSum_When_CalledWithMultipleNumbers(string input, int expectedResult)
        {
            // Arrange
            StringCalculator calc = new StringCalculator();

            // Act
            var result = calc.Add(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        ///<summary>
        /// Summary
        ///</summary>
        [Test]
        public void Test_Add_Should_ReturnSum_When_CalledWithInputWithNewLineSeparator()
        {
            // Arrange
            StringCalculator calc = new StringCalculator();

            // Act
            var result = calc.Add("4\n5\n6");

            // Assert
            Assert.AreEqual(15, result);
        }

        ///<summary>
        /// Summary
        ///</summary>
        [Test]
        public void Test_Add_Should_ReturnSum_When_CalledWithInputWithMixesSeparators()
        {
            // Arrange
            StringCalculator calc = new StringCalculator();

            // Act
            var result = calc.Add("4,5\n6");

            // Assert
            Assert.AreEqual(15, result);
        }

        ///<summary>
        /// Summary
        ///</summary>
        [Test]
        public void Test_Add_Should_ReturnSum_When_CalledWithInputContainingCustomSeparator()
        {
            // Arrange
            StringCalculator calc = new StringCalculator();

            // Act
            var result = calc.Add("//plus\n1plus2plus3");

            // Assert
            Assert.AreEqual(6, result);
        }

        ///<summary>
        /// Summary
        ///</summary>
        [Test]
        public void Test_Add_Should_ThrowException_When_CalledWithNegativeNumbers()
        {
            // Arrange
            StringCalculator calc = new StringCalculator();

            // Assert
            Assert.Throws<Exception>(() => { calc.Add("1,-1"); });
        }


    }
}
