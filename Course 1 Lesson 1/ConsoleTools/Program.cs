using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleTools
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = "";
            string surename = "";
            string city = "";

            //Добавляю для красоты
            TextInfo myTI = new CultureInfo("ru-RU", false).TextInfo;

            WriteLine("Добро пожаловать в программу анкета. Пожалуйста, ответьте на несколько вопросов.\n\n");
            //имя
            WriteLine("Введите ваше имя и нажмите Enter:");
            name = ReadLine();
            //фамилия
            WriteLine("Введите вашу фамилию и нажмите Enter");
            surename = ReadLine();

            //фамилия
            WriteLine("Введите ваш город и нажмите Enter");
            surename = ReadLine();

            Console.CursorTop = Console.WindowHeight / 2;
            Console.CursorLeft = Console.WindowWidth / 2;

            WriteLine("Имя: {0} ", name);
            Console.CursorLeft = Console.WindowWidth / 2;
            WriteLine("Фамилия: {0}", surename);
            Console.CursorLeft = Console.WindowWidth / 2;
            WriteLine("Город: {0}", city);

            Console.ReadKey();

        }
    }
}
