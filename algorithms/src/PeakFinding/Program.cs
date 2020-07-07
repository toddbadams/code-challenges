using System;

namespace PeakFindingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new[] { 1, 3, 4, 3, 5, 1, 3, 6 };

            var result = FindAPeak(data, data.Length - 1);
        }

        /// <summary>
        /// asymptotic complexity O(Log N)
        /// Find a peak if it exists
        /// Example { a, b, c, d, e, f, g, h, i } where a...i are numbers
        ///   position 2 (b) is a peak iff b>=a && b>=c
        ///   position 9 (i) is a peak iff i>=h
        ///
        /// This is recursive, we start in the middle and break the problem 1/2
        /// Since we only have to find a single peak, this divide and conquer solves
        /// with a log complexity
        /// </summary>
        public static int FindAPeak(int[] arr, int n)
        {
            var lowerBound = 0;
            var upperBound = n;

            while (true)
            {
                n = (upperBound + lowerBound) / 2;

                if (arr[n] >= arr[n - 1] && arr[n] >= arr[n + 1])
                    return n;  // this is a peak, return it's index

                if (arr[n] <= arr[n - 1])
                {
                    upperBound = n - 1; // Peak is lower in array
                    continue;
                }

                if (arr[n] <= arr[n + 1])
                {
                    lowerBound = n + 1;  // Peak is higher in array
                }
            }
        }
    }
}
