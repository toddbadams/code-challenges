using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeToSpeech.Application
{
    public class WrittenTimeProcessor
    {
        private readonly IDictionary<int, string> _numberToTextDictionary = new Dictionary<int, string>
        {
            {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"},
            {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, {10, "Ten"},
            {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, {15, "Fifteen"},
            {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
            {20, "Twenty"}, {30, "Half"}, {40, "Forty"}, {50, "Fifty"}
        };
        private readonly IDictionary<string, string> _specialTimes = new Dictionary<string, string>
        {
            { "0000", Midnight}, { "2400", Midnight}, { "1200", Noon }
        };

        private const string InvalidMessage = "Invalid format, should be [hh][mm] or [hh]:[mm]";
        private const string Midnight = "Midnight";
        private const string Noon = "Noon";
        private const string OClock = "o'clock";

        /// <summary>
        /// Present time in a more "Human Friendly" way
        /// </summary>
        /// <param name="time">The format is [hh][mm] or [hh]:[mm].</param>
        /// <returns>Human friendly time</returns>
        public string Process(string time)
        {
            time = ConvertToBasicFormat(time);
            if (!IsValidBasicFormat(time)) return InvalidMessage;

            if (_specialTimes.Keys.Contains(time)) return _specialTimes[time];

            var hours = int.Parse(time.Substring(0, 2));
            var minutes = int.Parse(time.Substring(2, 2));
            if (minutes > 59 || hours > 23) return InvalidMessage;

            return minutes == 0
                ? $"{ConvertHours(hours)} {OClock}"
                : $"{ConvertMinutes(minutes, DoubleDigitNumberFunc)} {ConvertHours(minutes > 30 ? hours + 1 : hours).ToLowerInvariant()}";
        }

        private static string ConvertToBasicFormat(string time)
        {
            var result = time?.Replace(":", "");
            return result != null && result.Length == 3 ? $"0{result}" : result ?? string.Empty;
        }

        private static bool IsValidBasicFormat(string time) =>
            time != null && time.Length == 4 && time.All(char.IsDigit);

        private string ConvertHours(int hours)
        {
            switch (hours)
            {
                case int n when n == 0 || n == 24:
                    return Midnight;
                case int n when n == 12:
                    return Noon;
                default:
                    return _numberToTextDictionary[hours > 12 ? hours - 12 : hours];
            }
        }

        private Func<int, bool> IsTwentyOrLess => (int i) => i < 21;
        private Func<int, bool> IsBetweenTwentyOneAndTwentyNine => (int i) => i > 20 && i < 30;
        private Func<int, bool> IsThirty => (int i) => i == 30;
        private Func<int, bool> IsBetweenThirtyOneAndThirtyNine => (int i) => i > 30 && i < 40;
        private Func<int, bool> IsBetweenFortyAndFiftyNine => (int i) => i > 40 && i < 60;

        private Func<int, Func<int, string>, string> TwentyOrLess => (minutes, formatter) => $"{_numberToTextDictionary[minutes]} past";
        private Func<int, Func<int, string>, string> BetweenTwentyOneAndTwentyNine => (minutes, formatter) => $"{formatter(minutes)} past";
        private Func<int, Func<int, string>, string> BetweenFortyAndFiftyNine => (minutes, formatter) => $"{_numberToTextDictionary[60 - minutes]} to";
        private Func<int, Func<int, string>, string> BetweenThirtyOneAndThirtyNine => (minutes, formatter) => $"{formatter(60 - minutes)} to";

        private Func<int, string> DoubleDigitNumberFunc => (int i) => $"{_numberToTextDictionary[i - i % 10]} {_numberToTextDictionary[i % 10].ToLowerInvariant()}";

        private string ConvertMinutes(int minutes, Func<int, string> doubleDigitNumberFormatter)
        {
            switch (minutes)
            {
                case int n when IsTwentyOrLess(n) || IsThirty(n):
                    return TwentyOrLess(minutes, doubleDigitNumberFormatter);
                case int n when IsBetweenTwentyOneAndTwentyNine(n):
                    return BetweenTwentyOneAndTwentyNine(minutes, doubleDigitNumberFormatter);
                case int n when IsBetweenFortyAndFiftyNine(n):
                    return BetweenFortyAndFiftyNine(minutes, doubleDigitNumberFormatter);
                case int n when IsBetweenThirtyOneAndThirtyNine(n):
                    return BetweenThirtyOneAndThirtyNine(minutes, doubleDigitNumberFormatter);
            }
            return string.Empty;
        }
    }

    public class Minutes
    {
        private readonly int minutes;
        private readonly IDictionary<int, string> _numberToTextDictionary = new Dictionary<int, string>
        {
            {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"},
            {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, {10, "Ten"},
            {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, {15, "Fifteen"},
            {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
            {20, "Twenty"}, {30, "Half"}, {40, "Forty"}, {50, "Fifty"}
        };

        public Minutes(int minutes)
        {
            this.minutes = minutes;
        }

        public override string ToString()
        {
            if (IsTwentyOrLess(minutes) || IsThirty(minutes)) return TwentyOrLess(minutes, FormatterFunc);
            if (IsBetweenTwentyOneAndTwentyNine(minutes)) return BetweenTwentyOneAndTwentyNine(minutes, FormatterFunc);
            if (IsBetweenThirtyOneAndThirtyNine(minutes)) return BetweenThirtyOneAndThirtyNine(minutes, FormatterFunc);
            return BetweenFortyAndFiftyNine(minutes, FormatterFunc);
        }


        private Func<int, bool> IsTwentyOrLess => (int i) => i < 21;
        private Func<int, bool> IsBetweenTwentyOneAndTwentyNine => (int i) => i > 20 && i < 30;
        private Func<int, bool> IsThirty => (int i) => i == 30;
        private Func<int, bool> IsBetweenThirtyOneAndThirtyNine => (int i) => i > 30 && i < 40;

        private Func<int, Func<int, string>, string> TwentyOrLess => (minutes, formatter) => $"{formatter(minutes)} past";
        private Func<int, Func<int, string>, string> BetweenTwentyOneAndTwentyNine => (minutes, formatter) => $"{formatter(minutes)} past";
        private Func<int, Func<int, string>, string> BetweenThirtyOneAndThirtyNine => (minutes, formatter) => $"{formatter(60 - minutes)} to";
        private Func<int, Func<int, string>, string> BetweenFortyAndFiftyNine => (minutes, formatter) => $"{formatter(60 - minutes)} to";

        private Func<int, string> FormatterFunc => (int i) => _numberToTextDictionary.ContainsKey(i) ?
        $"{_numberToTextDictionary[i]}" : $"{_numberToTextDictionary[i - i % 10]} {_numberToTextDictionary[i % 10].ToLowerInvariant()}";
    }

}
