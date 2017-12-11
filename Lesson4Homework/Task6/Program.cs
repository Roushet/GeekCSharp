using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{

    //Владимир Евдокимов
        //6. *** Написать игру “Верю.Не верю”. В файле хранятся некоторые данные и правда это или нет.Например:
        //“Шариковую ручку изобрели в древнем Египте”, “Да”.

        //Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задает их игроку.
        //Игрок пытается ответить правда или нет, то что ему загадали и набирает баллы.Список вопросов
        //ищите во вложении или можно воспользоваться Интернетом.

    class Program
    {
        static void Main(string[] args)
        {
            #region Инициализация опросника

            int questionCount = 5; // количество вопросов, можно менять, главное что было было меньше 210

            int[] numbers = new int[questionCount]; // массив для номеров вопросов
            string rawData; //строка неразобранного текста опросника
            string[] lines; //массив разобранного по строкам текста опросника

            QuestionData[] questions = new QuestionData[questionCount]; //создаётся массив вопросов
            rawData = QuestionData.GetQuestionsFromAssembly(); //получаются вопросы из сборки

            lines = rawData.Split(new char[] { '\n' }); //разбиваются по линиям
            numbers = GetRandomInts(lines.Length, questionCount); //получаются уникальные номера вопросов

            questions = QuestionData.InitQuestionData(questions, lines, numbers); //массив вопросов инициализируется подготовленными данными

            #endregion

            #region Опросник

            int userScore = 0;
            int progress = 0;
            bool reply = false;

            Console.WriteLine("Приветствуем вас в игре \"Верю не верю\"");
            Console.WriteLine($"Вам предстоит ответить на {questionCount} вопросов.\nПриступим!");

            //основной цикл
            while (progress < questionCount)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nУтверждение:{0}\n", questions[progress].Question);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("Вы верите, что это утверждение правда? Введите ответ.");

                reply = GetAnswer();
                //Обработка ответа
                if (
                    (reply && questions[progress].Answer) ||
                    (!reply && !questions[progress].Answer)
                    )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nВерно! {0}", questions[progress].Description);
                    userScore += 1;
                }
                else
                {
                    Console.WriteLine("\nНеверно! {0}", questions[progress].Description);
                }
                progress++;
            }

            Console.WriteLine("Игра окончена! Ваш счёт {0} из {1}", userScore, questionCount);

            #endregion

            Console.ReadKey();
        }
        /// <summary>
        /// Ждёт ввода с клавиатуры.
        /// Возращает ответ в виде переменной true(да) / false (нет)
        /// </summary>
        /// <returns>ответ</returns>
        static bool GetAnswer()
        {
            ConsoleKeyInfo key;

            Console.WriteLine("1 -- Да, согласен\t 2 -- Нет, не согласен");

            do
            {
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    return true;
                }
                if (key.Key == ConsoleKey.D2)
                {
                    return false;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nОшибка ввода. Пожалуйста, вводите только 1 или 2.");
                Console.ForegroundColor = ConsoleColor.White;

            } while (key.Key != ConsoleKey.D1 || key.Key != ConsoleKey.D2);//странно, но неравенство != не работает с енумератором КонсольКей
            return false;
        }


        /// <summary>
        /// Возвращает список из 5 уникальных интов, от 0 до параметра
        /// которые потом 
        /// будут номерами строк при выборе вопросов из файла
        /// </summary>
        /// <param name="maxIndex">Максимальное значение интервала для рандома</param>
        /// <returns></returns>
        static int[] GetRandomInts(int maxIndex, int size)
        {
            int[] fiveRandomInts = new int[size];
            Random rnd = new Random();
            int temp = 0;

            for (int i = 0; i < size; i++)
            {
                temp = rnd.Next(0, maxIndex);
                while (CheckArray(fiveRandomInts, temp))
                {
                    temp = rnd.Next(maxIndex);
                }
                fiveRandomInts[i] = temp;

            }
            return fiveRandomInts;
        }

        /// <summary>
        /// Вспомогательный метод, который проверяет наличие числа в массиве
        /// Нужен для того, чтобы добавлять в массив только уникальные числа
        /// </summary>
        /// <param name="array"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        static bool CheckArray(int[] array, int num)
        {
            foreach (int i in array)
            {
                if (i == num) return true;
            }
            return false;
        }


    }
}
