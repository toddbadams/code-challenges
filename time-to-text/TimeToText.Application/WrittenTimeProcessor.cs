using System.Collections.Generic;
using System.Linq;

namespace TimeToSpeech.Application
{
    public class WrittenTimeProcessor
    {
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
                ? $"{new Hours(hours)} {OClock}"
                : $"{new Minutes(minutes)} {new Hours(minutes > 30 ? hours + 1 : hours).ToString().ToLowerInvariant()}";
        }

        private static string ConvertToBasicFormat(string time)
        {
            var result = time?.Replace(":", "");
            return result != null && result.Length == 3 ? $"0{result}" : result ?? string.Empty;
        }

        private static bool IsValidBasicFormat(string time) =>
            time != null && time.Length == 4 && time.All(char.IsDigit);
    }
}
