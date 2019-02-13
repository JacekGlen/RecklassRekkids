using System;

namespace RR.GRM.Core
{
    public interface IDateParser
    {
        DateTime? Parse(string input);
    }
}