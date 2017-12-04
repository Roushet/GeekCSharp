using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Евдокимов Владимир
//4. Реализовать метод проверки логина и пароля.На вход подается логин и пароль.
//  На выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин:root, Password:GeekBrains). 
//  Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
//  программа пропускает его дальше или не пропускает.С помощью цикла do while ограничить ввод пароля тремя попытками.

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //счётчик попыток
            int attempts = 3;
            bool auth = false;

            Console.WriteLine("Добро пожаловать!\nПожалуйста, представьтесь системе.\n\n");

            do
            {
                attempts--;

                Console.WriteLine("Введите логин: ");
                string login = Console.ReadLine();

                Console.WriteLine("Введите пароль: ");
                string pass = Console.ReadLine();

                auth = Authenticate(login, pass);

                //если авторизация неуспешна, то писать осколько осталось
                //если успешна, то выходить из цикла
                if (!auth) Console.WriteLine("Осталось {0} попыток", attempts);
                else
                {
                    Console.WriteLine($"Авторизация успешна!\nДобро пожаловать, {login}");
                    break;
                }
                //если попытки кончились - выходить из цикла
            } while (attempts > 0);

            //в конце программы проверяем успех авторизации, если не успех - то пишем сообщение
            if (!auth) Console.WriteLine("Попытки входа исчерпаны. Попробуйте позднее.");
            Console.ReadKey();
        }
        /// <summary>
        /// Проверка авторизации по логину и паролю.
        /// </summary>
        /// <param name="login">логин пользователя</param>
        /// <param name="pass">пароль пользователя</param>
        /// <returns></returns>
        static bool Authenticate(string login, string pass)
        {
            if (login == "root")
            {
                if (pass == "GeekBrains")
                {
                    return true;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ОШИБКА: логин или пароль не верны!\n");
            Console.ResetColor();

            return false;
        }
    }
}
