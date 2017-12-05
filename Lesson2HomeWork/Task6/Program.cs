using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    //Владимир Евдокимов
    //6. * Написать программу подсчета количества “Хороших” чисел в диапазоне от 1 до 1 000 000 000. 
    //Хорошим называется число, которое делится на сумму своих цифр. 
    //Реализовать подсчет времени выполнения программы, используя структуру DateTime.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа считает количество хороших чисел на интервале от 1 до 1 000 000 000\n Наберитесь терпения");

            DateTime before = new DateTime();
            before = DateTime.Now;
            DateTime after = new DateTime();
            

            int result = 0;
            for (int i = 1; i <= 1000000000; i++)
            {
                if(IsGoodNum(i)) result++;
            }

            
            Console.WriteLine("Всего хороших чисел: {0:N1}", result);
            after = DateTime.Now;

            var deltaTime = after - before;

            Console.WriteLine("Вычисление заняло: {0} мин {1} сек", deltaTime.Minutes, deltaTime.Seconds);
            Console.ReadKey();
        }

        /// <summary>
        /// Проверяет число на то, хороший это номер или нет
        /// </summary>
        /// <param name="num">чило для проверки</param>
        /// <returns></returns>
        static bool IsGoodNum(int num)
        {
            if (num % SumOfDigits(num) == 0) return true;
            else return false;

        }

        /// <summary>
        /// Возвращает сумму цифр числа
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static int SumOfDigits(int num)
        {
            int result = 0;

            do
            {
                
                if (num % 10 > 0) //делит на 10 с остатком, если остаток есть - записывает его в результат
                {
                    result += num % 10;
                    num /= 10;
                }
                else if (num < 10)
                {
                    result += num; //берём последний оставшийся разряд и складываем в итог, 
                    num = 0; //затем обнуляем число, чтобы выйти из цикла
                }
                else num /= 10; //если число с нулём, то просто пропускаем его

            } while (num > 0);

            return result;
        }

        static int GetNumber()
        {
            int result = 0;
            bool success = false;
            string input = "";

            while (success == false)
            {
                input = Console.ReadLine();
                success = Int32.TryParse(input, out result);
                if (success == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ОШИБКА: введенное значение не является целым числом, попробуйте ещё раз.");
                    Console.ResetColor();
                }
            }
            return result;
        }
    }
}
