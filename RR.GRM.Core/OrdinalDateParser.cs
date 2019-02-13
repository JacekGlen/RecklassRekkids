using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RR.GRM.Core
{
    public class OrdinalDateParser : IDateParser
    {
        public DateTime? Parse(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            input = input
                .Replace("st", "")
                .Replace("nd", "")
                .Replace("rd", "")
                .Replace("th", "");

            if (DateTime.TryParseExact(input, "d MMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                return date;
            }

            if (DateTime.TryParseExact(input, "d MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date2))
            {
                return date2;
            }

            throw new ArgumentException($"Could not parse {input} to date");
        }
    }
}
