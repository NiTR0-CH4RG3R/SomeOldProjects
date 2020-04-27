using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace SoftForSasandi
{
    public partial class Form1 : Form
    {
        int delayTimeOff = 0;
        int delayTimeOn = 100;
        bool laserIn = false;
        bool laserOut = false;
        bool colorBall = false;
        bool fOut1 = false;
        bool fOut2 = false;
        bool fOut3 = false;
        bool fOut4 = false;
        bool fIn1 = false;
        bool fIn2 = false;
        bool fIn3 = false;
        bool fIn4 = false;
        SerialPort myPort = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            button2.Text = "Connect";
            GetAvailablePorts();
            lightsGroup.Enabled = false;
            logGroup.Enabled = false;
            delayTimeOff = trackBar1.Value;
            delayTimeOn = trackBar2.Value;
        }

        /*
         * Laser:
         *      In:
         *          on - 0;
         *          off - 1;
         *      Out:
         *          on - 2;
         *          off - 3;
         * Color Ball:
         *      on - 4;
         *      off - 5;
         * Flasher:
         *      Out:
         *       1:
         *          on - a;
         *          off - b;
         *       2:
         *          on - c;
         *          off - d;
         *       3:
         *          on - e;
         *          off - f;
         *       4:
         *          on - g;
         *          off - h;
         *      In:
         *       1:
         *          on - A;
         *          off - B;
         *       2:
         *          on - C;
         *          off - D;
         *       3:
         *          on - E;
         *          off - F;
         *       4:
         *          on - G;
         *          off - H;
         */

        void Pattern1(string bin1On, string bin1Off, string bin2On, string bin2Off, string bin3On, string bin3Off, string bin4On, string bin4Off, string bout1On, string bout1Off, string bout2On, string bout2Off, string bout3On, string bout3Off, string bout4On, string bout4Off) 
        {
            do
            {
                myPort.Write(bin1On);
                fIn1 = true;
                myPort.Write(bin4On);
                fIn4 = true;
                myPort.Write(bout1On);
                fOut1 = true;
                myPort.Write(bout4On);
                fOut4 = true;
                Thread.Sleep(delayTimeOn);
                myPort.Write(bin1Off);
                fIn1 = false;
                myPort.Write(bin4Off);
                fIn4 = false;
                myPort.Write(bout1Off);
                fOut1 = false;
                myPort.Write(bout4Off);
                fOut4 = false;
                Thread.Sleep(delayTimeOff);
                myPort.Write(bin2On);
                fIn2 = true;
                myPort.Write(bin3On);
                fIn3 = true;
                myPort.Write(bout2On);
                fOut2 = true;
                myPort.Write(bout3On);
                fOut3 = true;
                Thread.Sleep(delayTimeOn);
                myPort.Write(bin2Off);
                fIn2 = false;
                myPort.Write(bin3Off);
                fIn3 = false;
                myPort.Write(bout2Off);
                fOut2 = false;
                myPort.Write(bout3Off);
                fOut3 = false;
                Thread.Sleep(delayTimeOff);
            }
            while (true);
        }

        void Pattern2(string bin1On, string bin1Off, string bin2On, string bin2Off, string bin3On, string bin3Off, string bin4On, string bin4Off, string bout1On, string bout1Off, string bout2On, string bout2Off, string bout3On, string bout3Off, string bout4On, string bout4Off)
        {
            do
            {
                myPort.Write(bin1On);
                fIn1 = true;
                myPort.Write(bout1On);
                fOut1 = true;
                Thread.Sleep(delayTimeOn);
                myPort.Write(bin1Off);
                fIn1 = false;
                myPort.Write(bout1Off);
                fOut1 = false;
                Thread.Sleep(delayTimeOff);
                myPort.Write(bin2On);
                fIn2 = true;
                myPort.Write(bout2On);
                fOut2 = true;
                Thread.Sleep(delayTimeOn);
                myPort.Write(bin2Off);
                fIn2 = false;
                myPort.Write(bout2Off);
                fOut2 = false;
                Thread.Sleep(delayTimeOff);
                myPort.Write(bin3On);
                fIn3 = true;
                myPort.Write(bout3On);
                fOut3 = true;
                Thread.Sleep(delayTimeOn);
                myPort.Write(bin3Off);
                fIn3 = false;
                myPort.Write(bout3Off);
                fOut3 = false;
                Thread.Sleep(delayTimeOff);
                myPort.Write(bin4On);
                fIn4 = true;
                myPort.Write(bout4On);
                fOut4 = true;
                Thread.Sleep(delayTimeOn);
                myPort.Write(bin4Off);
                fIn4 = false;
                myPort.Write(bout4Off);
                fOut4 = false;
                Thread.Sleep(delayTimeOff);
                myPort.Write(bin3On);
                fIn3 = true;
                myPort.Write(bout3On);
                fOut3 = true;
                Thread.Sleep(delayTimeOn);
                myPort.Write(bin3Off);
                fIn3 = false;
                myPort.Write(bout3Off);
                fOut3 = false;
                Thread.Sleep(delayTimeOff);
                myPort.Write(bin2On);
                fIn2 = true;
                myPort.Write(bout2On);
                fOut2 = true;
                Thread.Sleep(delayTimeOn);
                myPort.Write(bin2Off);
                fIn2 = false;
                myPort.Write(bout2Off);
                fOut2 = false;
                Thread.Sleep(delayTimeOff);
                myPort.Write(bin1On);
                fIn1 = true;
                myPort.Write(bout1On);
                fOut1 = true;
                Thread.Sleep(delayTimeOn);
                myPort.Write(bin1Off);
                fIn1 = false;
                myPort.Write(bout1Off);
                fOut1 = false;
                Thread.Sleep(delayTimeOff);
            }
            while (true);
        }

        void Pattern3(string bin1On, string bin1Off, string bin2On, string bin2Off, string bin3On, string bin3Off, string bin4On, string bin4Off, string bout1On, string bout1Off, string bout2On, string bout2Off, string bout3On, string bout3Off, string bout4On, string bout4Off)
        {
            do
            {
                myPort.Write(bin1On);
                myPort.Write(bout1On);
                myPort.Write(bin2On);
                myPort.Write(bout2On);
                myPort.Write(bin3On);
                myPort.Write(bout3On);
                myPort.Write(bin4On);
                myPort.Write(bout4On);
                fIn1 = true;
                fIn2 = true;
                fIn3 = true;
                fIn4 = true;
                fOut1 = true;
                fOut2 = true;
                fOut3 = true;
                fOut4 = true;
                Thread.Sleep(delayTimeOn); 
                myPort.Write(bin1Off);
                myPort.Write(bout1Off);
                myPort.Write(bin2Off);
                myPort.Write(bout2Off);
                myPort.Write(bin3Off);
                myPort.Write(bout3Off);
                myPort.Write(bin4Off);
                myPort.Write(bout4Off);
                fIn1 = false;
                fIn2 = false;
                fIn3 = false;
                fIn4 = false;
                fOut1 = false;
                fOut2 = false;
                fOut3 = false;
                fOut4 = false;
                Thread.Sleep(delayTimeOff); 
            }
            while (true);
        }

        void Pattern4(string bin1On, string bin1Off, string bin2On, string bin2Off, string bin3On, string bin3Off, string bin4On, string bin4Off, string bout1On, string bout1Off, string bout2On, string bout2Off, string bout3On, string bout3Off, string bout4On, string bout4Off)
        {
            do
            {
                myPort.Write(bin1On);
                myPort.Write(bout1On);
                myPort.Write(bin2On);
                myPort.Write(bout2On);
                myPort.Write(bin3On);
                myPort.Write(bout3On);
                myPort.Write(bin4On);
                myPort.Write(bout4On);
                fIn1 = true;
                fIn2 = true;
                fIn3 = true;
                fIn4 = true;
                fOut1 = true;
                fOut2 = true;
                fOut3 = true;
                fOut4 = true;
            }
            while (true);
        }

        void AllPatternsOff(string bin1Off, string bout1Off, string bin2Off, string bout2Off, string bin3Off, string bout3Off, string bin4Off, string bout4Off) 
        {
            myPort.Write(bin1Off);
            myPort.Write(bout1Off);
            myPort.Write(bin2Off);
            myPort.Write(bout2Off);
            myPort.Write(bin3Off);
            myPort.Write(bout3Off);
            myPort.Write(bin4Off);
            myPort.Write(bout4Off);
            fIn1 = false;
            fIn2 = false;
            fIn3 = false;
            fIn4 = false;
            fOut1 = false;
            fOut2 = false;
            fOut3 = false;
            fOut4 = false;
        }

        void GetAvailablePorts() 
        {
            string[] a = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(a);
        }

        void OpeningPort() 
        {
            myPort.PortName = comboBox1.Text;
            myPort.BaudRate = Convert.ToInt32(comboBox2.Text);
            myPort.Open();
            button2.Text = "Dissconnect";
            panel1.Enabled = false;
            lightsGroup.Enabled = true;
            logGroup.Enabled = true;
        }

        void ClosingPort()
        {
            myPort.Close();
            button2.Text = "Connect";
            panel1.Enabled = true;
            lightsGroup.Enabled = false;
            logGroup.Enabled = false;
        }

        void Refreshing() 
        {
            comboBox1.Items.Clear();
            GetAvailablePorts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (myPort.IsOpen == true)
                {
                    ClosingPort();
                }
                else if (myPort.IsOpen == false)
                {
                    OpeningPort();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refreshing();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (laserIn == false) 
            {
                myPort.Write("0");
                button3.Text = "on";
                button3.BackColor = Color.DarkOrange;
            }
            else if (laserIn == true)
            {
                myPort.Write("1");
                button3.Text = "off";
                button3.BackColor = Color.GhostWhite;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (laserOut == false)
            {
                myPort.Write("2");
                button4.Text = "on";
                button4.BackColor = Color.DarkOrange;
            }
            else if (laserOut == true)
            {
                myPort.Write("3");
                button4.Text = "off";
                button4.BackColor = Color.GhostWhite;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorBall == false)
            {
                myPort.Write("4");
                button5.Text = "on";
                button5.BackColor = Color.DarkOrange;
            }
            else if (colorBall == true)
            {
                myPort.Write("5");
                button5.Text = "off";
                button5.BackColor = Color.GhostWhite;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (fOut1 == false)
            {
                myPort.Write("a");
                button13.Text = "on";
                button13.BackColor = Color.DarkOrange;
            }
            else if (fOut1 == true)
            {
                myPort.Write("b");
                button13.Text = "off";
                button13.BackColor = Color.GhostWhite;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (fOut2 == false)
            {
                myPort.Write("c");
                button12.Text = "on";
                button12.BackColor = Color.DarkOrange;
            }
            else if (fOut2 == true)
            {
                myPort.Write("d");
                button12.Text = "off";
                button12.BackColor = Color.GhostWhite;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (fOut3 == false)
            {
                myPort.Write("e");
                button11.Text = "on";
                button11.BackColor = Color.DarkOrange;
            }
            else if (fOut3 == true)
            {
                myPort.Write("f");
                button11.Text = "off";
                button11.BackColor = Color.GhostWhite;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (fOut4 == false)
            {
                myPort.Write("g");
                button10.Text = "on";
                button10.BackColor = Color.DarkOrange;
            }
            else if (fOut4 == true)
            {
                myPort.Write("h");
                button10.Text = "off";
                button10.BackColor = Color.GhostWhite;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (fIn1 == false)
            {
                myPort.Write("A");
                button6.Text = "on";
                button6.BackColor = Color.DarkOrange;
            }
            else if (fIn1 == true)
            {
                myPort.Write("B");
                button6.Text = "off";
                button6.BackColor = Color.GhostWhite;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (fIn2 == false)
            {
                myPort.Write("C");
                button7.Text = "on";
                button7.BackColor = Color.DarkOrange;
            }
            else if (fIn2 == true)
            {
                myPort.Write("D");
                button7.Text = "off";
                button7.BackColor = Color.GhostWhite;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (fIn3 == false)
            {
                myPort.Write("E");
                button8.Text = "on";
                button8.BackColor = Color.DarkOrange;
            }
            else if (fIn3 == true)
            {
                myPort.Write("F");
                button8.Text = "off";
                button8.BackColor = Color.GhostWhite;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (fIn4 == false)
            {
                myPort.Write("G");
                button9.Text = "on";
                button9.BackColor = Color.DarkOrange;
            }
            else if (fIn4 == true)
            {
                myPort.Write("H");
                button9.Text = "off";
                button9.BackColor = Color.GhostWhite;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Pattern1("A", "B", "C", "D", "E", "F", "G", "H", "a", "b", "c", "d", "e", "f", "g", "h");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Pattern2("A", "B", "C", "D", "E", "F", "G", "H", "a", "b", "c", "d", "e", "f", "g", "h");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Pattern3("A", "B", "C", "D", "E", "F", "G", "H", "a", "b", "c", "d", "e", "f", "g", "h");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Pattern4("A", "B", "C", "D", "E", "F", "G", "H", "a", "b", "c", "d", "e", "f", "g", "h");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            AllPatternsOff("B", "b", "D", "d", "F", "f", "H", "h");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            delayTimeOff = trackBar1.Value;
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            delayTimeOn = trackBar2.Value;
            textBox2.Text = trackBar2.Value.ToString();
        }
    }
}
