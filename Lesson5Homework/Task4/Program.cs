using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        //На вход программе подаются сведения о сдаче экзаменов учениками 9-х
        //классов некоторой средней школы.В первой строке сообщается количество
        //учеников N, которое не меньше 10, но не превосходит
        //100, каждая из следующих N строк имеет следующий формат:
        //<Фамилия> <Имя> <оценки>,
        //где<Фамилия> – строка, состоящая не более чем из 20 символов, <Имя> – строка,
        //состоящая не более чем из 15 символов, <оценки> – через пробел
        //три целых числа, соответствующие оценкам по пятибалльной системе.
        //<Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом. Пример входной строки:
        //Иванов Петр 4 5 3
        //Требуется написать как можно более эффективную программу,
        //которая будет выводить на экран фамилии и имена трех
        //худших по среднему баллу учеников. Если среди остальных
        //есть ученики, набравшие тот же средний балл, что и один из трех худших, то следует вывести и их фамилии и имена.
        static void Main(string[] args)
        {
            string[] rawData = Input.LoadDataFromFile("..\\Pupils.txt");
            Console.WriteLine($"В файле содержаться данные на {rawData[0]} учеников");

            Pupil[] pupils = Pupil.ListPupils(rawData);
            int i = 1;
            //список учеников, если нужен
            //foreach (var p in pupils)
            //{
            //    Console.WriteLine($"Ученик {i} {p.Name} {p.Surename} средний бал {p.Average}");
            //    i++;
            //}

            //Сортирую учеников
            PupilBuble(pupils);

            Console.WriteLine("\n");

            Console.WriteLine("Вывод трёх самых худших по среднему баллу учеников:");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine($"Ученик {i}\t {pupils[i].Name} {pupils[i].Surename} средний бал {pupils[i].Average}");
            }
            Console.WriteLine("\nДругие ученики с таким же средним баллом");
            i = 3;
            while (pupils[i].Average == pupils[2].Average)
            {
                Console.WriteLine($"Ученик {i}\t {pupils[i].Name} {pupils[i].Surename} средний бал {pupils[i].Average}");
                i++;
            }


            Console.ReadKey();
        }

        /// <summary>
        /// Пузырьковая сортировка учеников
        /// по среднему баллу
        /// </summary>
        /// <param name="pupils"></param>
        public static void PupilBuble(Pupil[] pupils)
        {
            for (int i = 0; i < pupils.Length; i++)
            {
                for (int j = 0; j < pupils.Length - i - 1; j++)
                {
                    if (pupils[j].Average > pupils[j + 1].Average) 
                    {
                        Swap(pupils, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Вспомогательный метод обмена местами элементов 
        /// массива для пузырьковой сортировки
        /// </summary>
        /// <param name="pupils"></param>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        public static void Swap(Pupil[] pupils, int pos1, int pos2)
        {
            Pupil temp;
            temp = pupils[pos1];
            pupils[pos1] = pupils[pos2];
            pupils[pos2] = temp;

        }

    }
}
