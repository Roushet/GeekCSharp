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
            Array2D arr = new Array2D(3, 4, 10, 30);


            Console.WriteLine("Сумма {0}", arr.Sum());

            Console.WriteLine("Сумма выше заданного значения {0}", arr.SumHigherThan(15));

            Console.WriteLine("Минимальный элемент {0}", arr.Min);

            Console.WriteLine("Максимальный элемент {0}", arr.Max);
            int h = 0;
            int v = 0;
            arr.RefMaxIndex(out h, out v);

            Console.WriteLine("Номер максимального элемента через реф {0}, {1}", h, v);

            Console.WriteLine(arr.ToString());
            Console.WriteLine();

            Console.WriteLine("Запись в файл");
            arr.Write(arr, "C:\\Temp\\1.txt");

            Console.WriteLine("Обнуление массива");
            arr.Clear();
            Console.WriteLine(arr.ToString());
            Console.WriteLine();

            Console.WriteLine("Чтение в массив из файла");
            arr = arr.Read("C:\\Temp\\1.txt");
            Console.WriteLine(arr.ToString());

            Console.ReadKey();
        }
    }
}
