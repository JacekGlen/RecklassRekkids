using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using RR.GRM.Console;
using RR.GRM.Core;

namespace RR.GRM.Tests.Console
{
    [TestFixture]
    public class ArgumentParserTest
    {
        [Test]
        public void ThorowsExceptionWhenEmptyArguments()
        {
            var sut = new ArgumentParser(new Mock<IDateParser>().Object);

            string[] args = { };

            Assert.Throws<ArgumentException>(() => sut.Parse(args));
        }

        [Test]
        public void ThorowsExceptionWhenInvalidNumberOfArguments()
        {
            var sut = new ArgumentParser(new Mock<IDateParser>().Object);

            string[] args = {"one", "two" };

            Assert.Throws<ArgumentException>(() => sut.Parse(args));
        }

        [Test]
        public void SetsPartnerName()
        {
            var dateParser = new Mock<IDateParser>();
            dateParser.Setup(dp => dp.Parse(It.IsAny<string>())).Returns(DateTime.Now);
            var sut = new ArgumentParser(dateParser.Object);

            string[] args = { "partner", "1st", "May", "2019" };
            sut.Parse(args);

            Assert.AreEqual("partner", sut.PartnerName);
        }

        [Test]
        public void CallsDateParser()
        {
            var dateParser = new Mock<IDateParser>();
            dateParser.Setup(dp => dp.Parse(It.IsAny<string>())).Returns(DateTime.Now);
            var sut = new ArgumentParser(dateParser.Object);

            string[] args = { "partner", "1st", "May", "2019" };
            sut.Parse(args);

            dateParser.Verify(dp => dp.Parse("1st May 2019"));
        }
    }
}
