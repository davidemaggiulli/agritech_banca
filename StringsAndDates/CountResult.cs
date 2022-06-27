using System;
using System.Collections.Generic;
using System.Text;

namespace StringsAndDates
{
    public class CountResult
    {
        public CountResult(int alpha, int numeric, int special)
        {
            NumericCount = numeric;
            AlphaChars = alpha;
            SpecialChars = special;
        }
        public int NumericCount { get; }
        public int SpecialChars { get; }
        public int AlphaChars { get; }
    }
}
