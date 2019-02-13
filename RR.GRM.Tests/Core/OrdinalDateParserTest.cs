using System;
using System.Collections.Generic;
using System.Text;

using Moq;
using NUnit.Framework;
using RR.GRM.Core;

namespace RR.GRM.Tests.Core
{
    [TestFixture]
    public class OrdinalDateParserTest
    {
        [Test]
        public void ReturnsNullForEmptyString()
        {
            var sut = new OrdinalDateParser();

            var result = sut.Parse(null);

            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ThrowsExceptionWhenBadFormat()
        {
            var sut = new OrdinalDateParser();

            Assert.Throws<ArgumentException>(() => sut.Parse("I really am a date"));
        }

        [Test]
        [TestCase("1st Feb 2012", "2012-02-01")]
        [TestCase("1st Aug 2012", "2012-08-01")]
        [TestCase("25st Dec 2012", "2012-12-25")]
        [TestCase("31st Dec 2012", "2012-12-31")]
        [TestCase("1st March 2012", "2012-03-01")]
        public void ParsesValidOridnalDateString(string input, DateTime expectedResult)
        {
            var sut = new OrdinalDateParser();

            var result = sut.Parse(input);

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(expectedResult, result.Value);
        }
    }
}
