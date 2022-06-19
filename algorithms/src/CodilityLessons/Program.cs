using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Codility Lessons");
            // BinaryGap();
            // OddOccurrencesInArray();
            // TapeEquilibrium();
            // FrogRiverOne();
            // PassingCars();
            // CountDiv();
            // Distinct();
            // Brackets();
            Dominator();
            Console.ReadLine();
        }

        #region Iterations

        /// <summary>
        /// https://app.codility.com/programmers/lessons/1-iterations/binary_gap/
        /// </summary>
        private static void BinaryGap()
        {
            Console.WriteLine("Binary Gap");
            RunSolution(new[] { 32, 15, 1041, 1, 101, 2147483647, 6, 328, 9, 11, 19, 42, 1162, 51712, 6291457, 1610612737 });

            static void RunSolution(IEnumerable<int> values)
            {
                foreach (var n in values)
                {
                    Console.WriteLine($"N={n}, result={Solution(n)}");
                }
            }

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
        }

        #endregion

        #region Arrays

        /// <summary>
        /// https://app.codility.com/programmers/lessons/2-arrays/odd_occurrences_in_array/
        /// </summary>
        private static void OddOccurrencesInArray()
        {
            Console.WriteLine("Odd Occurrences In Array");
            RunSolution(new[]
            {
                new[] { 9, 3, 9, 3, 9, 7, 9 },
                new[] { 1 },
                new[] { 1, 1 },
                new[] { 1, 1, 1 },
                new[] { 9, 3, 9, 3, 9, 7, 9, 7, 9 }
            });

            static void RunSolution(int[][] values)
            {
                foreach (var arr in values)
                {
                    Console.WriteLine($"N={string.Join(',', arr)}, result={Solution(arr)}");
                }
            }

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
        }
        #endregion

        #region Time Complexity
        /// <summary>
        /// https://app.codility.com/programmers/lessons/3-time_complexity/tape_equilibrium/
        /// </summary>
        private static void TapeEquilibrium()
        {
            Console.WriteLine("Tape Equilibrium");
            RunSolution(new[]
            {
                new[] { 3, 1, 2, 4, 3 },
                new[] { 1,1 },
                new[] { -1000, 1000 },
                new[] { -1000, -1000 },
                new[] { 0, 0, 0 }
            });

            static void RunSolution(int[][] values)
            {
                foreach (var arr in values)
                {
                    Console.WriteLine($"A=[{string.Join(',', arr)}], result={Solution(arr)}");
                }
            }

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
        }
        #endregion

        #region Counting Elements
        /// <summary>
        /// https://app.codility.com/programmers/lessons/4-counting_elements/frog_river_one/
        /// </summary>
        private static void FrogRiverOne()
        {
            Console.WriteLine("Frog River One");
            RunSolution(new[]
                {
                    5,
                    2
                },
                new[]
                {
                    new[] {1, 3, 1, 4, 2, 3, 5, 4},
                    new[] {1}
                });

            static void RunSolution(int[] xs, int[][] arrs)
            {
                for (var i = 0; i < arrs.Length; i++)
                {
                    var arr = arrs[i];
                    var x = xs[i];
                    Console.WriteLine($"X={x}  A=[{string.Join(',', arr)}], result={Solution(x, arr)}");
                }
            }

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
        }
        #endregion

        #region Prefix Sums
        /// <summary>
        /// https://app.codility.com/programmers/lessons/5-prefix_sums/passing_cars/
        /// </summary>
        private static void PassingCars()
        {
            Console.WriteLine("Passing Cars");
            RunSolution(new[]
                {
                    new[] {0,1,0,1,1},
                    new[] {1},
                    new[] {1, 1, 1},
                    new[] {0},
                    new[] {0, 0, 0, 0, 1, 1, 1}
                });

            static void RunSolution(int[][] arrs)
            {
                foreach (var arr in arrs)
                {
                    Console.WriteLine($"A=[{string.Join(',', arr)}], result={Solution(arr)}");
                }
            }

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
        }


        /// <summary>
        /// https://app.codility.com/programmers/lessons/5-prefix_sums/count_div/
        /// </summary>
        private static void CountDiv()
        {
            Console.WriteLine("CountDiv");
            RunSolution(new[]
            {
                new[] {10, 10, 5},
                new[] {10, 10, 7},
                new[] {10, 10, 20},
                new[] {6, 11, 2},
                new[] {0, 0, 1},
                new[] {0, 1, 1},
                new[] {0, 2000000000, 2000000000 }
            });

            static void RunSolution(int[][] arrs)
            {
                foreach (var arr in arrs)
                {
                    Console.WriteLine($"A={arr[0]}, B={arr[1]}, K={arr[2]}, result={Solution(arr[0], arr[1], arr[2])}");
                }
            }

            static int Solution(int a, int b, int k)
            {
                if (k < 0 || b < a) return 0;

                var min = ((a + k - 1) / k) * k;
                if (min > b) return 0;
                return ((b - min) / k) + 1;
            }
        }
        #endregion

        #region Sorting
        /// <summary>
        /// https://app.codility.com/programmers/lessons/6-sorting/distinct/
        /// </summary>
        private static void Distinct()
        {
            Console.WriteLine("Distinct");
            RunSolution(new[]
                {
                    new[] {2, 1, 1, 2, 3, 1},
                    new[] {-1000000, 1, 2, 1000000},
                    new[] {1, 1, 1},
                    new int[] {},
                    new[] {0, 0, 0, 0, 1, 1, 3}
                });

            static void RunSolution(int[][] arrs)
            {
                foreach (var arr in arrs)
                {
                    Console.WriteLine($"A=[{string.Join(',', arr)}], result={Solution(arr)}");
                }
            }

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
        }
        #endregion

        #region stacks and queues
        /// <summary>
        /// https://app.codility.com/programmers/lessons/7-stacks_and_queues/brackets/
        /// </summary>
        private static void Brackets()
        {
            Console.WriteLine("Brackets");
            RunSolution(new[]
            {
                "",
                "(",
                "{[()()]}",
                "([)()]",
                "([)()]",
                "([)()]",
            });

            static void RunSolution(string[] ss)
            {
                foreach (var s in ss)
                {
                    Console.WriteLine($"S={string.Join(',', s)}, result={Solution(s)}");
                }
            }

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
        }
        #endregion

        #region Dominator
        /// <summary>
        /// https://app.codility.com/programmers/lessons/8-leader/dominator/
        /// </summary>
        private static void Dominator()
        {
            Console.WriteLine("Dominator");
            const int min = -2147483648;
            const int max = 2147483647;
            RunSolution(new[]
            {
                new[] { 3, 4, 3, 2, 3, -1, 3, 3 },
                new int[] { },
                new int[] { min, max},
                new int[] { min, max, max},
                new int[] { 1, 1, 2, 2},
                new int[] { 1 }
            });

            static void RunSolution(int[][] values)
            {
                foreach (var arr in values)
                {
                    Console.WriteLine($"A={string.Join(',', arr)}, result={Solution(arr)}");
                }
            }

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
        }
        #endregion


        #region helper functions
        private static Dictionary<int, int> AllNumbers(int from, int to)
        {
            var allNumbers = new Dictionary<int, int>();
            for (var i = from; i <= to; i++)
            {
                allNumbers.Add(i, i);
            }

            return allNumbers;
        }

        private static void Shift(int[] arr)
        {
            var result = new int[arr.Length];
            result[0] = arr[arr.Length - 1];
            for (var j = 1; j < arr.Length; j++)
            {
                result[j] = arr[j - 1];
            }

            Array.Copy(result, arr, result.Length);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static void SetAll(int[] arr, int value)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }
        }

        public static object BinarySearchIterative(int[] arr, int value)
        {
            var min = 0;
            var max = arr.Length - 1;
            while (min <= max)
            {
                var mid = (min + max) / 2;
                if (value == arr[mid])
                {
                    return ++mid;
                }

                if (value < arr[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "Nil";
        }

        #endregion
    }
}
