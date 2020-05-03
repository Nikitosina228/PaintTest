using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ris
{
    public partial class Form1 : Form
    {

        Color CurrentColor = Color.Black;
        bool isPressed = false;
        Point CurrentPoint;
        Point PrevPoint;
        int Size = 1;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;

            SolidBrush mySolidBrush = new SolidBrush(CurrentColor);
            g.FillEllipse(mySolidBrush, CurrentPoint.X - Size / 2, CurrentPoint.Y - Size / 2, Size, Size);
            label2.Text = Convert.ToString(isPressed);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.Location.X + "X" + " " + e.Location.Y + "Y";
            label2.Text = Convert.ToString(isPressed);

            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                for_paint();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        public void for_paint()
        {
            Pen p = new Pen(CurrentColor, Size);
            SolidBrush mySolidBrush = new SolidBrush(CurrentColor);
            g.DrawLine(p, PrevPoint, CurrentPoint);
            g.FillEllipse(mySolidBrush, CurrentPoint.X - Size / 2, CurrentPoint.Y - Size / 2, Size, Size);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Size = trackBar1.Value;
            label3.Text = Convert.ToString(Size);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.White;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Black;
        }
    }
}
