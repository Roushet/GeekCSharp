using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        //Label lbl = new Label();
        //TextBox text = new TextBox();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


            //lbl.Name = "lbl";
            //lbl.Text = "313";
            //lbl.Height = 30;
            //lbl.Width = 400;

            //lbl.Location = new Point(100, 30);
            //Controls.Add(text);

        }



        private void Hover(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

        }

        private void menuNewSmall_Click(object sender, EventArgs e)
        {
            Cell.ClearAll(Controls);
            Cell field = new Cell();
            field.MakeField(8, Controls);

            this.Size = new Size(45 * 16, 30 + 45 * 16);
            this.Refresh();

            //text.Enabled = false;
            //text.Height = 50;
            //text.Width = this.Width - 30;
            //text.Location = new Point(10, this.Height - 40);

            this.Height = this.Size.Height + 50;
            this.Refresh();

        }

        private void menuNewMedium_Click(object sender, EventArgs e)
        {
            Cell.ClearAll(Controls);
            Cell field = new Cell();
            field.MakeField(12, Controls);

            this.Size = new Size(45 * 16, 30 + 45 * 16);
            this.Refresh();

            //text.Enabled = false;
            //text.Height = 50;
            //text.Width = this.Width - 30;
            //text.Location = new Point(10, this.Height - 40);

            this.Height = this.Size.Height + 50;
            this.Refresh();
        }

        private void menuNewBig_Click(object sender, EventArgs e)
        {
            Cell.ClearAll(Controls);
            Cell field = new Cell();
            field.MakeField(16, Controls);

            this.Size = new Size(45 * 16, 30 + 45 * 16);
            this.Refresh();

            //text.Enabled = false;
            //text.Height = 50;
            //text.Width = this.Width - 30;
            //text.Location = new Point(10, this.Height - 40);

            this.Height = this.Size.Height + 50;
            this.Refresh();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cell.Wave();
        }
    }
}

