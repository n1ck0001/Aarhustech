

using System.Diagnostics;

namespace MergeSort
{
    class Program
    {
        static void Main()
        {
            RandomArrayGenerator generator = new RandomArrayGenerator();

            // Generate random arrays of different sizes
            int[] reallyBigArray = generator.GenerateRandomArray(200000);
            int[] arrThousand = generator.GenerateRandomArray(1000);

            // Test different sorting algorithms
            Console.WriteLine("Start Sorting");
            
            TestSortingAlgorithm.RunSortingAlgorithm("MergeSort", MergeSort.Sort, reallyBigArray);
            generator.ShuffleArray(reallyBigArray);
            Console.WriteLine("Start Sorting");
            TestSortingAlgorithm.RunSortingAlgorithm("ParallelMergeSort", ParallelMergeSort.Sort, arrThousand);
            Console.WriteLine("Start Sorting");
            TestSortingAlgorithm.RunSortingAlgorithm("ThresholdParallelMergeSort", ThresholdParallelMergeSort.Sort, reallyBigArray);
            generator.ShuffleArray(reallyBigArray);
            Console.WriteLine("Start Sorting");
            TestSortingAlgorithm.RunSortingAlgorithm("ThreadPoolParallelMergeSort", ThreadpoolParallelMergeSort.Sort, reallyBigArray);


        }
    }

}