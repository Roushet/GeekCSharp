using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3HomeWork
{
    struct ComplexStruct
    {
        double im;
        double re;

        public ComplexStruct(double _re​, double _im)
        {
            this.im = _im;
            this.re = _re;
        }

        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="x2"></param>
        /// <returns></returns>
        public ComplexStruct Plus​(ComplexStruct x2)
        {
            ComplexStruct x3 = new ComplexStruct();
            x3​.im = x2​.im + im;
            x3​.re = x2​.re + re;
            return x3;
        }
        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="x2"></param>
        /// <returns></returns>
        public ComplexStruct Minus(ComplexStruct x2)
        {
            ComplexStruct x3 = new ComplexStruct();
            x3​.im = x2​.im - im;
            x3​.re = x2​.re - re;
            return x3;
        }

        /// <summary>
        /// Произведение комплексных чисел
        /// </summary>
        /// <param name="x2"></param>
        /// <returns></returns>
        public ComplexStruct Multiply(ComplexStruct x2)
        {
            //тут в методичке использовалась неправильная формула произведения
            ComplexStruct x3 = new ComplexStruct();
            x3​.re = (x2​.re * re - x2.im * im);
            x3​.im = (x2​.re * re + x2.im * im);
            return x3;
        }

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double Im
        {
            get { return im; }

            set { im = value; }
        }

        public double Re
        {
            get { return re; }
            set { re = value; }
        }


        public override string ToString​()
        {
            return re + " + " + im + "i";
        }
    }





}