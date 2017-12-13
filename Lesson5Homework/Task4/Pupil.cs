using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Pupil
    {
        string _name;
        string _surename;
        int[] _grades;

        public Pupil()
        {
            _name = "";
            _surename = "";
            _grades = new int[3];
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surename
        {
            get { return _surename; }
            set { _surename = value; }
        }


    }
}
