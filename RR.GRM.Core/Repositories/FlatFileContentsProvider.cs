using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RR.GRM.Core.Repositories
{
    public class FlatFileContentsProvider : IInputData
    {
        private readonly ICoreSettings _coreSettings;

        public FlatFileContentsProvider(ICoreSettings coreSettings)
        {
            _coreSettings = coreSettings;
        }

        public string GetAssetData()
        {
            return File.ReadAllText(_coreSettings.FlatFileAssetPath);
        }

        public string GetPartnerData() 
        {
            return File.ReadAllText(_coreSettings.FlatFilePartnerPath);
        }
    }
}
