using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    //Реализовать конструктор,
    //заполняющий массив случайными числами. Создать методы, которые возвращают сумму
    //всех элементов массива, сумму всех элементов массива больше заданного, свойство,
    //возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод,
    //возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)

    class Array2D
    {
        int[,] arr;

        public Array2D(int sizeH, int sizeV)
        {
            arr = new int[sizeH, sizeV];
        }

        public Array2D(int sizeH, int sizeV, int min, int max)
        {
            arr = new int[sizeH, sizeV];
            Random random = new Random();

            for (int i = 0; i < sizeH; i++)
                for (int j = 0; j < sizeV; j++)
                    arr[i, j] = random.Next(min, max);
        }

        /// <summary>
        /// Возвращает сумму всех элементов массива
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            int sum = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    sum += arr[i, j];
            return sum;
        }

        /// <summary>
        /// возвращает сумму всех элементов, значние которых больше чем...
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int SumHigherThan(int value)
        {
            int sum = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] > value) sum += arr[i, j];
            return sum;
        }
        /// <summary>
        /// Очищает массив: делает значение всех элементов
        /// равным нулю
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = 0;
        }
        /// <summary>
        /// Возвращает минимальное значение из массива
        /// </summary>
        public int Min
        {
            get
            {
                int min = arr[0, 0];

                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] < min) min = arr[i, j];
                return min;
            }
        }
        
        /// <summary>
        /// Возвращает максимальное значение
        /// </summary>
        public int Max
        {
            get
            {
                int max = arr[0, 0];

                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] > max) max = arr[i, j];
                return max;
            }
        }

        /// <summary>
        /// Возвращает индекс первого максимального элемента
        /// в массиве
        /// </summary>
        public int[] MaxIndex
        {
            get
            {
                int[] result;
                result = new int[2];
                int max = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] > max)
                        {
                            max = arr[i, j];
                            result[0] = i;
                            result[1] = j;
                        }
                return result;
            }


        }

        /// <summary>
        /// Возвращает индекс первого максимального элемента 
        /// в массиве с помощью реф
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        /// <returns></returns>
        public int RefMaxIndex(out int horizontal, out int vertical)
        {
            horizontal = 0;
            vertical = 0;

            int max = arr[0, 0];

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        horizontal = i;
                        vertical = j;
                    }
            return max;
        }

        /// <summary>
        /// Пишет массив в текстовый файл с указанным адресом
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="address"></param>
        public void Write(Array2D arr, string address)
        {
            StreamWriter writer = new StreamWriter(address);
            writer.WriteLine(arr.ToString());
            writer.Close();
        }

        /// <summary>
        /// Индексатор для работы с массивом
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <returns></returns>
        public int this[int index1, int index2]    // Indexer declaration  
        {
            get => arr[index1, index2];
            set => arr[index1, index2] = value;

        }

        /// <summary>
        /// Читает массив из файл и создаёт массив для него
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public Array2D Read(string address)
        {
            StreamReader reader = new StreamReader(address);
            string temp = reader.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
            string[] horizontal = temp.Split((new char[] { '\n' }));
            string[] vertical = horizontal[0].Split((new char[] { ',' }));

            Array2D newarr = new Array2D(horizontal.Length, vertical.Length);

            for (int i = 0; i < horizontal.Length; i++)
            {
                string[] currentRow = horizontal[i].Split((new char[] { ',' }));
                for (int j = 0; j < currentRow.Length; j++)
                {
                    newarr[i, j] = Convert.ToInt32(currentRow[j]);
                }
            }
            return newarr;
        }

        /// <summary>
        /// Оверрайд метода стринг, используется при выводе в файл
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string ouput = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    ouput += arr[i, j];
                    if (j != arr.GetLength(1)-1) ouput += ",";
                    ;
                }

                if (i != arr.GetLength(0)-1)
                    ouput += "\n"; // Переход на новую строчку
            }
            return ouput;
        }
    }
}