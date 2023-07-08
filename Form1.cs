using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_PictureBox
{
    public partial class Form1 : Form
    {
        int _widthTextB=0, _heightTextB=0;
        Point _loc;
        int _widthPB = 84, _hegthPB = 44;
        public Form1()
        {
            InitializeComponent();
        }
        private void moveTextBox(Point location) {
            textBox1.Location = location;
            Point rigthDownAncle=new Point(location.Y+textBox1.Size.Height,location.X+textBox1.Size.Width);
            textBox1.Text = "width_leftUp: "+location.X.ToString() + "\n width_rigthDown: " + rigthDownAncle.Y +
                "\nhegth_LeftUp: " + location.Y.ToString() + "\n hegth_rigthDown: " + rigthDownAncle.X;        
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            _widthTextB = vScrollBar1.Value;
            _loc = new Point(_heightTextB, _widthTextB);
            moveTextBox(_loc);
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == string.Empty) {
                return;
            }
            if (int.Parse(maskedTextBox1.Text) < pictureBox1.MinimumSize.Width &&
                int.Parse(maskedTextBox1.Text) > pictureBox1.MaximumSize.Width)
            {
                pictureBox1.Size = pictureBox1.MinimumSize;
            }
            else
            {
                pictureBox1.Size = new Size(int.Parse(maskedTextBox1.Text), pictureBox1.Size.Height);
            }
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text == string.Empty)
            {
                return;
            }
            if (int.Parse(maskedTextBox2.Text) < pictureBox1.MinimumSize.Width &&
                int.Parse(maskedTextBox2.Text) > pictureBox1.MaximumSize.Width)
            {
                pictureBox1.Size = pictureBox1.MinimumSize;
            }
            else
            {
                pictureBox1.Size = new Size(pictureBox1.Size.Width, int.Parse(maskedTextBox2.Text));
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Size = new Size(pictureBox1.Size.Width+1, pictureBox1.Size.Height+1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(_widthPB+trackBar1.Value*10,_hegthPB + trackBar1.Value * 10);
           
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            _heightTextB = hScrollBar1.Value;
            _loc = new Point( _heightTextB, _widthTextB);
            moveTextBox(_loc);
        }
    }
}
