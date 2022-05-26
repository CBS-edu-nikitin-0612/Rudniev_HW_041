using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        static Mutex mutex = new Mutex(true, "Rudniev.ThreadsTask3");
        static void Main(string[] args)
        {
            mutex.WaitOne();
            bool flag;
            do
            {
                Console.Write("Input number: ");
                string strNumber = Console.ReadLine();
                flag = double.TryParse(strNumber, out double number);
                if (flag)
                {
                    Console.WriteLine($"Square = {Math.Pow(number, 2)}");
                }
            } while (flag);
            mutex.ReleaseMutex();
        }
    }
}
