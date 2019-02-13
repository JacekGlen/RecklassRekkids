using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RR.GRM.Core
{
    public class MusicContract
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public IList<string> DistributionChannels { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public MusicContract()
        {
            DistributionChannels = new List<string>();
        }

        public override string ToString()
        {
            return String.Join("|", 
                Artist, 
                Title, 
                String.Join(',', DistributionChannels), 
                StartDate?.ToString("d MMM yyyy"),
                EndDate?.ToString("d MMM yyyy")
                );
        }

    }
}
