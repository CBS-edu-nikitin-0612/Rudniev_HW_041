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
            Thread.Sleep(500);

            //Console.WriteLine("Нажмите на любую клавишу для перевода AutoResetEvent в сигнальное состояние.\n");
            //Console.ReadKey();
            if (flag)
                auto.Set();

            //Console.WriteLine("Нажмите на любую клавишу для перевода AutoResetEvent в сигнальное состояние.\n");
            //Console.ReadKey();
            if (flag)
                auto.Set();

            Console.ReadKey();
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
