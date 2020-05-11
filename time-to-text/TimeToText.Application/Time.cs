using System.Collections.Generic;
using System.Linq;
using System;

namespace TimeToSpeech.Application
{
    public class Time
    {
        private readonly string _time;
        private static readonly IDictionary<string, string> SpecialTimes = new Dictionary<string, string>
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
            if (SpecialTimes.Keys.Contains(_time))
            {
                _time = SpecialTimes[_time];
                return;
            }

            if (!IsValidBasicFormat(_time) || !IsValidHours(_time) || !IsValidMinutes(_time))
            {
                _time = InvalidMessage;
                return;
            }

            var hours = int.Parse(_time.Substring(0, 2));
            var minutes = int.Parse(_time.Substring(2, 2));
            if (minutes > 59 || hours > 23)
            {
                _time = InvalidMessage;
                return;
            }

            _time =  minutes == 0
                ? $"{Hours} {OClock}"
                : $"{Minutes} {new Hours(minutes > 30 ? hours + 1 : hours).ToString().ToLowerInvariant()}";
        }

        public override string ToString() => _time;

        private Hours Hours => new Hours(int.Parse(_time.Substring(0, 2)));

        private Minutes Minutes => new Minutes(int.Parse(_time.Substring(2, 2)));

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
