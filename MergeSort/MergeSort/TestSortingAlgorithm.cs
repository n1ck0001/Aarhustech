using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public static class TestSortingAlgorithm
    {
        public static void RunSortingAlgorithm(string algorithmName, Action<int[]> sortingAlgorithm, int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            sortingAlgorithm(arr);
            stopwatch.Stop();
            Console.WriteLine($"{algorithmName} sorting took: {stopwatch.Elapsed.TotalMilliseconds} milliseconds for array of size: {arr.Length}");
        }
    }
    
}
