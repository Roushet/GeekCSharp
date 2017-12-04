using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task5
{

    //5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;

    //б) * Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
    class Program
    {
        static void Main(string[] args)
        {
            float lowerBound = 18.5F; // нижняя граница нормы
            float upperBound = 24.9F; // верхняя граница нормы

            WriteLine("Программа считает индекс массы тела и выдаёт совет по коррекции.\n");
            WriteLine("Введите ваш вес в кг.");
            int weight = GetNumber();

            WriteLine("Введите ваш рост в см.");
            int height = GetNumber();
            float bmi = BMI(weight, height);
            WriteLine("Ваш идекс массы тела: {0:#.##}", bmi);

            //вес ниже нормы
            if (bmi < lowerBound)
            {
                WriteLine("Вы слишком худы для своего веса.");
                //5б
                WriteLine("Вам нужно набрать как минимум {0:#.##} кг.", lowerBound * Math.Pow((float)height / 100, 2) - (float)weight);
            }

            //вес выше нормы
            if (bmi > upperBound)
            {
                WriteLine("У вас лишний вес.");
                //5б
                WriteLine("Вам сбросить как минимум {0:#.##} кг.", (float)weight - upperBound * Math.Pow((float)height / 100, 2));
            }
            
            //Вес в пределах нормы
            if (bmi <= upperBound && bmi >= lowerBound) Console.WriteLine("Ваш индекс массы тела в пределах нормы. Всё в порядке.");

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
        /// <summary>
        /// Возвращает индекс массы тела
        /// </summary>
        /// <param name="bodyMass">масса тела в кг.</param>
        /// <param name="height">рост в см.</param>
        /// <returns></returns>
        static float BMI(int bodyMass, int height)
        {
            float heightM = (float)height / 100;

            return (bodyMass / (heightM * heightM));
        }
    }
}
