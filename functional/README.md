## Imperative programming 

Imperative programming uses statements that change a program's state and focuses on describing how a program operates. Let's look at an example from the `time-to-text` code example:

``` csharp
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
                : $"{ConvertMinutes(minutes)} {ConvertHours(minutes > 30 ? hours + 1 : hours).ToLowerInvariant()}";
        }

        private static string ConvertToBasicFormat(string time)
        {
            var result = time?.Replace(":", "");
            return result != null && result.Length == 3 ? $"0{result}" : result;
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

        private string ConvertMinutes(int minutes)
        {
            switch (minutes)
            {
                case int n when n < 21 || n == 30:
                    return $"{_numberToTextDictionary[minutes]} past";
                case int n when n > 20 && n < 30:
                    return $"{DoubleDigitNumber(minutes)} past";
                case int n when 60 - n < 21:
                    return $"{_numberToTextDictionary[60 - minutes]} to";
                default:
                    return $"{DoubleDigitNumber(60 - minutes)} to";
            }
        }

        private string DoubleDigitNumber(int i) =>
            $"{_numberToTextDictionary[i - i % 10]} {_numberToTextDictionary[i % 10].ToLowerInvariant()}";
    }
```

Imperative programming makes uses of for-each loops, if-statements, and switch statements.  The above c# class is a type of imperative programming known as procedural programming.  It is build from public method `Process(string time)` and calls a number of functions to compose the solution.  This technique improves maintainability and overall quality of imperative programming, and is a step along the way to declarative programming.

Declarative programming is  accomplished using expressions and declarations instead of statements.  Functional programming is a form of declarative programming that expresses computation as pure functional transformation of data.  Let's look at some key concepts in functional programming.

## Referential transparency

All programs can be decomposed into subprograms, and those again into smaller subprograms.  A subprogram is referentially transparent if it can be replaced by its return value.  Said another way: A function should indicate the result only by looking at the values of its parameters.

An example of a function that is not referentially transparent:

``` csharp
public int DaysBetween(DateTime from) => (DateTime.Now - from).Days;
```

This function returns a different answer based on the current time `DateTime.Now`.  Let’s look at making this function referentially transparent.

``` csharp
public int DaysBetween(DateTime from, DateTime to) => (to - from).Days;
```

Looking at the `time-to-text` processing class we can see that indeed each of the functions are referentially transparent.

## Function honesty

A function should convey about the possible input and resultant output.  It always honors its signature. Let's look at an example function that is not honest:

``` csharp
    private static string ConvertToBasicFormat(string time)
    {
        if (time == null) return null;
        var result = time.Replace(":", "");
        return result.Length == 3 ? $"0{result}" : result;
    }
```

In the above example it is possible to return a null, which is not a string. Let's improve this function by making it honest.

``` csharp
    private static string ConvertToBasicFormat(string time)
    {
        var result = time?.Replace(":", "");
        return result != null && result.Length == 3 ? $"0{result}" : result ?? "0000";
    }
```

In the above example even if the input is null we get a default string response. 

