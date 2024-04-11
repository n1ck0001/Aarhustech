using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers_Anonymous = new List<int> { 5, 2, 8, 1, 9, 3 };
            List<int> numbers_lambda = new List<int> { 8, 3, 9, 2, 1, 5 };

            // Sort using anonymous method
            Console.WriteLine("Sorted List (Anonymous Method): " + string.Join(", ", numbers_Anonymous));
            // Sort using lambda expression
            Console.WriteLine("Sorted List (Lambda Expression): " + string.Join(", ", numbers_lambda));

            numbers_Anonymous.Sort(delegate (int a, int b)
            {
                return a.CompareTo(b);
            });

            numbers_lambda.Sort((a, b) =>  a.CompareTo(b));


            // Sort using anonymous method
            Console.WriteLine("Sorted List (Anonymous Method): " + string.Join(", ", numbers_Anonymous));
            // Sort using lambda expression
            Console.WriteLine("Sorted List (Lambda Expression): " + string.Join(", ", numbers_lambda));
        }


       
    }
}
