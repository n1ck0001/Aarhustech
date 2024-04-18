using System;
using System.Threading;

namespace MergeSort
{
    public class ParallelMergeSort
    {
        public static void Sort(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            if (arr.Length > 1000)
                throw new Exception (nameof(arr) + "Should not be over a 1.000 in length ");

            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                // Create threads for sorting left and right halves
                Thread leftThread = new Thread(() => Sort(arr, left, mid));
                Thread rightThread = new Thread(() => Sort(arr, mid + 1, right));

                // Start the threads
                leftThread.Start();
                rightThread.Start();

                // Join the threads to wait for them to finish
                leftThread.Join();
                rightThread.Join();

                // Merge the sorted halves
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            // Copy data to temp arrays
            for (int i = 0; i < n1; ++i)
                leftArr[i] = arr[left + i];
            for (int j = 0; j < n2; ++j)
                rightArr[j] = arr[mid + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first and second subarrays
            int iLeft = 0, iRight = 0;

            // Initial index of merged subarray array
            int k = left;
            while (iLeft < n1 && iRight < n2)
            {
                if (leftArr[iLeft] <= rightArr[iRight])
                {
                    arr[k] = leftArr[iLeft];
                    iLeft++;
                }
                else
                {
                    arr[k] = rightArr[iRight];
                    iRight++;
                }
                k++;
            }

            // Copy remaining elements of leftArr[] if any
            while (iLeft < n1)
            {
                arr[k] = leftArr[iLeft];
                iLeft++;
                k++;
            }

            // Copy remaining elements of rightArr[] if any
            while (iRight < n2)
            {
                arr[k] = rightArr[iRight];
                iRight++;
                k++;
            }
        }
    }

}
