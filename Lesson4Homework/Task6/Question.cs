using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    /// <summary>
    /// Класс, в котором описан тип Вопрос и методы для его заполнения
    /// </summary>
    class QuestionData
    {
        private string question;
        private bool answer;
        private string description;

        public string Question { get => question; set => question = value; }
        public bool Answer { get => answer; set => answer = value; }
        public string Description { get => description; set => description = value; }

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public QuestionData()
        {
            question = "";
            answer = false;
            description = "";
        }

        /// <summary>
        /// Загружает вопросы из сборки, т.е. текстовичка Questions, который 
        /// вшит в тело программы
        /// </summary>
        /// <returns>строку</returns>
        public static string GetQuestionsFromAssembly()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Task6.Questions.txt";
            Stream resourceStream = assembly.GetManifestResourceStream(resourceName);

            StreamReader streamReader = new StreamReader(resourceStream);
            string file = streamReader.ReadToEnd();
            streamReader.Close();

            return file;
        }

        /// <summary>
        /// Метод, который инициализиует массив вопросов
        /// и заполняет его передаваемыми данными
        /// </summary>
        /// <param name="qData">Пустой массив вопросов</param>
        /// <param name="rawData">Массив строк, где каждая строка - один вопрос</param>
        /// <param name="numbers">Массив неповторяющися целых чисел</param>
        /// <returns></returns>
        public static QuestionData[] InitQuestionData(QuestionData[] qData, string[] rawData, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                string[] rawLine = rawData[numbers[i]].Split(new string[] { ";" }, StringSplitOptions.None);
                qData[i] = new QuestionData();

                qData[i].Question = rawLine[0];

                if (rawLine[1] == "Да")
                {
                    qData[i].Answer = true;
                }
                else qData[i].Answer = false;

                qData[i].Description = rawLine[2];
            }

            return qData;
        }
    }

}
