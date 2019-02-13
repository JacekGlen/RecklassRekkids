using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RR.GRM.Core.Repositories
{
    public class FlatFilePartnerRepository : IPartnerRepository
    {
        private readonly IInputData _inputData;

        public FlatFilePartnerRepository(IInputData inputData)
        {
            _inputData = inputData;
        }
        public IList<Partner> GetAll()
        {
            var partnerFlatLines = _inputData
                .GetPartnerData()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1);

            var retList = new List<Partner>();

            foreach (var partnerFlatLine in partnerFlatLines)
            {
                var data = partnerFlatLine.Split('|');

                if (data.Length != 2)
                {
                    throw new ArgumentException("Cannot create Partner object from invalid data");
                }

                var partner = new Partner()
                {
                    Name = data[0],
                    SupportedDistributionChannels = data[1].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                };

                retList.Add(partner);
            }

            return retList;
        }
    }
}
