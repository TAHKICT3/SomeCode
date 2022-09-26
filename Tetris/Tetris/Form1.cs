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
    public partial class Form1 : Form
    {
        GameField mainField, bonusField;
        Brush[] br = { Brushes.Teal, Brushes.Blue, Brushes.DarkOrange, Brushes.Orange, Brushes.DarkGreen, Brushes.Purple, Brushes.IndianRed };
        Brush[] brin = { Brushes.Turquoise, Brushes.LightBlue, Brushes.NavajoWhite, Brushes.Yellow, Brushes.Green, Brushes.MediumOrchid, Brushes.Red };
        int score;      
        int brickVariants = 7;
        Random r = new Random();
        bool play = false;
        bool started = false;
        Timer t = new Timer();
        int time, timeLeak;
        string[,] records = new string[10, 3];
        Graphics gm, gb;
        bool needUpdRec = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void TimerWork(Object myObject, EventArgs myEventArgs)
        {
            CheckAndMove(0, 1, 0);
            if (score > timeLeak)
            {
                timeLeak += 50;
                if (time > 50)
                {
                    time -= 25;
                    t.Interval = time;
                }   
            }
            if (!started)
            {
                t.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (started)
            {
                PlayPause();
            }
            else
            {
                StartNew();
            }
        }

        private void StartNew()
        {
            time = 1000;
            timeLeak = 50;
            t.Interval = time;  
            play = true;
            started = true;
            mainField = new GameField(10, 21, new TetraBrick(r.Next(brickVariants), 4, 1));
            bonusField = new GameField(6, 4, new TetraBrick(r.Next(brickVariants), 2, 2));
            score = 0;
            label2.Text = "" + score;
            Draw(mainField, gm, 0, -1);
            Draw(bonusField, gb, 0, 0);
            t.Start();
            button1.Text = "Pause";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (play)
            {
                if (e.KeyCode == Keys.A || e.KeyCode == Keys.NumPad4)
                {
                    CheckAndMove(-1, 0, 0);
                }
                if (e.KeyCode == Keys.D || e.KeyCode == Keys.NumPad6)
                {
                    CheckAndMove(1, 0, 0);
                }
                if (e.KeyCode == Keys.S || e.KeyCode == Keys.NumPad2)
                {
                    CheckAndMove(0, 1, 0);
                }
                if (e.KeyCode == Keys.Q || e.KeyCode == Keys.NumPad7)
                {
                    CheckAndMove(0, 0, -1);
                }
                if (e.KeyCode == Keys.E || e.KeyCode == Keys.NumPad9)
                {
                    CheckAndMove(0, 0, 1);
                }
            }
            switch (e.KeyCode)
            {
                case Keys.F1:
                    Output(0);
                    break;
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F2:
                    StartNew();
                    break;
                case Keys.F3:
                    Output(1);
                    break;
                case Keys.F4:
                    Output(2);
                    break;
                case Keys.Pause:
                    PlayPause();
                    break;
                case Keys.P:
                    PlayPause();
                    break;
            }
        }

        private void Output(int p)
        {
            if(play)
            {
                PlayPause();
            }
            switch (p)
            {
                case 0:
                    MessageBox.Show("Tetris game\nMade by Ihnatiev Oleksandr\n2022 y.", "About Tetris2022");
                    break;
                case 1:
                    MessageBox.Show("Game:\n" +
                        "Move left - \"A\" or \"4\"(NumPad)\n" +
                        "Move right - \"D\" or \"6\"(NumPad)\n" +
                        "Move down - \"S\" or \"2\"(NumPad)\n" +
                        "Turn left - \"Q\" or \"7\"(NumPad)\n" +
                        "Turn right - \"E\" or \"9\"(NumPad)\n" +
                        "Pause/Play - \"Pause\"or \"P\"\n" +
                        "Other:\n" +
                        "Exit - \"Esc\"\n" +
                        "About program... - \"F1\"\n" +
                        "New game - \"F2\"\n" +
                        "Controls - \"F3\"\n" +
                        "Records - \"F4\"", "Controls");
                    break;
                case 2:
                    string text = "Name\tScore\tDate";
                    UpdateRecord();
                    for (int i = 0; i < 10; i++)
                    {
                        text += "\n" + records[i, 0] + "\t" + records[i, 1] + "\t" + records[i, 2];
                    }
                    MessageBox.Show(text, "Records");
                    break;
            }
        }

        private void CheckAndMove(int x, int y, int where)
        {
            bool test = false;
            if(where == 0)
            {
                int[] testData = mainField.MoveBrick(x, y);
                switch (testData[0])
                {
                    case 1:
                        test = true;
                        break;
                    case 2:
                        mainField.ChangeBrick(bonusField.brick.color, 4, 1);
                        bonusField.ChangeBrick(r.Next(brickVariants), 2, 2);
                        Draw(bonusField, gb, 0, 0);
                        score += testData[1] * testData[1] * 10;
                        label2.Text = "" + score;
                        test = true;
                        break;
                    case 3:
                        score += testData[1] * testData[1] * 10;
                        label2.Text = "" + score;
                        test = false;
                        for(int i = 0; i < bonusField.sizeX; i++)
                        {
                            for (int j = 0; j < bonusField.sizeY; j++)
                            {
                                bonusField.fieldData[i, j, 0] = 0;
                            }
                        }
                        Draw(bonusField, gb, 0, 0);
                        GameOver();
                        break;
                }
            }
            else
            {
                test = mainField.TurnBrick(where);
            }
            if (test)
            {
                Draw(mainField, gm, 0, -1);
            }
        }

        private void UpdateRecord()
        {
            if (needUpdRec)
            {
                try
                {
                    StreamReader sr = new StreamReader("Records.rcr");
                    string a = sr.ReadToEnd();
                    sr.Close();
                    try
                    {
                        string[] b = a.Split(Convert.ToChar("\n"));
                        for (int i = 0; i < 10; i++)
                        {
                            string[] c = b[i].Split(' ');
                            records[i, 0] = c[0];
                            records[i, 1] = c[1];
                            records[i, 2] = c[2];
                        }
                        needUpdRec = false;
                    }
                    catch (Exception ex)
                    {
                        Environment.Exit(ex.HResult);
                    }
                }
                catch (FileNotFoundException exf)
                {
                    MessageBox.Show(exf.Message + "\nRecords.rcr will be created.", "Warning!");
                    try
                    {
                        StreamWriter sw = new StreamWriter("Records.rcr");
                        string text = "- 0 -";
                        for (int i = 1; i < 10; i++)
                        {
                            text += "\n- 0 -";
                        }
                        sw.Write(text);
                        sw.Close();
                        UpdateRecord();
                        needUpdRec = false;
                    }
                    catch (Exception ex)
                    {
                        Environment.Exit(ex.HResult);
                    }
                }
            }
        }

        private void GameOver()
        {
            t.Stop();
            t.Enabled = false;
            play = false;
            started = false;
            label4.Visible = false;
            label5.Visible = false;
            button1.Text = "Start!";
            int n = 10;
            UpdateRecord();
            for(int i = 0; i < 10; i++)
            {
                if(score > Convert.ToInt32(records[i, 1]))
                {
                    n = i;
                    break;
                }
            }
            if(n < 10)
            {
                for (int i = 8; i >= n; i--)
                {
                    records[i + 1, 0] = records[i, 0];
                    records[i + 1, 1] = records[i, 1];
                    records[i + 1, 2] = records[i, 2];
                }
                needUpdRec = true;
                Form2 f = new Form2(score, records, n);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Score:\n" + score, "GAME OVER");
            }
        }

        private void PlayPause()
        {
            if (started)
            {
                if (play)
                {
                    t.Enabled = false;
                    button1.Text = "Play";
                }
                else
                {
                    t.Enabled = true;
                    button1.Text = "Pause";                  
                }
                play = !play;
                label4.Visible = !label4.Visible;
                label5.Visible = !label5.Visible;
            }
        }

        private void Draw(GameField field, Graphics g, int xCor, int yCor)
        {
            g.Clear(Color.WhiteSmoke);
            for (int i = 0; i < field.sizeX + xCor; i++)
            {
                for(int j = 0; j < field.sizeY + yCor; j++)
                {
                    if(field.fieldData[i - xCor, j - yCor, 0] != 0)
                    {
                        int k = field.fieldData[i - xCor, j - yCor, 1];
                        g.FillRectangle(br[k], i * 15, j * 15, 15, 15);
                        g.FillRectangle(brin[k], i * 15 + 3, j * 15 + 3, 9, 9);
                    }
                }
            }
        } 

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNew();
        }

        private void pausePlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Output(1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (play)
            {
                PlayPause();
            }
            bool test = true;
            if (MessageBox.Show("You confirm closing program?", "Tetris2022", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                test = false;
            }
            e.Cancel = test;
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Output(0);
        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Output(2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t.Tick += new EventHandler(TimerWork);
            gm = pictureBox1.CreateGraphics();
            gb = pictureBox2.CreateGraphics();
            UpdateRecord();
        }
    }
}
