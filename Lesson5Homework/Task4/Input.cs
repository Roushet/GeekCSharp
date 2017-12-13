using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4
{
    class Input
    {
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
}
