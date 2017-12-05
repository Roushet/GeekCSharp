using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{

    //Евдокимов Владимир
    
    //7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b);

    //б) * Разработать рекурсивный метод, который считает сумму чисел от a до b.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Рекурсивная печать");
            RecursivePrint(5, 15);
            Console.WriteLine();

            Console.WriteLine("Рекурсивная сумма");
            Console.WriteLine(RecursiveSum(1, 4));

            Console.ReadKey();
        }

        // 7 а
        /// <summary>
        /// Метод, который с помощью рекурсии печатает числа в строку
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void RecursivePrint(int a, int b)
        {
            //проверка на адекватность входных данных
            if (a > b)
            {
                return;
            }

            //Вывод, если условие соблюдается
            if (a <= b)
            {
                Console.Write("{0} ", a);
                a++;
                RecursivePrint(a, b);
            }
        }

        //7 b
        /// <summary>
        /// Метод, который с помощью рекурсии суммирует все числа в заданном диапазоне
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int RecursiveSum(int a, int b)
        {
            if (a == b) return b;
            else
            {
                return a + RecursiveSum(a + 1, b);
            }

        }
    }
}
