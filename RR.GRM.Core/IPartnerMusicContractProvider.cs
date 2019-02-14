using System;
using System.Collections.Generic;
using System.Text;

namespace RR.GRM.Core
{
    public interface IPartnerMusicContractProvider
    {
        IList<MusicContract> Get(string partnerName, DateTime effectiveDate);
    }
}
