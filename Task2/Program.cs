using System;
using System.Threading;

namespace Task2
{
    class Program
    {
        static AutoResetEvent auto = new AutoResetEvent(false);
        static bool flag = false;
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Thread thread = new Thread(Function);
            thread.Start();

            Thread.Sleep(1000);

            //Console.WriteLine("Нажмите на любую клавишу для перевода AutoResetEvent в сигнальное состояние.\n");
            //Console.ReadKey();
            if (flag)
            {
                Thread.Sleep(1);
                auto.Set();
            }

            Thread.Sleep(1000);

            //Console.WriteLine("Нажмите на любую клавишу для перевода AutoResetEvent в сигнальное состояние.\n");
            //Console.ReadKey();
            if (flag)
            {
                Thread.Sleep(1);
                auto.Set();
            }
        }

        static void Function()
        {
            Console.WriteLine("Красный свет");
            flag = true;
            auto.WaitOne(); 

            Console.WriteLine("Желтый");
            flag = true;
            auto.WaitOne(); 

            Console.WriteLine("Зеленый");
        }
    }
}
