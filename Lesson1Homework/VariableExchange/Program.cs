using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Евдокимов Владимир
//Написать программу обмена значениями двух переменных:
//а) с использованием третьей переменной;
//б) * без использования третьей переменной.

namespace VariableExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 8;
            int t = 0;

            Console.WriteLine("Переменные а = {0} b = {1}, меняем местами с помощью третьей переменной", a, b);

            //а
            t = a; a = b; b = t;

            Console.WriteLine("Переменные а = {0} b = {1}\n\n", a, b);

            Console.WriteLine("Переменные а = {0} b = {1}, меням обратно без третьей переменной", a, b);

            //int a = 8;
            //int b = 5;

            //б
            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("Переменные а = {0} b = {1}\n\n", a, b);

            Console.ReadKey();

        }
    }
}
