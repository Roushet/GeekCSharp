using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//Евдокимов Владимир
//а) Написать программу, которая выводит на экран ваше имя, фамилию и  город проживания.
//б) * Сделать задание, только вывод организуйте в центре экрана
//в) ** Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)


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
            city = ReadLine();


            //a
            WriteLine($"{name} {surename} из {city}");
            Pause(); //используется метод внутри класса

            //б
            string str = name + " " + surename + " из " + city;
            int posX = (WindowWidth / 2) - str.Length / 2;
            int posY = WindowHeight / 2;

            CursorLeft = posX;
            CursorTop = posY;

            
            Write($"{name} {surename} из {city}");
            Tools.Pause(); //используется вспомогательный класс
        }

        /// <summary>
        /// Пауза.
        /// Выводит строку предупреждение и ждёт нажатия любой клавиши.
        /// </summary>
        static void Pause()
        {
            WriteLine("\nНажмите любую клавишу для продолжения...\n");
            ReadKey();
        }


        /// <summary>
        /// Выводит строку в указанной точке экрана
        /// </summary>
        /// <param name="message">строка для вывода</param>
        /// <param name="posX">координата Х</param>
        /// <param name="posY">координата Y</param>
        static void Print(string message, int posX, int posY)
        {
            CursorLeft = posX;
            CursorTop = posY;

            Write(message);
        }
    }

    /// <summary>
    /// *Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).
    /// </summary>
    static class Tools
    {
        public static void Pause()
        {
            WriteLine("\nНажмите любую клавишу для продолжения...\n");
            ReadKey();
        }

        public static void Print(string message, int posX, int posY)
        {
            CursorLeft = posX;
            CursorTop = posY;

            Write(message);
        }
    }
}
