using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task2
{

    //2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
    //Требуется подсчитать сумму всех нечетных положительных чисел.
    //Сами числа и сумму вывести на экран; Используя tryParse;

    //б) Добавить обработку исключительных ситуаций на то, что могут 
    //быть введены некорректные данные.При возникновении ошибки вывести сообщение.

    class Program
    {
        //2a
        static void Main(string[] args)
        {
            WriteLine("Программа подсчитывает сумму всех нечетных положительных чисел, которые вводит пользователь.");

            int num = 0;
            int result = 0;
            string numbers = "";
            do
            {
                WriteLine("\nВведите целое число для расчёта, или 0 для вывода результата");
                num = GetNumber();
                WriteLine($"Вы ввели {num}");


                if (num == 0) break;

                if (num > 0 && num % 2 > 0)
                {
                    result += num;
                    numbers += num.ToString() + " ";
                }

            } while (num != 0);

            WriteLine($"\n\nЧисла: {numbers}");
            WriteLine($"Результат: {result}");
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

                //2b

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
