using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialCOM
{
    public partial class Form1 : Form
    {
        SerialPort myPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();
            GetSerials();
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            if (myPort.IsOpen == false)
            {
                button1.Text = "Open Port";
            }
        }

        void GetSerials() 
        {
            String[] a = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" || comboBox2.Text != "")
            {
                if (myPort.IsOpen == false)
                {
                    try
                    {
                        myPort.PortName = comboBox1.Text;
                        myPort.BaudRate = Convert.ToInt32(comboBox2.Text);
                        myPort.Open();
                        progressBar2.Value = 100;
                        MessageBox.Show("You just opened " + comboBox1.Text + " Serial Port");
                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        groupBox2.Enabled = true;
                        groupBox3.Enabled = true;
                        progressBar2.Value = 0;
                        button1.Text = "Close " + comboBox1.Text + " Serial Port";
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    myPort.Close();
                    MessageBox.Show("You just closed " + comboBox1.Text + " Serial Port");
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    button1.Text = "Open Port";

                    if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "") 
                    {
                        textBox1.Clear(); 
                        textBox2.Clear(); 
                        textBox3.Clear();
                        textBox4.Clear();
                    }

                }
            }
            else 
            {
                MessageBox.Show("Configure the Serial Port Settings first.");
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    myPort.Write(textBox1.Text);
                    textBox1.Clear();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            {
                MessageBox.Show("Write something to send FIRST");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    int inputOne = Convert.ToInt32(textBox3.Text);
                    for (int f = 0; f <= inputOne; f++)
                    {
                        myPort.Write(textBox2.Text + "" + f + "" + textBox4.Text);
                        progressBar1.Value = f / inputOne * 100;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            {
                MessageBox.Show("You need to enter some value first");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                myPort.Write(textBox1.Text);
                textBox1.Clear();
            }
        }
    }
}