using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Array2D
    {
        int[,] arr;

        public Array2D(int sizeH, int sizeV, int min, int max)
        {
            arr = new int[sizeH, sizeV];
            Random random = new Random();

            for (int i = 0; i < sizeH; i++)
                for (int j = 0; j < sizeV; j++)
                    arr[i, j] = random.Next(min, max);
        }

        public int Sum()
        {
                int sum = 0;

                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        sum += arr[i, j];
                return sum;
        }

        private int SumHigherThan(int value)
        {
                int sum = 0;

                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] > value) sum += arr[i, j];
                return sum;
        }

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

        public int MaxIndex
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
    }
}
