using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Инициализация опросника

            int questionCount = 5; // количество вопросов 
            int[] numbers = new int[questionCount]; // массив для номеров вопросов
            string rawData; //строка неразобранного текста опросника
            string[] lines; //массив разобранного по строкам текста опросника

            QuestionData[] questions = new QuestionData[questionCount]; //создаётся массив вопросов

            rawData = GetQuestionsFromAssembly(); //получаются вопросы из сборки
            lines = rawData.Split(new char[] { '\n' }); //разбиваются по линиям
            numbers = GetFiveRandoms(lines.Length); //получаются уникальные номера вопросов

            questions = InitQuestionData(questions, lines, numbers); //массив вопросов инициализируется подготовленными данными

            #endregion

            #region Опросник

            int userScore = 0;
            int progress = 0;
            bool reply = false;
            
            Console.WriteLine("Приветствуем вас в игре \"Верю не верю\"");
            Console.WriteLine($"Вам предстоит ответить на {questionCount} вопросов.\nПриступим!");

            //основной цикл
            while (progress < 5)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Утверждение:{0}\n", questions[progress].Question);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("Вы верите, что это утверждение правда? Введите ответ.");

                reply = GetAnswer();
                //Обработка ответа
                if (
                    (reply && questions[progress].Answer == "Да") ||
                    (!reply && questions[progress].Answer == "Нет")
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

            Console.WriteLine("Игра окончена! Ваш счёт {0}", userScore);

            #endregion

            Console.ReadKey();
        }

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
                Console.WriteLine("Ошибка ввода. Пожалуйста, вводите только 1 или 2.");
                Console.ForegroundColor = ConsoleColor.White;

            } while (key.Key != ConsoleKey.D1 || key.Key != ConsoleKey.D2);//странно, но неравенство != не работает с енумератором КонсольКей
            return false;
        }

        static string GetQuestionsFromAssembly()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Task6.Questions.txt";
            Stream resourceStream = assembly.GetManifestResourceStream(resourceName);

            StreamReader streamReader = new StreamReader(resourceStream);
            string file = streamReader.ReadToEnd();

            return file;
        }

        static int[] GetFiveRandoms(int maxIndex)
        {
            int[] fiveRandomInts = new int[5];
            Random rnd = new Random();
            int temp = 0;

            for (int i = 0; i < 5; i++)
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

        static bool CheckArray(int[] array, int num)
        {
            foreach (int i in array)
            {
                if (i == num) return true;
            }
            return false;
        }

        static QuestionData[] InitQuestionData(QuestionData[] qData, string[] rawData, int[] numbers)
        {

            for (int i = 0; i < numbers.Length; i++)
            {
                string[] rawLine = rawData[numbers[i]].Split(new string[] { ";" }, StringSplitOptions.None);
                qData[i] = new QuestionData();

                qData[i].Question = rawLine[0];
                qData[i].Answer = rawLine[1];
                qData[i].Description = rawLine[2];
            }

            return qData;
        }
    }
}
