using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        //Евдокимов Владимир

        //4. *а) Реализовать класс для работы с двумерным массивом.Реализовать конструктор,
        //заполняющий массив случайными числами. Создать методы, которые возвращают сумму
        //всех элементов массива, сумму всех элементов массива больше заданного, свойство,
        //возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод,
        //возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)

        //**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

        static void Main(string[] args)
        {
            Array2D arr = new Array2D(3, 3, 5, 10);
            arr.Write(arr, "C:\\Temp\\1.txt");

            Console.WriteLine(arr.ToString());
            Console.WriteLine();

            arr.Clear();
            Console.WriteLine(arr.ToString());
            Console.WriteLine();

            arr = arr.Read("C:\\Temp\\1.txt");
            Console.WriteLine(arr.ToString());

            Console.ReadKey();
        }
    }
}
