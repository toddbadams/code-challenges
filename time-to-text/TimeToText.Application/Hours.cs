using System.Collections.Generic;

namespace TimeToSpeech.Application
{
    internal class Hours
    {
        private readonly string _hours;
        private static readonly IDictionary<int, string> NumberToTextDictionary = new Dictionary<int, string>
        {
            {0, "Midnight"}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"},
            {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, {10, "Ten"},
            {11, "Eleven"}, {12, "Noon"}, {24, "Midnight"}
        };

        public Hours(int hours)
        {
            _hours = NumberToTextDictionary[hours > 12 && hours < 24 ? hours - 12 : hours];
        }

        public override string ToString() => _hours;
    }
}
