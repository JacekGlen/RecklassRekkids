using System;
using System.Collections.Generic;
using System.Text;

namespace RR.GRM.Core
{
    public class Partner
    {
        public string Name { get; set; }
        public IList<string> SupportedDistributionChannels { get; set; }

        public Partner()
        {
            SupportedDistributionChannels = new List<string>();
        }
    }
}
