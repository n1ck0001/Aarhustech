using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learning about threads");

            int s = GetMicroSleep();
            int numberOfThreads = GetNumberOfThreads();
            Vector sharedVector = new Vector(); 
            Thread[] threads = new Thread[numberOfThreads];

            for (int i = 0; i < numberOfThreads; i++)
            {
                int threadId = i + 1;
                threads[i] = new Thread(() => ThreadFunction(sharedVector, threadId, s));
                threads[i].Start();
            }

            Console.WriteLine("All threads started. Press any key to exit.");
            Console.ReadKey();

            foreach (Thread thread in threads)
            {
                thread.Join(); 
            }
        }

    static void ThreadFunction(Vector vector, int id, int microSleep)
    {
        Stopwatch stopwatch = new Stopwatch();
        while (true)
        {
            if (!vector.SetAndTest(id))
            {
                Console.WriteLine($"Error: Thread {id} found inconsistency in vector.");
            }

            stopwatch.Restart();
                while (stopwatch.ElapsedTicks < microSleep * (Stopwatch.Frequency / (1000 * 1000)))
                    Thread.Yield();
        }
    }

    static int GetMicroSleep()
    {
        Console.WriteLine("Enter the sleep time in microseconds:");
        return Convert.ToInt32(Console.ReadLine());
    }

    static int GetNumberOfThreads()
        {
            Console.WriteLine("Enter the number of threads (1-100):");
            int number = Convert.ToInt32(Console.ReadLine());
            return number;
        }
    }
}
