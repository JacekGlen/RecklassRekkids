using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using RR.GRM.Core.Repositories;

namespace RR.GRM.Tests.Core
{
    [TestFixture]
    public class FlatFilePartnerRepositoryTest
    {
        [Test]
        public void ParsesValidData()
        {
            var inputData = new Mock<IInputData>();
            inputData.Setup(data => data.GetPartnerData())
                .Returns(@"Partner|Usage
ITunes|digital download
YouTube|streaming");

            var sut = new FlatFilePartnerRepository(inputData.Object);

            var result = sut.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }
    }
}
