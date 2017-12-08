using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{

//Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
//Предусмотреть методы сложения, вычитания, умножения и деления дробей.
//Написать программу, демонстрирующую все разработанные элементы класса.

    class Program
    {
        static void Main(string[] args)
        {
            Fraction x1 = new Fraction(1, 3);

            Fraction x2 = new Fraction(3, 11);

            Fraction x3 = new Fraction();

            Console.WriteLine($"Используются дроби: {x1.ToString()} и {x2.ToString()}");

            Console.WriteLine($"Сложение: {x1.ToString()} + {x2.ToString()} = ");
            x3 = x1 + x2;
            Console.WriteLine(x3.ToString());

            Console.WriteLine($"Вычитание: {x1.ToString()} - {x2.ToString()} = ");
            x3 = x1 - x2;
            Console.WriteLine(x3.ToString());

            Console.WriteLine($"Умножение: {x1.ToString()} * {x2.ToString()} = ");
            x3 = x1 * x2;
            Console.WriteLine(x3.ToString());

            Console.WriteLine($"Деление: {x1.ToString()} / {x2.ToString()} = ");
            x3 = x1 / x2;
            Console.WriteLine(x3.ToString());

            Console.ReadKey();


        }
    }
}
