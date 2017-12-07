using System;
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

        public Complex​(double _im​, double _re)
        {
            im = _im;
            re = _re;
        }

        public Complex Plus​(Complex x2)
        {
            Complex x3 = new Complex​();
            x3​.im = x2​.im + im;
            x3​.re = x2​.re + re;
            return x3;
        }

        public Complex Minus(Complex x2)
        {
            Complex x3 = new Complex​();
            x3​.im = x2​.im - im;
            x3​.re = x2​.re - re;
            return x3;
        }

        public double Im
        {
            get { return im​; }

            set { if (value >= 0) im = value; }
        }

        public override string ToString​()
        {
            return re + "+" + im + "i";
        }
    }





}