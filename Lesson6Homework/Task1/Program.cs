using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    // Евдокимов Владимир


    // Описываем делегат. В делегате описывается сигнатура методов, на
    // которые сможет ссылаться делегат в дальнейшем (хранить в себе)
    public delegate double DoubleArgs(double x, double a);

    class Program
    {
        // Создаем метод, который принимает делегат
        // То есть на практике, этот метод сможет принимать любой метод
        // с такой же сигнатурой как у делегата
        public static void Table(DoubleArgs D, double x, double a, double b)
        {
            Console.WriteLine("----- X ----- A ----- Y -----");
            while (x <= b)
            {
                //внимание трюк - а заменяется на i чтобы не переписывать значение входящей переменной в итерации
                for (double i = a; i <= b;  i++)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", x, i, D(x, i));
                }
                x ++;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double SquareParam(double x, double a)
        {
            return a * x * x;
        }

        public static double SineParam(double x, double a)
        {
            return a * Math.Sin(x);
        }



        static void Main()
        {
            Console.WriteLine("Таблица функции SquareParam:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(SquareParam, -2, -2, 4);
            Console.WriteLine("Таблица функции SineParam:");
            Table(SineParam, -2, -2, 4);

            Console.ReadKey();
        }
    }
}