using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Fraction
    {
        //числитель
        int numerator = 0;
        //знаменатель
        //не может быть нулём
        int denominator = 1;

        //конструктор
        public Fraction(int _numerator, int _denominator)
        {
            //заранее страхуемся от ошибки деления на 0
            this.numerator = _numerator;
            if (_denominator == 0)
                this.denominator = 1;
            else this.denominator = _denominator;
        }
    }
}
