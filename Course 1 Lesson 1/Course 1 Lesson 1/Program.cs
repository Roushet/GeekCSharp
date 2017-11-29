﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Questionnaire
{
    class Program
    {
        static void Main(string[] args)
        {
            //определение переменных
            string name = "";
            string surename = "";
            int age = 0;
            int height = 0;
            int bodyMass = 0;

            int ageNum = 0;
            int heightNum = 0;
            int bodyMassNum = 0;
            
            //Добавляю для красоты
            TextInfo myTI = new CultureInfo("ru-RU", false).TextInfo;

            WriteLine("Добро пожаловать в программу анкета. Пожалуйста, ответьте на несколько вопросов.\n\n");
            //имя
            WriteLine("Введите ваше имя и нажмите Enter:");
            name = ReadLine();
            //фамилия
            WriteLine("Введите вашу фамилию и нажмите Enter");
            surename = ReadLine();
            //возраст
            WriteLine("Введите ваш возраст и нажмите Enter");
            age = GetNumber();
            //рост
            WriteLine("Введите ваш рост в сантиметрах и нажмите Enter");
            height = GetNumber();
            //вес
            WriteLine("Введите ваш вес и нажмите Enter");
            bodyMass = GetNumber();

            WriteLine();

            //вывод
            WriteLine();
            WriteLine("Вывод через конкатенацию. \n");

            WriteLine("Вас зовут " 
                + myTI.ToTitleCase(name) 
                + " "
                + myTI.ToTitleCase(surename)
                + " ваш возраст "
                + age.ToString()
                + " ваш рост "
                + height.ToString()
                + "(см) и ваш вес "
                + bodyMass
                +"(кг) \n Спасибо."
                );

            ReadKey();

            WriteLine("Вывод через форматирование. \n");
            WriteLine();
        }

        /// <summary>
        /// Метод для получения числового значения из строки.
        /// </summary>
        /// <returns></returns>
        static int GetNumber()
        {
            int result = 0;
            bool success = false;
            string input = "";

            while (success == false)
            {
                input = ReadLine();
                success = Int32.TryParse(input, out result);
                if (success == false)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("ОШИБКА: введенное значение не является целым числом, попробуйте ещё раз.");
                    ResetColor();
                }
            }
            return result;
        }
    }
}