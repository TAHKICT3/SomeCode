using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tetris
{
    public partial class Form2 : Form
    {
        string[,] records;
        int n, score;

        public Form2(int score, string[,] records, int n)
        {
            this.records = records;
            this.n = n;
            this.score = score;           
            InitializeComponent();
            label3.Text = "" + this.score;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 10)
            {
                MessageBox.Show("Record wasn`t recorde, try again.\nName must have less than 11 simbols!", "Warning");
            }
            else
            {
                records[n, 0] = textBox1.Text.Replace(' ', '_');
                records[n, 1] = "" + score;
                records[n, 2] = DateTime.Today.ToShortDateString();
                try
                {
                    StreamWriter sw = new StreamWriter("Records.rcr");
                    string text = records[0, 0] + " " + records[0, 1] + " " + records[0, 2];
                    for (int i = 1; i < 10; i++)
                    {
                        text += "\n" + records[i, 0] + " " + records[i, 1] + " " + records[i, 2];
                    }
                    sw.Write(text);
                    sw.Close();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    Close(); 
                }
            }
        }
    }
}
