using System.Collections.Generic;

namespace TimeToSpeech.Application
{
    public class Hours
    {
        private readonly int hours;
        private readonly IDictionary<int, string> numberToTextDictionary = new Dictionary<int, string>
        {
            {0, "Midnight"}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"},
            {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, {10, "Ten"},
            {11, "Eleven"}, {12, "Noon"}, {24, "Midnight"}
        };

        public Hours(int hours)
        {
            this.hours = hours;
        }

        public override string ToString() => numberToTextDictionary[hours > 12  && hours < 24 ? hours - 12 : hours];
    }
}
