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

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    Cell cell = new Cell(controls, location, i, j);
                    Field[i - 1, j - 1] = cell;
                    location.X += cellSize;

                    cell.button.Click += delegate (object sender2, EventArgs e2) { OnCellClick(sender2, e2, cell); };
                }
                location.X = 10;
                location.Y += cellSize;
            }
            Field[0, 0].isCat = true;
            Field[0, 0].color = Color.Black;
            Field[size-1, size-1].isExit = true;
            Field[size-1, size-1].color = Color.Crimson;

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
            foreach (var cell in Cells)
            {
                controls.Remove(cell.button);
            }
            Cells.Clear();
        }


        public void FindWave(int startX, int startY, int targetX, int targetY)
        {
            bool add = true;
            int[,] cMap = new int[MapHeight, MapWidht];
            int x, y, step = 0;
            for (y = 0; y < MapHeight; y++)
                for (x = 0; x < MapWidht; x++)
                {
                    if (Map[y, x] == 1)
                        cMap[y, x] = -2;//индикатор стены
                    else
                        cMap[y, x] = -1;//индикатор еще не ступали сюда
                }
            cMap[targetY, targetX] = 0;//Начинаем с финиша
            while (add == true)
            {
                add = false;
                for (y = 0; y < MapWidht; y++)
                    for (x = 0; x < MapHeight; x++)
                    {
                        if (cMap[x, y] == step)
                        {
                            //Ставим значение шага+1 в соседние ячейки (если они проходимы)
                            if (y - 1 >= 0 && cMap[x - 1, y] != -2 && cMap[x - 1, y] == -1)
                                cMap[x - 1, y] = step + 1;
                            if (x - 1 >= 0 && cMap[x, y - 1] != -2 && cMap[x, y - 1] == -1)
                                cMap[x, y - 1] = step + 1;
                            if (y + 1 < MapWidht && cMap[x + 1, y] != -2 && cMap[x + 1, y] == -1)
                                cMap[x + 1, y] = step + 1;
                            if (x + 1 < MapHeight && cMap[x, y + 1] != -2 && cMap[x, y + 1] == -1)
                                cMap[x, y + 1] = step + 1;
                        }
                    }
                step++;
                add = true;
                if (cMap[startY, startX] != -1)//решение найдено
                    add = false;
                if (step > MapWidht * MapHeight)//решение не найдено
                    add = false;
            }


        }
}
