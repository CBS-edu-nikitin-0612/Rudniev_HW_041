using System;
using System.Threading;
using System.Text;

namespace Task2
{
    class Program
    {
        // Аргумент:
        // false - установка в несигнальное состояние.
        static AutoResetEvent auto = new (false);

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            new Thread(Function1).Start();
            new Thread(Function2).Start();

            Thread.Sleep(500);  // Дадим время запуститься вторичным потокам.

            Console.WriteLine("Нажмите на любую клавишу для перевода ManualResetEvent в сигнальное состояние.\n");
            Console.ReadKey();
            for (int i = 0; i < 2; i++)
                auto.Set();

            // Delay
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Поток 1 запущен и ожидает сигнала.");
            auto.WaitOne(); // Остановка выполнения вторичного потока 1.
            Console.WriteLine("Поток 1 завершается.");
        }

        static void Function2()
        {
            Console.WriteLine("Поток 2 запущен и ожидает сигнала.");
            auto.WaitOne(); // Остановка выполнения вторичного потока 2.
            Console.WriteLine("Поток 2 завершается.");
        }
    }
}
