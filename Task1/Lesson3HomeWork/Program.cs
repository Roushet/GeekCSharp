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
            Complex num1 = new Complex(1, 2);

            Complex num2 = new Complex(3, 5);

           num1.Plus(num2);
        }
    }
}
