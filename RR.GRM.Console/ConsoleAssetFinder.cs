using System;
using System.Collections.Generic;
using System.Text;
using RR.GRM.Core;

namespace RR.GRM.Console
{
    public class ConsoleAssetFinder : IConsoleAssetFinder
    {
        private readonly IArgumentParser _argumentParser;
        private readonly IPartnerMusicContractProvider _partnerMusicContractProvider;
        private const string PrinthHeader = "Artist|Title|Usage|StartDate|EndDate";

        public ConsoleAssetFinder(IArgumentParser argumentParser, IPartnerMusicContractProvider partnerMusicContractProvider)
        {
            _argumentParser = argumentParser;
            _partnerMusicContractProvider = partnerMusicContractProvider;
        }

        public void Print(string arg)
        {
            _argumentParser.Parse(arg);
            var contracts = _partnerMusicContractProvider.Get(_argumentParser.PartnerName, _argumentParser.EffectiveDate);

            System.Console.WriteLine(PrinthHeader);

            foreach (var musicContract in contracts)
            {
                System.Console.WriteLine(musicContract);
            }
        }
    }
}
