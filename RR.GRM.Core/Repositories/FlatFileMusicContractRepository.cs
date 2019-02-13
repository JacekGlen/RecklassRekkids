using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RR.GRM.Core.Repositories
{
    public class FlatFileMusicContractRepository : IMusicContractRepository
    {
        private readonly IInputData _inputData;

        public FlatFileMusicContractRepository(IInputData inputInputData)
        {
            _inputData = inputInputData;
        }

        public IList<MusicContract> GetAll()
        {
            var musicContractFlatLines = _inputData
                .GetAssetData()
                .Split(Environment.NewLine)
                .Skip(1);

            var retList = new List<MusicContract>();

            foreach (var musicContractFlatLine in musicContractFlatLines)
            {
                var 
            }

            return retList;
        }
    }
}
