using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4
{
    class Input
    {
        public static string[] LoadDataFromFile(string address)
        {
            string[] data;
            data = File.ReadAllText(address).Split('\r');
            return data;
        }

        /// <summary>
        /// Возвращает набор данных в правильном формате
        /// полученным из строки
        /// </summary>
        /// <param name="data"></param>
        public static void ParseDataString(string data, out string name, out string surename, out int[] grades)
        {
            name = "";
            surename = "";

            string[] processed = data.Split(new char[] { ' ', '\t' });
            if (processed.Length > 5) throw new InputException("Ошибка. Неверный формат входных данных");
            grades = new int[processed.Length - 2];
            for (int i = 0; i < processed.Length; i++)
            {
                name = processed[0];
                surename = processed[1];
                for (int j = 2; j < processed.Length; j++)
                {
                    try
                    {
                        grades[j] = Convert.ToInt32(processed[j]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка, не удаётся преобразовать строку в оценку. Неверный формат данных");
                    }
                    catch
                    {
                        Console.WriteLine("Неизвестная ошибка преобразования данных в оценки");
                    }
                }

            }
        }




        /// <summary>
        /// Считывает ввод из консоли, который удовлетворяет
        /// паттерну регекспа и максимальной длине
        /// </summary>
        /// <param name="lenght">максимальная длина строки</param>
        /// <param name="pattern">паттерн ввода</param>
        private static string GetLimitedString(int lenght, string pattern)
        {
            int counter = 0;
            ConsoleKeyInfo key;
            Regex regex = new Regex(pattern);
            string output = "";
            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter) return output;

                if (regex.IsMatch(key.KeyChar.ToString()))
                {
                    counter++;
                    Console.Write(key.KeyChar.ToString());
                    output += key.KeyChar.ToString();
                }
                else Console.Beep();

            } while (counter < lenght);

            return output;
        }
    }

    public class InputException : Exception
    {
        public InputException() : base() { }
        public InputException(string message) : base(message) { }
        public InputException(string message, Exception inner) : base(message, inner) { }
    }
}
