using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkovAlgorithmsWindowsForms
{
    public partial class LogForm : Form
    {
        public LogForm(string str)
        {
            InitializeComponent();

            richTextBox1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        Point point;
        private void LogForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }
        private void LogForm_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }
    }
}
