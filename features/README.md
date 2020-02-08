# 10 important c# features

## Object / array / collection initializers

C# lets you instantiate an object, arrray or collection and perform initialization in a single statement.

``` csharp
    public class Wine
    {
        public int Vintage { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }

        public Wine()
        {
        }

        public Wine(string name)
        {
            Name = name;
        }
    }
```


``` csharp
    class Program
    {
        static void Main(string[] args)
        {
            var petrus = new Wine { Vintage = 2005, Name = "Petrus", Region = "Pomerol" };
            var lePin = new Wine("Le Pin") { Vintage = 2000, Region = "Pomerol" };
        }
    }
```

This especially useful in LINQ query expressions combined anonymous types.


``` csharp
    class Program
    {
        static void Main(string[] args)
        {
            // collection initializer
            var wines = new List<Wine>
            {
                new Wine {Vintage = 2005, Name = "Petrus", Region = "Pomerol"},
                new Wine("Le Pin") {Vintage = 2000, Region = "Pomerol"}
            };
            // anonymous initializer
            foreach (var w in wines.Select(_ => new {_.Vintage, _.Region}))
            {
                // do stuff
            }
        }
    }
```

## Null Coalescing

The C# Null Coalescing Operator ( ?? ) is a binary operator that simplifies checking for null values. It is used to assign a default value to a variable when the value is null.

``` csharp
    class Program
    {
        static void Main(string[] args)
        {
            List<Wine> wines = null;
            //...
            wines = wines ?? new List<Wine>
            {
                new Wine {Vintage = 2005, Name = "Petrus", Region = "Pomerol"},
                new Wine("Le Pin") {Vintage = 2000, Region = "Pomerol"}
            };
        }
    }
```

Beginning with C# 8.0, you can use the ??= operator to replace the code of the form

``` csharp
if (variable is null)
{
    variable = expression;
}
```
with the following code:
``` csharp
variable ??= expression;
```

## Null-conditional operators ?. and ?[]
Available in C# 6 and later, a null-conditional operator applies a member access, ?., or element access, ?[], operation to its operand only if that operand evaluates to non-null; otherwise, it returns null.


``` csharp
    class Program
    {
        static void Main(string[] args)
        {
            double SumNumbers(IReadOnlyList<double[]> setsOfNumbers, int indexOfSetToSum) => 
                setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;

            Console.WriteLine(SumNumbers(null, 0));  // output: NaN

            Console.WriteLine(SumNumbers(new List<double[]>
            {
                new[] { 1.0, 2.0, 3.0 },
                null
            }, 0));  // output: 6

            Console.WriteLine(SumNumbers(new List<double[]>
            {
                new[] { 1.0, 2.0, 3.0 },
                null
            }, 1));  // output: NaN
        }
    }
```

## Asynchronous programming

There are two common scenarios:

1.  I/O Bound such as requesting data from a DB. Use `await` operation which returns a Task or Task<T> inside of an async method.
1.  CPU Bound such as performing an expensive calucation. Use `await` operation which is started on a background thread with the Task.Run method.

``` csharp

    public class WineCellarStats
    {
        public int Vintage { get; set; }
        public string Region { get; set; }
        public int Count { get; set; }
    }
```

``` csharp
    
    public class MyWineService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private WineCellarStats CalculateWineCellar(IEnumerable<Wine> wines)
        {
            // Does an expensive calculation and returns
            // the result of that calculation.
            throw new NotImplementedException();
        }

        // CPU Bound Example
        // free calling thread while performing calculation
        public async Task<WineCellarStats> Calculate(IEnumerable<Wine> wines) =>
            await Task.Run(() => CalculateWineCellar(wines));

        // I/O Bound Example
        // free thread while waiting on external web service
        public async Task<HttpResponseMessage> GetWines() =>
            await _httpClient.GetAsync(new Uri("http://winejargon.com"));
    };
```

## Lamda Expressions

Two forms of the lambda:

1. Expression lambda - used in the construction of expression trees

``` csharp
    // zero input parameters 
    public Action BlankWine = () => new Wine();

    // Two or more input parameters 
    private readonly Func<Wine, Wine, bool> _isSameVintage = (x, y) => x.Vintage == y.Vintage;

    // Sometimes it's impossible to infer the input types.
    // Specify the types explicitly
    private readonly Func<Wine, dynamic> _selector = (Wine w) => new { w.Vintage, w.Region };
```

2. Statement lambda 

``` csharp
    public Func<string, int, Wine> BlankWine = (string name, int vintage) =>
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return new Wine(name) { Vintage = vintage }; 
    };
```