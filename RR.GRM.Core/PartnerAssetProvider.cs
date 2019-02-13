using System;
using System.Collections.Generic;
using System.Text;
using RR.GRM.Core.Repositories;

namespace RR.GRM.Core
{
    public class PartnerAssetProvider : IPartnerAssetProvider
    {
        public PartnerAssetProvider(IMusicContractRepository assetRepository, IPartnerRepository partnerRepository)
        {

        }

        public IList<MusicContract> Get(string partnerName, DateTime effectiveDate)
        {
            throw new NotImplementedException();
        }
    }
}
