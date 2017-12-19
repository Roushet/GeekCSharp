using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    //Владимир Евдокимов
            //3. Подсчитать количество студентов:

            //а) учащихся на 5 и 6 курсах;
            //б)подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
            //в) отсортировать список по возрасту студента;
            //г) * отсортировать список по курсу и возрасту студента.
            //Дополнительное домашнее задание

    class Program
    {

        static void Main(string[] args)
        {
            #region Код из методички
            int bakalav = 0;
            int magistr = 0;
            List<Student> list = new List<Student>(); // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("..\\..\\Students.csv", Encoding.GetEncoding(1251));
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[6]) < 5) bakalav++; else magistr++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(AlphabeticSort));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalav);
            #endregion

            #region а) учащихся на 5 и 6 курсах;
            Console.WriteLine("Учащихся 5 и 6 курсов:" + list.Count<Student>(CourseHigherThan));
            //или через лямбда
            Console.WriteLine("Учащихся 5 и 6 курсов ЛЯМБДА:" + list.Count<Student>(st => st.course > 4));
            #endregion
            Console.WriteLine();
            #region б)подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);

            for (int i = 18; i <= 20; i++)
            {
                List<Student> studentsByAge = list.FindAll(s => s.age == i);
                Console.WriteLine($"Возраст {i}");
                PrintTable(CourceFromList(studentsByAge));
            }

            #endregion
            Console.WriteLine();
            #region в) отсортировать список по возрасту студента;

            list.Sort(new Comparison<Student>(AgeSort));
            Console.WriteLine("Сортировка по возрасту студента");
            foreach (var v in list) Console.WriteLine("{0,14} | {1,14} | {2,14} | {3,14} ", v.firstName, v.lastName, v.course, v.age);
            #endregion
            Console.WriteLine();
            #region г) *отсортировать список по курсу и возрасту студента.
            for (int i = 1; i <= 6; i++)
            {
                List<Student> studentsCource = list.FindAll(s => s.course == i);
                studentsCource.OrderBy(s => s.age);
                foreach (var v in studentsCource) Console.WriteLine("{0,14} | {1,14} | {2,14} | {3,14} ", v.firstName, v.lastName, v.course, v.age);
            }
            #endregion

            //list.OrderBy(s => s.course).ThenBy(s => s.age); - не работает

            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }

        /// <summary>
        /// Сортировка по алфавиту
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int AlphabeticSort(Student st1, Student st2)
        {
            return String.Compare(st1.firstName, st2.firstName);
        }

        /// <summary>
        /// Сортировка по возрасту
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int AgeSort(Student st1, Student st2) // Создаем метод для сравнения для экземпляров
        {
            return st1.age.CompareTo(st2.age); // Сравниваем две строки
        }

        /// <summary>
        /// Сортировка по возрасту в частотный массив
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static int[] CourceFromList(List<Student> list)
        {
            int maxCource = 0;
            foreach (Student st in list)
            {
                if (st.course > maxCource) maxCource = st.course;
            }

            int[] result = new int[maxCource];
            foreach (Student st in list)
            {
                result[st.course - 1]++;
            }
            return result;
        }

        /// <summary>
        /// Предикат для отсортировки студентов по курсу
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        static bool CourseHigherThan(Student student)
        {
            //не смог придумать, как передавать курс параметром в предикат 8(
            return (student.course > 4) ? true : false;
        }

        /// <summary>
        /// Вспомогательный метод, который выводит в консоль таблицу частотного массива
        /// </summary>
        /// <param name="table"></param>
        static void PrintTable(int[] table)
        {
            for (int i = 0; i < table.Length; i++) Console.WriteLine($"курс {i + 1} : студентов {table[i]}");
            Console.WriteLine();
        }

    }
}