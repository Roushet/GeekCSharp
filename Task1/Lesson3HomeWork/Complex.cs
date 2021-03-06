﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3HomeWork
{
    class Complex
    {
        double im;
        double re;

        public Complex​()
        {
            im = 0;
            re = 0;
        }

        public Complex​(double _re, double _im)
        {
            this.im = _im;
            this.re = _re;
        }

        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="x2"></param>
        /// <returns></returns>
        public Complex Plus​(Complex x2)
        {
            Complex x3 = new Complex​();
            x3​.im = x2​.im + im;
            x3​.re = x2​.re + re;
            return x3;
        }
        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="x2"></param>
        /// <returns></returns>
        public Complex Minus(Complex x2)
        {
            Complex x3 = new Complex​();
            x3​.im = x2​.im - im;
            x3​.re = x2​.re - re;
            return x3;
        }

        /// <summary>
        /// Произведение комплексных чисел
        /// </summary>
        /// <param name="x2"></param>
        /// <returns></returns>
        public Complex Multiply(Complex x2)
        {
            //тут в методичке использовалась неправильная формула произведения
            Complex x3 = new Complex​();
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