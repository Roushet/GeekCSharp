using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3HomeWork
{

    //1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры;

    //б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;
    class Program
    {
        static void Main(string[] args)
        {
            Complex num1 = new Complex(11, 2);
            Complex num2 = new Complex(-5, 1);

            //демонстрация работы класса
            Console.WriteLine("Числа, использование оверрайда для ToString()");
            Console.WriteLine(num1.ToString());
            Console.WriteLine(num2.ToString());

            Console.WriteLine("Сумма чисел");
            Console.WriteLine(num1.Plus(num2));

            Console.WriteLine("Произведение чисел, использование оверрайда для ToString()");
            Console.WriteLine(num1.Multiply(num2).ToString());

            Console.WriteLine("Вывод мнимой части числа 1");
            Console.WriteLine(num1.Im);

            Console.WriteLine("Вывод действительной части числа 1");
            Console.WriteLine(num1.Re);

            Console.WriteLine("Использование структуры");

            ComplexStruct num3 = new ComplexStruct(-8, 22);
            ComplexStruct num4 = new ComplexStruct(12, -5);

            Console.WriteLine("Числа, использование оверрайда для ToString()");
            Console.WriteLine(num3.ToString());
            Console.WriteLine(num4.ToString());

            Console.WriteLine("Сумма чисел");
            Console.WriteLine(num3.Plus(num4));

            Console.WriteLine("Произведение чисел, использование оверрайда для ToString()");
            Console.WriteLine(num3.Multiply(num4).ToString());

            Console.WriteLine("Вывод мнимой части числа 1");
            Console.WriteLine(num3.Im);

            Console.WriteLine("Вывод действительной части числа 1");
            Console.WriteLine(num3.Re);

            Console.ReadKey();
        }
    }
}
