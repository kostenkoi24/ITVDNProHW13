using System;
using System.Linq;
using System.Threading.Tasks;


namespace Homework13_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 1000000;

            int[] array = new int[arraySize];

            Random random = new Random();

            // Ініціалізація масиву даних є позитивними значеннями.
            Parallel.For(0, arraySize, (i) => array[i] = random.Next(1, 10));

            

            // Запит PLINQ для пошуку непарні числа.
            ParallelQuery<int> negatives = from element in array.AsParallel()
                                           where element % 2 == 0
                                           select element;

            foreach (int element in negatives)
                Console.Write(element + " ");

            // Delay
            Console.ReadKey();
        }
    }
}
