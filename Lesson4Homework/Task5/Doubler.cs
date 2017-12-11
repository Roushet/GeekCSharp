using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    //Реализовать класс “Удвоитель”. Класс хранит в себе поле current - текущее значение, finish - число,
    //которого нужно достичь, конструктор, в котором задается конечное число.Методы:
    //увеличить число на 1, увеличить число в два раза, сброс текущего до 1, свойство Current,
    //которое возвращает текущее значение, свойство Finish, которое возвращает конечное значение.
    //Создать с помощью этого класса игру, в которой компьютер загадывает число, а человек.выбирая из меню на экране,
    //отдает команды удвоителю и старается получить это число за наименьшее число ходов.Если человек получает число больше
    //положенного, игра прекращается.

    class Doubler
    {
        int _current;
        int _finish;

        public Doubler()
        {
            _current = 1;
            _finish = 1;
        }

        public int Current
        {
            get => _current;
        }

        public int Finish
        {
            get => _finish;
            set => _finish = value;
        }

        public int AddOne()
        {
            return _current += 1;
        }

        public int Double()
        {
            return _current *= 2;
        }

        public int Reset()
        {
            return _current = 1;
        }
    }
}
