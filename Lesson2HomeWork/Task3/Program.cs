using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Программа подсчитывает сумму всех нечетных положительных чисел, которые вводит пользователь.\n");

            int num = 0;
            int result = 0;
            do
            {
                WriteLine("Введите целое число для расчёта, или 0 для вывода результата");
                num = GetNumber();
                WriteLine($"Вы ввели {num}");

                if (num == 0) break;

                if (num > 0 && num % 2 > 0) result += num;

            } while (num != 0);

            WriteLine($"\nРезультат: {result}");
            ReadKey();
        }

        /// <summary>
        /// Метод для получения числового значения из строки.
        /// </summary>
        /// <returns></returns>
        static int GetNumber()
        {
            int result = 0;
            bool success = false;
            string input = "";

            while (success == false)
            {
                input = ReadLine();
                success = Int32.TryParse(input, out result);
                if (success == false)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("ОШИБКА: введенное значение не является целым числом, попробуйте ещё раз.");
                    ResetColor();
                }
            }
            return result;
        }
    }
}
