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

//Mohammad Al-Qaisy

namespace Task_05
{
    struct Coordinate
    {
        public int x;
        public int y;
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public partial class Form1 : Form
    {
        List<vehicle> list = new List<vehicle>();
        int Timer;
        StreamReader reader;
        public Form1()
        {
            InitializeComponent();
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void caToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void camToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timesNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void underLineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void blackToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void whiteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void blackToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void blueToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void whiteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listview.ForeColor = Color.White;
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            listview.Font = new Font(listview.Font.FontFamily, (float)8, listview.Font.Style);
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            listview.Font = new Font(listview.Font.FontFamily, (float)12, listview.Font.Style);
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            listview.Font = new Font(listview.Font.FontFamily, (float)10, listview.Font.Style);
        }

        private void blackToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listview.ForeColor = Color.Black;
        }

        private void redToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listview.ForeColor = Color.Red;
        }

        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listview.BackColor = Color.Blue;
        }

        private void blackToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            listview.BackColor = Color.Black;
        }

        private void whiteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listview.BackColor = Color.White;
        }

        private void whiteToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void blackToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void blueToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }
        void _Open()
        {
            reader = new StreamReader(openFileDialog1.FileName);
            list.Clear();
            string str = reader.ReadLine();
            while (str != null)
            {
                vehicle obj = new vehicle(str);
                list.Add(obj);
                str = reader.ReadLine();
            }
            reader.Close();
            SpeedClass();
            view();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _Open();
                timer1.Enabled = true;
            }
        }
        
        void view()
        {
            listview.Items.Clear();
            foreach (vehicle obj in list)
            {
                var row = new string[] { obj._number , obj._type, obj._Displacement.ToString() ,
                    obj._speed.ToString(), obj._exit.ToString() ,obj._speedClass };
                var x = new ListViewItem(row);
                listview.Items.Add(x);
            }
            speedinfo();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void minToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SpeedClass();
        }

        private void maxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpeedClass();
        }
        void SpeedClass()
        {
            double min = 0, max = 0;
            while (true)
            {
                try
                {
                    min = Int32.Parse(minToolStripMenuItem.Text);
                    max = Int32.Parse(maxToolStripMenuItem.Text);
                    break;
                }
                catch
                {
                    return;
                }
            }
            double slot = (max - min) / 3;
            foreach (vehicle obj in list)
            {
                if (min <= obj._speed && obj._speed < (min + slot))
                    obj._speedClass = "Slow";
                else if (min+slot<=obj._speed && obj._speed<min + 2*slot)
                    obj._speedClass = "Medium";
                else if (min+2*slot<=obj._speed&& obj._speed<=max)
                    obj._speedClass = "High";
            }
            view();
        }

        private void timesNewRomanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listview.Font = new Font("Times New Roman", listview.Font.Size, listview.Font.Style);
        }

        private void cambriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listview.Font = new Font("Cambria", listview.Font.Size, listview.Font.Style);
        }

        private void calibriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listview.Font = new Font("Calibri", listview.Font.Size, listview.Font.Style);
        }
        void speedinfo()
        {
            int speedlow = list[0]._speed, speedhigh = list[0]._speed;
            int allSpeed = 0;
            int exit1 = 0, exit2 = 0, exit3 = 0, exit4 = 0;
            foreach (vehicle obj in list)
            {
                if (speedlow > obj._speed)
                    speedlow = obj._speed;
                if (speedhigh < obj._speed)
                    speedhigh = obj._speed;
                allSpeed += obj._speed;
                if (obj._exit == 1)
                    exit1++;
                else if (obj._exit == 2)
                    exit2++;
                else if (obj._exit == 3)
                    exit3++;
                else if (obj._exit == 4)
                    exit4++;
            }
            label2.Text = (speedlow.ToString() + " - " + speedhigh.ToString());
            label4.Text = (allSpeed / list.Count).ToString();
            label6.Text = list.Count.ToString();
            label8.Text = string.Format("{0:00.0}",((100.0/list.Count)*exit1))+"%";
            label10.Text = string.Format("{0:00.0}", ((100.0 / list.Count) * exit2)) + "%";
            label12.Text = string.Format("{0:00.0}", ((100.0 / list.Count) * exit3)) + "%";
            label14.Text = string.Format("{0:00.0}", ((100.0 / list.Count) * exit4)) + "%";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                StreamWriter writer = new StreamWriter(filename);
                string str = label1.Text + " " + label2.Text + "\t\t" + label3.Text + " " + label4.Text + "\t\t" +
                    label5.Text + " " + label6.Text + "\n" +
                    label7.Text + " " + label8.Text + "\t\t" + label9.Text + " " + label10.Text + "\t\t"
                    + label11.Text + " " + label12.Text + "\t\t" + label13.Text + " " + label14.Text;
                writer.WriteLine(str);
                writer.Close();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Timer = Int16.Parse(toolStripMenuItem5.Text);
            timer1.Interval = Timer * 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _Open();
        }
    }
}
