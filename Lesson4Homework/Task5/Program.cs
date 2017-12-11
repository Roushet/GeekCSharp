using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{

    //Евдокимов Владимир

    //5. ** Существует алгоритмическая игра “Удвоитель”. В этой игре человеку предлагается какое-то число,
    //а человек должен, управляя роботом “Удвоитель”, достичь этого числа за минимальное число шагов.
    //Робот умеет выполнять несколько команд: увеличить число на 1, умножить число на 2 и сбросить
    //число до 1. Начальное значение удвоителя равно 1.

    //Реализовать класс “Удвоитель”. Класс хранит в себе поле current - текущее значение, finish - число,
    //которого нужно достичь, конструктор, в котором задается конечное число.Методы:
    //увеличить число на 1, увеличить число в два раза, сброс текущего до 1, свойство Current,
    //которое возвращает текущее значение, свойство Finish, которое возвращает конечное значение.
    //Создать с помощью этого класса игру, в которой компьютер загадывает число, а человек.выбирая из меню на экране,
    //отдает команды удвоителю и старается получить это число за наименьшее число ходов.Если человек получает число больше
    //положенного, игра прекращается.

    class Program
    {
        static void Main(string[] args)
        {
            int max = 100;
            int steps = 0;


            Console.WriteLine("Добро пожаловать в игру \"Удвоитель\"");


            //Инициализация игры
            Random random = new Random();
            Doubler goal = new Doubler();
            goal.Finish = random.Next(0, max);
            Console.WriteLine("Программа загадала число {0}.\n", goal.Finish);
            Console.WriteLine(@"Получите это число за минимальное число шагов, используя команды:
        Клавиша 1 -  Прибавить к текущему значению 1
        Клавиша 2 - Умножить текущее значнеие на 2
        Клавиша 3 - Сбросить текущее значение.");
            Console.WriteLine();

            int input;
            //Основной цикл
            do
            {
                WriteColor("\nТекущее значение: " + goal.Current +
                    " Цель: " + goal.Finish +
                    " Выполнено шагов " + steps, ConsoleColor.White);

                Console.WriteLine("Ваше действие");
                input = GetAnswer();

                switch (input)
                {
                    case 1:
                        goal.AddOne();
                        break;
                    case 2:
                        goal.Double();
                        break;
                    case 3:
                        goal.Reset();
                        break;
                    default:
                        break;
                }
                steps++;
            } while (goal.Current < goal.Finish);

            Console.WriteLine("\n");

            if (goal.Current == goal.Finish)
            {
                WriteColor("Победа! Вы достигли цели за " + steps + " шагов", ConsoleColor.Green);
            }
            else if( goal.Current > goal.Finish)
            {
                WriteColor("Поражение. Последний шаг был ошибкой.", ConsoleColor.Red);
            }
            Console.ReadKey();
        }

        static int GetAnswer()
        {
            ConsoleKeyInfo key;
            int output = 0;

            Console.WriteLine("1 -- Прибавить 1\t 2 -- Умножить на 2\t3 -- Сбросить");

            do
            {
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        output = 1;
                        break;
                    case ConsoleKey.D2:
                        output = 2;
                        break;
                    case ConsoleKey.D3:
                        output = 3;
                        break;
                    default:
                        WriteColor("\nОшибка ввода. Пожалуйста, вводите только 1 или 2.", ConsoleColor.Red);
                        break;
                }

            } while (output < 1 && output > 3);

            return output;
        }

        static void WriteColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

}
