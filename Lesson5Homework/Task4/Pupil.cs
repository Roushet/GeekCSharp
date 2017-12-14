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

        public int this[int index]    // Indexer declaration  
        {
            get => _grades[index];
            set => _grades[index] = value;

        }

        public Pupil(string name, string surename, params int[] grades)
        {
            if (name.Length > 15) throw new PupilInvalidNameException("Ошибка, слишком длинное имя");
            if (surename.Length > 20) throw new PupilInvalidSurenameException("Ошибка, слишком длинная фамилия");
            if (grades.Length != 3) throw new PupilInvalidGradesException("Ошибка, неверное количество оценок. Должно быть 3");

            _name = name;
            _surename = surename;
            for (int i = 0; i < 3; i++)
            {
                _grades[i] = grades[i];
            }
        }
    }

    public class PupilInvalidNameException : Exception
    {
        public PupilInvalidNameException() : base() { }
        public PupilInvalidNameException(string message) : base(message) { }
        public PupilInvalidNameException(string message, Exception inner) : base(message, inner) { }
    }

    public class PupilInvalidSurenameException : Exception
    {
        public PupilInvalidSurenameException() : base() { }
        public PupilInvalidSurenameException(string message) : base(message) { }
        public PupilInvalidSurenameException(string message, Exception inner) : base(message, inner) { }
    }

    public class PupilInvalidGradesException : Exception
    {
        public PupilInvalidGradesException() : base() { }
        public PupilInvalidGradesException(string message) : base(message) { }
        public PupilInvalidGradesException(string message, Exception inner) : base(message, inner) { }
    }
}



