using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Fraction
    {
        //числитель
        int numerator;
        //знаменатель
        //не может быть нулём
        int denominator;

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        /// <summary>
        /// Перегрузка конструктора по умолчанию
        /// </summary>
        /// <param name="_numerator"></param>
        /// <param name="_denominator"></param>
        public Fraction(int _numerator, int _denominator)
        {
            this.numerator = _numerator;
            this.denominator = _denominator;
        }

        public int Numerator 
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }

        /// <summary>
        /// Перегрузка стандартного метода для класса дробей
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Numerator == 0) return "0";
            if (Numerator <0 || Denominator < 0) return "- " + Math.Abs(Numerator) + " / " + Math.Abs(Denominator);
            return Numerator + " / " + Denominator;
        }

        //перегрузка оператора сложения +
        public static Fraction operator +(Fraction x, Fraction y)
        {
            int gcd = 1;
            Fraction result = new Fraction();

            result.numerator = x.numerator * y.denominator + y.numerator*x.denominator;
            result.denominator = x.denominator* y.denominator;

            gcd = GCD(result.numerator, result.denominator);

            result.numerator /= gcd;
            result.denominator /= gcd;

            return result;
        }

        //перегрузка оператора вычитания -
        public static Fraction operator -(Fraction x, Fraction y)
        {
            int gcd = 1;
            Fraction result = new Fraction();

            result.numerator = x.numerator * y.denominator - y.numerator * x.denominator;
            result.denominator = x.denominator * y.denominator;

            gcd = GCD(result.numerator, result.denominator);

            result.numerator /= gcd;
            result.denominator /= gcd;

            return result;
        }

        //перегрузка оператора умножения *
        public static Fraction operator *(Fraction x, Fraction y)
        {
            int gcd = 1;
            Fraction result = new Fraction();

            result.numerator = x.numerator * y.numerator;
            result.denominator = x.denominator * y.denominator;

            gcd = GCD(result.numerator, result.denominator);

            result.numerator /= gcd;
            result.denominator /= gcd;

            return result;

        }

        //перегрузка оператора деления -
        public static Fraction operator /(Fraction x, Fraction y)
        {
            int gcd = 1;
            Fraction result = new Fraction();

            result.numerator = x.numerator * y.denominator;
            result.denominator = x.denominator * y.numerator;

            gcd = GCD(result.numerator, result.denominator);

            result.numerator /= gcd;
            result.denominator /= gcd;

            return result;
        }

        /// <summary>
        /// Возвращает наибольший общий делитель (НОД)
        /// Сервисный метод для всех операций с дробями
        /// Реализация спёрта из методички
        /// </summary>
        /// <returns></returns>
        public static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            if (a == 0)
                return b;
            else
                return a;
        }

        //реализация НОД через рекурсию и тренарный оператор
        //версия для наркоманов

        //static int GCD(int a, int b)
        //{
        //    return b == 0 ? a : GCD(b, a % b);
        //}
    }
}
