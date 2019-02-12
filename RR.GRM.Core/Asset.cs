using System;
using System.Collections.Generic;
using System.Text;

namespace RR.GRM.Core
{
    public class Asset
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public IList<string> DistributionChannels { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Asset()
        {
            DistributionChannels = new List<string>();
        }
    }
}
