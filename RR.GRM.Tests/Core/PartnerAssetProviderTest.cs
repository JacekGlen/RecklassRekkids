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
    public class PartnerAssetProviderTest
    {
        [Test]
        public void ReturnsNoContractsForUnknownPartner()
        {
            var sut = GetSut();

            var result = sut.Get("Big Name", new DateTime(2012, 10, 1));

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        [TestCase("ITunes", 3)]
        [TestCase("YouTube", 2)]
        public void FiltersContractsByChannel(string partnerName, int expectedContracts)
        {
            var sut = GetSut();

            var result = sut.Get(partnerName, new DateTime(2012, 10, 1));

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedContracts, result.Count);
        }

        [Test]
        public void FiltersByEndDate()
        {
            var sut = GetSut();

            var result = sut.Get("YouTube", new DateTime(2013, 10, 1));

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void FiltersByStartDate()
        {
            var sut = GetSut();

            var result = sut.Get("ITunes", new DateTime(2012, 3, 1));

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        private PartnerAssetProvider GetSut()
        {
            var mockMcr = new Mock<IMusicContractRepository>();
            mockMcr.Setup(mcr => mcr.GetAll()).Returns(new List<MusicContract>()
            {
                new MusicContract(){Artist = "Tinie Tempah", Title = "Frisky (Live from SoHo)", DistributionChannels = new List<string>(){"digital download", "streaming" }, StartDate = new DateTime(2012,2,1)},
                new MusicContract(){Artist = "Tinie Tempah", Title = "AAA", DistributionChannels = new List<string>(){"digital download"}, StartDate = new DateTime(2012,2,1)},
                new MusicContract(){Artist = "Tinie Tempah", Title = "BBB", DistributionChannels = new List<string>(){"digital download"}, StartDate = new DateTime(2012,9,1)},
                new MusicContract(){Artist = "Tinie Tempah", Title = "CCC", DistributionChannels = new List<string>(){"streaming" }, StartDate = new DateTime(2012,2,1), EndDate = new DateTime(2012,12,1)},
            });

            var mockPr = new Mock<IPartnerRepository>();
            mockPr.Setup(pr => pr.GetAll()).Returns(new List<Partner>()
            {
                new Partner() {Name = "ITunes", SupportedDistributionChannels =  new List<string>(){"digital download"}},
                new Partner() {Name = "YouTube", SupportedDistributionChannels =  new List<string>(){"streaming"}},
            });

            return new PartnerAssetProvider(mockMcr.Object, mockPr.Object);
        }
    }
}
