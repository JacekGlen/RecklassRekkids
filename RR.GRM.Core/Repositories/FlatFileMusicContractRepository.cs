using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RR.GRM.Core.Repositories
{
    public class FlatFileMusicContractRepository : IMusicContractRepository
    {
        private readonly IInputData _inputData;
        private readonly IDateParser _dateParser;

        public FlatFileMusicContractRepository(IInputData inputInputData, IDateParser dateParser)
        {
            _inputData = inputInputData;
            _dateParser = dateParser;
        }

        public IList<MusicContract> GetAll()
        {
            var musicContractFlatLines = _inputData
                .GetAssetData()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1);

            var retList = new List<MusicContract>();

            foreach (var musicContractFlatLine in musicContractFlatLines)
            {
                var data = musicContractFlatLine.Split('|');

                if (data.Length != 5)
                {
                    throw new ArgumentException("Cannot create MusicContract object from invalid data");
                }

                var contract = new MusicContract()
                {
                    Artist = data[0],
                    Title = data[1],
                    DistributionChannels = data[2].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(dc => dc.Trim()).ToList(),
                    StartDate = _dateParser.Parse(data[3]),
                    EndDate = _dateParser.Parse(data[4]),
                };

                retList.Add(contract);
            }

            return retList;
        }
    }
}
