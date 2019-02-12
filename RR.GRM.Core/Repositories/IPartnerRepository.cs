using System;
using System.Collections.Generic;
using System.Text;

namespace RR.GRM.Core.Repositories
{
    public interface IPartnerRepository
    {
        IList<Partner> GetAll();
    }
}
