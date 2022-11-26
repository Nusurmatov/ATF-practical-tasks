using NUnit.Framework;
using DevelopmentAndBuildTools;
using System;

namespace ConsecutiveCharsNUnitTests
{
    [TestFixture]
    public sealed class ConsecutiveCharTests
    {
        [TestCase(1, "AAA")]
        [TestCase(5, "aAaA ")]
        [TestCase(8, "Let's see")]
        [TestCase(6, "@44`3faA")]
        public void TotalConsecutiveUnequalCharsTest(int expected, string source)
        {
            // Assert 
            Assert.AreEqual(expected, ConsecutiveChar.GetTotalConsecutiveUnequalChars(source));
        }

        [TestCase(0, "Куртой")]
        [TestCase(2, "Latin letters")]
        [TestCase(0, "178@^4&")]
        public void TotalConsecutiveIdenticalLatinLettersTest(int expected, string source)
        {
            // Assert
            Assert.AreEqual(expected, ConsecutiveChar.GetTotalConcsecutiveIndenticalLatinLetters(source));
        }

        [TestCase(7, "7777777")]
        [TestCase(1, "CR7")]
        [TestCase(0, "seven")]
        [TestCase(0, "Куртой")]
        [TestCase(2, "53985uhaofg33")]
        [TestCase(2, "TwoNumbers22BetweenTwoStrings")]
        public void TotalConsecutiveIdenticalDigitsTest(int expected, string source)
        {
            // Assert
            Assert.AreEqual(expected, ConsecutiveChar.GetTotalConsecutiveIdenticalDigits(source));
        }
    
        [TestCase(null)]
        [TestCase("")]
        public void ThrowExceptionFromTotalConsecutiveUnequalCharsTest(string source)
        {
            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => ConsecutiveChar.GetTotalConsecutiveUnequalChars(source));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowExceptionFromtTotalConsecutiveIdenticalLatinLettersTest(string source)
        {
            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => ConsecutiveChar.GetTotalConsecutiveIdenticalDigits(source));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowExceptionFromTotalConsecutiveIdenticalDigitsTest(string source)
        {
            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => ConsecutiveChar.GetTotalConcsecutiveIndenticalLatinLetters(source));
        }
    }
}