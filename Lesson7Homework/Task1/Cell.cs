using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    /// <summary>
    /// Класс для работы с батонами.
    /// Создаёт батоны, добавляет их в лист
    /// Удаляет все батоны
    /// Меняет текст и цвет
    /// </summary>
    /// 

    class Cell
    {

        delegate void ClickHandler(object sender, EventArgs e, Cell cell);

        public static List<Cell> Cells = new List<Cell>();
        public static Cell[,] Field;

        private int cellSize = 45;
        Button button;
        string name;
        int row;
        int column;
        //Color color;
        bool isWall;
        bool isCat;
        bool isExit;
        //для поиска пути
        int wave;

        public Color color
        {
            get => button.BackColor;
            set => button.BackColor = value;
        }

        //Пустой конструктор
        public Cell() { }


        private Cell(Control.ControlCollection controls, Point location, int row, int column)
        {

            this.button = new Button();

            this.name = String.Format("btn_{0}_{1}", row, column);
            //button.BackColor = this.color;
            this.row = row;
            this.column = column;
            this.isWall = false;

            this.button.Text = name;
            this.button.Height = cellSize;
            this.button.Width = cellSize;
            this.button.Location = location;
            controls.Add(button);

        }

        public void MakeField(int size, Control.ControlCollection controls)
        {
            Point location = new Point(10, 30);
            Field = new Cell[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Cell cell = new Cell(controls, location, i, j);
                    Field[i, j] = cell;
                    location.X += cellSize;

                    cell.button.Click += delegate (object sender2, EventArgs e2) { OnCellClick(sender2, e2, cell); };
                }
                location.X = 10;
                location.Y += cellSize;
            }
            Field[0, 0].isCat = true;
            Field[0, 0].color = Color.Black;
            Field[size - 1, size - 1].isExit = true;
            Field[size - 1, size - 1].color = Color.Crimson;

        }

        private void OnCellClick(object sender, EventArgs e, Cell cell)
        {
            if (cell.isWall == true)
            {
                cell.color = Control.DefaultBackColor;
                cell.isWall = false;
            }
            else
            {
                cell.color = Color.Chocolate;
                //cell.button.Text = "";
                cell.isWall = true;
            }
        }

        public static void ClearAll(Control.ControlCollection controls)
        {
            if (Field != null)
            {
                foreach (var cell in Field)
                {
                    controls.Remove(cell.button);
                }
            }
            Field = null;
        }


        public static void Wave()
        {
            Cell start = Field[0, 0];
            Cell finish = Field[15, 15];
            Cell curPos = Field[0, 0];

            int count = 1;

            //пробегаем по строкам
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                //пробегаем по столбцам
                for (int column = 0; column < Field.GetLength(0); column++)
                {
                    //проверка, если нашли цель
                    if (curPos.isExit == true) {
                        MessageBox.Show(String.Format("Выход найден {0} {1}", curPos.row, curPos.column));
                        return;
                    };

                    //проверяем соседние клетки
                    //если соседняя клетка существует и не стена
                    if (curPos.column + 1 < Field.GetLength(0) && Field[curPos.row, curPos.column].isWall == false)
                    {
                        //мы её помечаем
                        Field[curPos.row, curPos.column + 1].button.Text = count.ToString();
                        curPos = Field[curPos.row, curPos.column + 1];
                        continue;
                    }

                    if (curPos.column - 1 > 0 && Field[curPos.row, curPos.column - 1].isWall == false)
                    {
                        //мы её помечаем
                        Field[curPos.row, curPos.column - 1].button.Text = count.ToString();

                    }

                    if (curPos.row + 1 < Field.GetLength(0) && Field[curPos.row + 1, curPos.column].isWall == false)
                    {
                        //мы её помечаем
                        Field[curPos.row + 1, curPos.column].button.Text = count.ToString();
                        curPos = Field[curPos.row + 1, curPos.column];
                        continue;
                    }

                    if (curPos.row - 1 > 0 && Field[curPos.row - 1, column].isWall == false)
                    {
                        //мы её помечаем
                        Field[curPos.row - 1, curPos.column].button.Text = count.ToString();
                        curPos = Field[curPos.row - 1, curPos.column];
                        continue;
                    }

                }
            }

        }

        public static bool IsValidPos(int newRow, int newColumn)
        {
            if (newRow < 0) return false;
            if (newColumn < 0) return false;
            if (newRow > Field.GetLength(0)) return false;
            if (newColumn > Field.GetLength(0)) return false;

            if (Field[newRow, newColumn].isWall == true) return false;

            return true;
        }

    }

}


