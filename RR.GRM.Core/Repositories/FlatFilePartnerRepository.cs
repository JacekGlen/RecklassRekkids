using System;
using System.Collections.Generic;
using System.Text;

namespace RR.GRM.Core.Repositories
{
    public class FlatFilePartnerRepository
    {
        public FlatFilePartnerRepository( IInputData inputData)
        {
            var partnerData = inputData.GetPartnerData();
        }
    }
}
