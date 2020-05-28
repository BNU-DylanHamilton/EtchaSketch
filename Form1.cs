using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace EtchaSketch
{
    public partial class Form1 : Form
    {
        private int x = 50, y = 50;     // starting position
        private int circleX = 20, circleY = 20; //sets the starting size of the drawing circle
        private Color colour;
        private Random rand = new Random();
        SolidBrush brush = new SolidBrush(Color.Blue);
        Bitmap bm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromImage(bm);
            g.FillEllipse(brush, x, y, circleX, circleY);
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            bm = new Bitmap(this.Width, this.Height);   // create a form-size bitmap
            Graphics g = Graphics.FromImage(bm);        // get a graphic object for the bitmap
            g.FillEllipse(Brushes.Blue, x, y, 20, 20);  // put a circle in the bitmap
            this.BackgroundImage = bm;                  // use the bitmap as the form background
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string input;
            input = keyData.ToString();
            Graphics g = Graphics.FromImage(bm);

            if (input == "Up")
            {
                y -= 10;
            }
            else if (input == "Down")
            {
                y += 10;
            }
            else if (input == "Left")
            {
                x -= 10;
            }
            else if (input == "Right")
            {
                x += 10;
            }
            else if (input == "C")
            {
                g.Clear(BackColor);
            }
            else if (input == "Escape")
            {
                if (MessageBox.Show("Are you sure you want to finish?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else if (input == "B")
            {
                if (circleX > 50 || circleY > 50)
                {
                    circleX = 50;
                    circleY = 50;
                }
                else
                {
                    circleX += 5;
                    circleY += 5;
                }
            }
            else if (input == "S")
            {
                if (circleX < 5 || circleY < 5)
                {
                    circleX = 5;
                    circleY = 5;
                }
                else
                {
                    circleX -= 5;
                    circleY -= 5;
                }
            }
            else if (input == "F1")
            {
                colour = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                brush = new SolidBrush(colour);
            }
            else if (input == "Q")
            {
                y -= 10;
                x -= 10;
            }
            else if (input == "W")
            {
                y -= 10;
                x += 10;
            }
            else if (input == "O")
            {
                y += 10;
                x -= 10;
            }
            else if (input == "P")
            {
                y += 10;
                x += 10;
            }
            else if(input == "F2")
            {
                this.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            }

            return false;    // return true if key processed, otherwise false
        }

    }
}