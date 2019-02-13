using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RR.GRM.Core;

namespace RR.GRM.Console
{
    public class ArgumentParser
    {
        private readonly IDateParser _dateParser;
        public string PartnerName { get; private set; }
        public DateTime EffectiveDate { get; private set; }

        public ArgumentParser(IDateParser dateParser)
        {
            _dateParser = dateParser;
        }

        public void Parse(string[] args)
        {
            if (args.Length != 4)
            {
                throw new ArgumentException("Could not resolve partner name and date from the given arguments");
            }

            PartnerName = args[0];
            EffectiveDate = _dateParser.Parse(String.Join(" ", args.Skip(1))).Value;
        }
    }
}
