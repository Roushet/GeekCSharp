using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Написать метод возвращающий минимальное из трех чисел.
//2. Написать метод подсчета количества цифр числа.

namespace Lesson2HomeWork
{
    class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("Возвращает минимальное число из трёх: 105, 50, 5");
            Console.WriteLine(MinOfThree(105, 50, 5));

            Console.WriteLine("Считает и возвращает количество разрядов в числе 114");
            Console.WriteLine("Result of 114: {0}", DigitNum(114));

            Console.ReadKey();
        }


        // 1.
        /// <summary>
        /// Возвращает минимальное из трёх переданных целых
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static int MinOfThree(int a, int b, int c)
        {
            if (a < b & a < c) return a;
            else if (b < c) return b;
            else return c;
        }

        // 2.
        /// <summary>
        /// Считает количество разрядов целого числа
        /// Возвращает так же целое число
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static int DigitNum(int num)
        {
            int digit = 0;
            //если пользователь вводит отрицательное число
            num = Math.Abs(num);
            do
            {
                digit++; //в первом входе инкрементирует разряд всегда
                num /= 10;
            } while (num > 0); //повторяет цикл, если после деления на 10 что-то осталось 

            return digit;
        }

    }
}
