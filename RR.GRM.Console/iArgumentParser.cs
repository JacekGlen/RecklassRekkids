using System;
using System.Collections.Generic;
using System.Text;

namespace RR.GRM.Console
{
    public interface IArgumentParser
    {
        string PartnerName { get; }
        DateTime EffectiveDate { get; }
        void Parse(string[] args);
        void Parse(string arg);
    }
}
