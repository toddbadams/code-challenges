using System;
using System.Collections.Generic;

namespace TimeToSpeech.Application
{
    internal class Minutes
    {
        private readonly string _minutes;
        private static readonly IDictionary<int, string> NumberToTextDictionary = new Dictionary<int, string>
        {
            {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"},
            {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, {10, "Ten"},
            {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, {15, "Fifteen"},
            {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
            {20, "Twenty"}, {30, "Half"}, {40, "Forty"}, {50, "Fifty"}
        };

        public Minutes(int minutes)
        {
            this._minutes = IsThirtyOrLess(minutes) ?
                $"{Formatter(minutes)} past" :
                $"{Formatter(60 - minutes)} to";
        }

        public override string ToString() => _minutes;

        private static Func<int, bool> IsThirtyOrLess => (int i) => i < 31;

        private Func<int, string> Formatter => (int i) => NumberToTextDictionary.ContainsKey(i) ?
            $"{NumberToTextDictionary[i]}" :
            $"{NumberToTextDictionary[i - i % 10]} {NumberToTextDictionary[i % 10].ToLowerInvariant()}";
    }
}
