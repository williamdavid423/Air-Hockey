using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Hockey
{
    public partial class Form1 : Form
    {
        Pen blackPen = new Pen(Color.Black, 3);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(blackPen, 50, 0, 50, 450);
            e.Graphics.DrawLine(blackPen, 450, 0, 450, 450);
            e.Graphics.DrawLine(blackPen, 50, 1, 450, 1);
            e.Graphics.DrawLine(blackPen, 50, 448, 450, 448);

        
        }
    }
}
