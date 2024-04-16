// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int id = 5;
int id2 = 2;
int Increment = 0;

string threadNUmber1 = "Thread number 1";
string threadNUmber = "Thread number 2";


Thread newThread = new Thread(() => ThreadMethod(id, threadNUmber1));

Thread newThread2 = new Thread(() => ThreadMethod(id2, threadNUmber));
newThread.Start();
newThread2.Start();



newThread.Join();
newThread2.Join();

Console.WriteLine("Done");


static void ThreadMethod(int id, string message)
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{i} {id}, {message}");
    }
}
object lockObject = new object();

Thread CounterThread = new Thread(() => IncrementThread());

Thread CounterThread2 = new Thread(() => IncrementThread2());

CounterThread.Start();
CounterThread2.Start();

CounterThread2.Join();
CounterThread.Join();



void IncrementThread()
{
    for (int i = 0; i < 100; i++)
    {
        lock (lockObject) 
        {
            Increment++;
            Console.WriteLine($"Incremented to {Increment}");
        }
        Thread.Sleep(100);  
    }
}
void IncrementThread2()
{
    for (int i = 0; i < 100; i++)
    {
        lock (lockObject)  
        {
            Console.WriteLine($"Read by Thread 2: {Increment}");
        }
        Thread.Sleep(100);  
    }
}



