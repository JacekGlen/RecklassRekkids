using System;
using System.Collections.Generic;
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

        public MusicContract(string flatLineData)
        {
            if (String.IsNullOrWhiteSpace(flatLineData))
            {
                throw new ArgumentException("Cannot create MusicContract object from empty data");
            }

            var data = flatLineData.Split('|');

            if (data.Length != 5)
            {
                throw new ArgumentException("Cannot create MusicContract object from invalid data");
            }


        }
    }
}
