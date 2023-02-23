using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Homework13_2
{
    class Program
    {

        static void Method1()
        {
            Console.WriteLine("Method1: запущений.");
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(1000);
                Console.Write("1");
            }
            Console.WriteLine("Method1: завершено.");
        }

        static void Method2()
        {
            Console.WriteLine("Method2: запущений.");
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(1000);
                Console.Write("2");
            }
            Console.WriteLine("Method2: завершено.");
        }


        static void PMethod()
        {
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 2; 
            Parallel.Invoke(options, Method1, Method2);

        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Основний потік запущений.");

            Console.WriteLine("Кількість логічних ядер CPU:" + Environment.ProcessorCount);

            Console.ReadKey();

            
            Action action = new Action(PMethod);

            Task task = new Task(action);
            task.Start();

            Console.WriteLine("Main(): запущений.");
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(1000);
                Console.Write("Main()");
            }
            Console.WriteLine("Main(): завершено.");


            Console.WriteLine("Основний потік завершено.");

            // Delay
            Console.ReadKey();
        }
    }
}
