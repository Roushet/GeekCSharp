using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        //1. Создать программу, которая будет проверять корректность ввода логина.Корректным логином 
        //будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и 
        //    при этом цифра не может быть первой.

        //а) без использования регулярных выражений;
        //б) **с использованием регулярных выражений.

        static void Main(string[] args)
        {
            string input = "";
            Console.WriteLine("Добро пожаловать в программу проверки корректности логинов! Введите 0 проверки с помощью регулярных выражений");
            do
            {
                Console.WriteLine("\nВведите логин:");
                input = Console.ReadLine();
                //проверка для выхода
                if (input == "0") break;

                if (IsCorrectLogin(input))
                {
                    Console.WriteLine("Этот логин корректный.");
                }
                else Console.WriteLine("Этот логин имеет неверный формат");

            } while (input != "0");

            Console.WriteLine("Проверка с помощью регулярных выражений Введите 0 для завершения работы");
            do
            {
                Console.WriteLine("\nВведите логин:");
                input = Console.ReadLine();
                //проверка для выхода
                if (input == "0") break;

                if (IsCorrectLoginRegex(input))
                {
                    Console.WriteLine("Этот логин корректный.");
                }
                else Console.WriteLine("Этот логин имеет неверный формат");

            } while (input != "0");
        }

        /// <summary>
        /// Проверка без использования регулярных выражений
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        static bool IsCorrectLogin(string login)
        {

            if (login.Length < 2 || login.Length > 10) return false;

            char[] arr = login.ToCharArray();

            //цифра не может быть первой
            if (Char.IsDigit(arr[0])) return false;

            bool result = true;

            foreach (char ch in arr)
            {
                if (!Char.IsLetter(ch) && !Char.IsDigit(ch)) return false;
            }
            return result;
        }

        /// <summary>
        /// Проверка с использованием регулярных выражений
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        static bool IsCorrectLoginRegex(string login)
        {
            string pattern = @"^[^0-9][A-Za-z0-9]{1,9}";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(login);
        }
    }
}
