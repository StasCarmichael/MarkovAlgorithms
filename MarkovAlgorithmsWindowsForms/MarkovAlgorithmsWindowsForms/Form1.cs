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
    public partial class Form1 : Form
    {
        //ctor
        public Form1()
        {
            InitializeComponent();

            this.ActiveControl = button1;

            richTextBox1.Text = "Поле для вводу алгоритма";
            textBox1.Text = "Ведіть початкові дані";
        }


        //create machine
        MarkovAlgorithm markovAlgorithm = new MarkovAlgorithm();



        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == string.Empty)
            {
                MessageBox.Show("Будь ласка введіть коректно дані !!!");
            }
            else
            {
                try
                {
                    string[] stringArray = richTextBox1.Text.Split('\n');

                    markovAlgorithm.DownloadData(stringArray);

                    if (markovAlgorithm.donwload == true)
                    {
                        MessageBox.Show("Дані завантажені успішно !!!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Стався збій програми " + ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (markovAlgorithm.donwload == true)
            {
                try
                {
                    markovAlgorithm.AddInputWords(textBox1.Text);
                    textBox2.Text = markovAlgorithm.StartMarkovMachine();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Стався збій уважно перегляньте коректність даних" + ex);
                }
            }
            else
            {
                MessageBox.Show("Завантажте буль ласка дані !!!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            foreach (var item in markovAlgorithm.logs) { str += item + '\n'; }
            LogForm logForm = new LogForm(str);

            logForm.Show();
        }



        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Поле для вводу алгоритма")
                richTextBox1.Text = "";
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ведіть початкові дані")
                textBox1.Text = "";
        }
        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                richTextBox1.Text = "Поле для вводу алгоритма";
        }


    }
}
