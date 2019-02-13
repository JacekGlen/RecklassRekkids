using System;
using System.Collections.Generic;
using System.Text;

namespace RR.GRM.Core.Repositories
{
    public interface IMusicContractRepository
    {
        IList<MusicContract> GetAll();
    }
}
