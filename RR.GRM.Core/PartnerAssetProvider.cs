using System;
using System.Collections.Generic;
using System.Text;
using RR.GRM.Core.Repositories;

namespace RR.GRM.Core
{
    public class PartnerAssetProvider : IPartnerAssetProvider
    {
        public PartnerAssetProvider(IAssetRepository assetRepository, IPartnerRepository partnerRepository)
        {

        }

        public IList<Asset> Get(string partnerName, DateTime effectiveDate)
        {
            throw new NotImplementedException();
        }
    }
}
