// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int id = 5;
int id2 = 2;

string threadNUmber1 = "Thread number 1";
string threadNUmber = "Thread number 2";


Thread newThread = new Thread(() => ThreadMethod(id, threadNUmber1));

Thread newThread2 = new Thread(() => ThreadMethod(id2,threadNUmber));
newThread.Start();
newThread2.Start();



newThread.Join();
newThread2.Join();

Console.WriteLine("Done");

Console.ReadLine();

static void ThreadMethod(int id,string message)
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{i} {id}, {message}");

    }

}




    