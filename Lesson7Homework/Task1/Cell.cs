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

        private int cellSize = 45;
        Button button;
        string name;
        int row;
        int column;
        //Color color;
        bool isWall;

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

            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    Cell cell = new Cell(controls, location, i, j);
                    cell.button.Click += delegate (object sender2, EventArgs e2) { OnCellClick(sender2, e2, cell); };
                    Cells.Add(cell);


                    location.X += cellSize;

                }
                location.X = 10;
                location.Y += cellSize;
            }
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

        //public void CellClicked(object sender, CellClickEventArgs args)
        //{



        //}

    }
}
