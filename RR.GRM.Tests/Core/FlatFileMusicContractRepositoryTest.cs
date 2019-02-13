using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using RR.GRM.Core;
using RR.GRM.Core.Repositories;

namespace RR.GRM.Tests.Core
{
    [TestFixture]
    public class FlatFileMusicContractRepositoryTest
    {
        [Test]
        public void ParsesValidData()
        {
            var inputData = new Mock<IInputData>();
            inputData.Setup(data => data.GetAssetData())
                .Returns(@"Artist|Title|Usages|StartDate|EndDate
Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming|1st Feb 2012|
Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|
Tinie Tempah|Till I'm Gone|digital download|1st Aug 2012|
Monkey Claw|Black Mountain|digital download|1st Feb 2012|
Monkey Claw|Iron Horse|digital download, streaming|1st June 2012|
Monkey Claw|Motor Mouth|digital download, streaming|1st Mar 2011|
Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012");

            var sut = new FlatFileMusicContractRepository(inputData.Object, new OrdinalDateParser());

            var result = sut.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(7, result.Count);
        }

    }
}
