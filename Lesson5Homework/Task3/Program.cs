using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    // 3. * Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.Регистр можно не учитывать.

    //а) с использованием методов C#
    //б) * разработав собственный алгоритм
    //Например:
    //badc являются перестановкой abcd
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "hjdakjhdkajshdkjahdkja";
            string str2 = "hjdakjhdkajshdkjahdkja";

            Console.WriteLine($"Результат сравнения методом C# {str1} и {str2} : {Interchange(str1, str2)}");
            Console.WriteLine($"Результат сравнения перебором {str1} и {str2} : {InterchangeCycle(str1, str2)}");
            Console.ReadKey();
        }

        /// <summary>
        /// Сравнение строк методами C#
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool Interchange(string str1, string str2)
        {
            //автоматом возвращает False если строки разной длины
            if (str1.Length != str2.Length) return false;

            char[] arr1 = str1.ToCharArray();
            char[] arr2 = str2.ToCharArray();

            Array.Sort(arr1);
            Array.Sort(arr2);
            
            //Используется метод из Linq
            return arr1.SequenceEqual(arr2);
        }

        /// <summary>
        /// Сравнение строк перебором
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool InterchangeCycle(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            char[] arr1 = str1.ToCharArray();
            char[] arr2 = str2.ToCharArray();

            Array.Sort(arr1);
            Array.Sort(arr2);

            bool result = true;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) result = false;
            }
            return result;
        }
    }
}
