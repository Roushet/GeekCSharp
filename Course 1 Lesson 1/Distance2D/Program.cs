using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Distance2D
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = 0;
            double x2 = 0;
            double y1 = 0;
            double y2 = 0;
            WriteLine("Программа вычисляет расстояние на плоскости между двумя \nточками с коодинатами (х1 у1) и (х2 у2).\n");

            Write("Введите значение х1 и нажмите Enter: ");
            x1 = GetNumber();

            Write("Введите значение y1 и нажмите Enter: ");
            y1 = GetNumber();

            Write("Введите значение х2 и нажмите Enter: ");
            x1 = GetNumber();

            Write("Введите значение y2 и нажмите Enter: ");
            y1 = GetNumber();

            Write("Расстояние между точками: {0:#.##}", Calculate(x1, x2, y1, y2));
            ReadKey();

        }
        /// <summary>
        /// Вычисляет расстояние между двумя точками.
        /// Принимает 2 пары координат.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        static double Calculate(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        /// <summary>
        /// Получает строку из консоли, превращает её в число и возвращает
        /// </summary>
        /// <returns></returns>
        static double GetNumber()
        {
            double result = 0;
            bool success = false;
            string input = "";

            while (success == false)
            {
                input = ReadLine();
                //если  пользователь ввёл число в неправильном формате - исправляем
                input = input.Replace(".", ",");
                success = double.TryParse(input, out result);
                if (success == false)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("ОШИБКА: введенное значение не является числом, попробуйте ещё раз.");
                    ResetColor();
                }
            }
            return result;
        }

    }
}
