A few of the code lessons from [Codility](https://app.codility.com/programmers/lessons/1-iterations/)

# [Binary Gap](https://app.codility.com/programmers/lessons/1-iterations/binary_gap/)


``` csharp
static int Solution(int n)
{
    var binary = Convert.ToString(n, 2);
    var result = 0;
    var current = 0;
    foreach (var element in binary)
    {
        if (element == '1')
        {
            if (result < current) result = current;
            current = 0;
        }
        else
        {
            current++;
        }
    }
    return result;
}
```


# [Odd Occurrences In Array](https://app.codility.com/programmers/lessons/2-arrays/odd_occurrences_in_array/)


``` csharp
static int Solution(int[] arr)
{
    var odd = new Dictionary<int, int>();
    var even = new Dictionary<int, int>();
    foreach (var element in arr)
    {
        if (odd.ContainsKey(element))
        {
            odd.Remove(element);
            even.Add(element, element);
        }
        else
        {
            odd.Add(element, element);
            if (even.ContainsKey(element)) even.Remove(element);
        }

    }
    return odd.Keys.FirstOrDefault();
}

```


# [Tape Equilibrium](https://app.codility.com/programmers/lessons/3-time_complexity/tape_equilibrium/)


``` csharp
static int Solution(int[] arr)
{
    var sumLeft = 0;
    var sumRight = arr.Sum();
    var result = int.MaxValue;
    for (var index = 0; index < arr.Length - 1; index++)
    {
        var element = arr[index];
        sumLeft += element;
        sumRight -= element;
        var tmp = Math.Abs(sumRight - sumLeft);
        if (tmp < result) result = tmp;
    }

    return result;
}
```


# [Counting Elements](https://app.codility.com/programmers/lessons/4-counting_elements/frog_river_one/)

``` csharp
static int Solution(int x, int[] arr)
{
    var all = AllNumbers(1, x);
    int index;
    var found = false;
    for (index = 0; index < arr.Length; index++)
    {
        var element = arr[index];
        if (all.ContainsKey(element)) all.Remove(element);
        if (all.Keys.Count != 0) continue;
        found = true;
        break;
    }

    return found ? index : -1;
}
```


# [Prefix Sums](https://app.codility.com/programmers/lessons/5-prefix_sums/passing_cars/)


``` csharp
static int Solution(int[] arr)
{
    var onesCount = 0;
    var result = 0;
    for (var i = arr.Length - 1; i > -1; i--)
    {
        if (arr[i] == 0)
        {
            result += onesCount;
        }
        else
        {
            onesCount++;
        }
        if (result > 1000000000) return -1;
    }

    return result;
}
```


# [Count Div]( https://app.codility.com/programmers/lessons/5-prefix_sums/count_div/)


``` csharp
static int Solution(int a, int b, int k)
{
    if (k < 0 || b < a) return 0;

    var min = ((a + k - 1) / k) * k;
    if (min > b) return 0;
    return ((b - min) / k) + 1;
}
```


# [Distinct](https://app.codility.com/programmers/lessons/6-sorting/distinct/)


``` csharp
static int Solution(int[] arr)
{
    if (arr.Length < 1) return 0;
    Array.Sort(arr);

    var current = arr[0];
    var result = 1;

    for (var i = 1; i < arr.Length; i++)
    {
        if (arr[i] == current) continue;
        current = arr[i];
        result++;
    }

    return result;
}
```


# [Brackets](https://app.codility.com/programmers/lessons/7-stacks_and_queues/brackets/)


``` csharp
static int Solution(string s)
{
    if (string.IsNullOrEmpty(s)) return 1;
    if (s.Length % 2 != 0) return 0;
    var match = new Dictionary<char, char>()
    {
        {'(', ')'},
        {'{', '}'},
        {'[', ']'}
    };
    var stack = new Stack<char>();
    for (var i = 0; i < s.Length; i++)
    {
        if (match.ContainsKey(s[i]))
        {
            stack.Push(s[i]);
        }
        else
        {
            if (stack.Count == 0) return 0;
            var tmp = stack.Pop();
            if (match[tmp] != s[i]) return 0;
        }
    }
    return stack.Count == 0 ? 1 : 0;
}
```


# [Dominator](https://app.codility.com/programmers/lessons/8-leader/dominator/)

``` csharp
static int Solution(int[] arr)
{
    if (arr.Length == 0) return -1;
    if (arr.Length == 1) return 0;
    var dominators = new Dictionary<int, Tuple<int, int>>();
    for (var index = 0; index < arr.Length; index++)
    {
        var element = arr[index];
        if (dominators.ContainsKey(element))
        {
            dominators[element] = new Tuple<int, int>(dominators[element].Item1, dominators[element].Item2 + 1);
        }
        else
        {
            dominators.Add(element, new Tuple<int, int>(index, 1));
        }
    }

    var result = -1;
    foreach (var key in dominators.Keys.Where(key => dominators[key].Item2 > arr.Length / 2))
    {
        result = dominators[key].Item1;
        break;
    }

    return result;
}
```
