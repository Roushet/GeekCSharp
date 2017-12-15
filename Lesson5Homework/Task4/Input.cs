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
                surename = processed[0].Trim(new char[] { '\r', '\n', '\t' });
                name = processed[1].Trim(new char[] { '\r', '\n', '\t' });

                for (int j = 2; j < processed.Length; j++)
                {
                    try
                    {
                        grades[j - 2] = Convert.ToInt32(processed[j]);
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




    }

    public class InputException : Exception
    {
        public InputException() : base() { }
        public InputException(string message) : base(message) { }
        public InputException(string message, Exception inner) : base(message, inner) { }
    }
}
