using System;
using System.IO;
using System.Threading;

namespace AditionalTask
{
    class Program
    {
        static Semaphore semaphore = new Semaphore(3, 5, "ThreadsAditionalTask");
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[30];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Function);
                threads[i].Name = i.ToString();
                threads[i].Start();
                threads[i].Join();
            }
            Console.WriteLine("Successfully completed!");
        }
        static void Function()
        {
            semaphore.WaitOne();
            FileStream stream = File.Open("Threads.log", FileMode.Append);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine($"Thread {Thread.CurrentThread.Name} got access.");
                Thread.Sleep(100);
                writer.WriteLine($"Thread {Thread.CurrentThread.Name} --- work completed.");
            }
            semaphore.Release();
        }
    }
}
