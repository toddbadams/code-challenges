using System.Collections.Generic;
using System.Linq;
using System;

namespace TimeToSpeech.Application
{
    public class Time
    {
        private readonly string _time;
        private readonly IDictionary<string, string> _specialTimes = new Dictionary<string, string>
        {
            { "0000", Midnight}, { "2400", Midnight}, { "1200", Noon }
        };

        private const string InvalidMessage = "Invalid format, should be [hh][mm] or [hh]:[mm]";
        private const string Midnight = "Midnight";
        private const string Noon = "Noon";
        private const string OClock = "o'clock";


        public Time(string time)
        {
            _time = ConvertToBasicFormat(time);
        }

        public override string ToString()
        {
            if (_specialTimes.Keys.Contains(_time)) return _specialTimes[_time];
            if (!IsValidBasicFormat(_time) || 
                !IsValidHours(_time) || 
                !IsValidMinutes(_time)) return InvalidMessage;

            var hours = int.Parse(_time.Substring(0, 2));
            var minutes = int.Parse(_time.Substring(2, 2));
            if (minutes > 59 || hours > 23) return InvalidMessage;

            return minutes == 0
                ? $"{_hours} {OClock}"
                : $"{_minutes} {new Hours(minutes > 30 ? hours + 1 : hours).ToString().ToLowerInvariant()}";
        }

        private Hours _hours => new Hours(int.Parse(_time.Substring(0, 2)));
        private Minutes _minutes => new Minutes(int.Parse(_time.Substring(2, 2)));

        private static bool IsValidBasicFormat(string time) =>
            time != null && time.Length == 4 && time.All(char.IsDigit);

        private Func<string, bool> IsValidHours => (time) => int.Parse(_time.Substring(0, 2)) < 24;
        private Func<string, bool> IsValidMinutes => (time) => int.Parse(_time.Substring(2, 2)) < 60;

        private static string ConvertToBasicFormat(string time)
        {
            var result = time?.Replace(":", "");
            return result != null && result.Length == 3 ? $"0{result}" : result ?? string.Empty;
        }
    }
}
