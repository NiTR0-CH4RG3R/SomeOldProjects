using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SlimDX.DirectInput;
using System.IO.Ports;

namespace Joystick1._1
{
    public partial class Form1 : Form
    {
        SerialPort myPort = new SerialPort();
        DirectInput myInput = new DirectInput();
        SlimDX.DirectInput.Joystick myStick;
        Joystick[] mySticks;
        int xVal = 0;
        int yVal = 0;
        int zVal = 0;
        int b = 0;
        int k;
        int rangeStart;
        int rangeEnd;
        int timerInterval;

        public Form1()
        {
            InitializeComponent();
            if (Properties.Settings.Default.TimerInterval == 0)
            {
                Properties.Settings.Default.TimerInterval = 1;
            }
            timer1.Interval = Properties.Settings.Default.TimerInterval;
            timerInterval = Properties.Settings.Default.TimerInterval;
            label16.Text = "You have not connected a joystick\nPlease connect a joystick and reopen the\napplication";
            panel1.Enabled = false;
            GetSticks();
            mySticks = GetSticks();
            timer1.Enabled = true;
            AvailablePorts();
            if (myPort.IsOpen == false) 
            {
                k = 0;
                button2.Text = "Open";
                label20.Text = "Not Connected";
            }
        }

        void AvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            string[] brates = { "9600", "19200", "38400", "57600", "74880", "115200", "230400", "250000" };
            comboBox2.Items.AddRange(brates);
        }
        public Joystick[] GetSticks()
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
            foreach (DeviceInstance device in myInput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    myStick = new SlimDX.DirectInput.Joystick(myInput, device.InstanceGuid);
                    myStick.Acquire();
                    label16.Text = "Connected";
                    panel1.Enabled = true;
                    foreach (DeviceObjectInstance deviceObject in myStick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                        {
                            myStick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(Properties.Settings.Default.DataRangeStarts, Properties.Settings.Default.DataRangeEnds);
                        }
                    }
                    sticks.Add(myStick);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            rangeStart = Properties.Settings.Default.DataRangeStarts;
            rangeEnd = Properties.Settings.Default.DataRangeEnds;
            return sticks.ToArray();
        }

        private void StickHandle(Joystick myStick, int id)
        {
            JoystickState state = new JoystickState();
            state = myStick.GetCurrentState();
            xVal = state.X;
            yVal = state.Y;
            zVal = state.Z;

            textBox11.Text = Convert.ToString(xVal);
            if (xVal != Properties.Settings.Default.DataRangeStarts) { textBox11.BackColor = Color.Gold; } else { textBox11.BackColor = Color.WhiteSmoke; }
            textBox12.Text = Convert.ToString(yVal);
            if (yVal != Properties.Settings.Default.DataRangeStarts) { textBox12.BackColor = Color.Gold; } else { textBox12.BackColor = Color.WhiteSmoke; }
            textBox13.Text = Convert.ToString(zVal);
            if (zVal != Properties.Settings.Default.DataRangeStarts) { textBox13.BackColor = Color.Gold; } else { textBox13.BackColor = Color.WhiteSmoke; }

            bool[] buttons = state.GetButtons();

            if (id == 0)
            {
                if (buttons[0]) 
                {
                    textBox1.Text = "1";
                    textBox1.BackColor = Color.Gold;
                    b = Properties.Settings.Default.Button_1;
                }
                else if (buttons[1]) 
                {
                    textBox2.Text = "1";
                    textBox2.BackColor = Color.Gold;
                    b = Properties.Settings.Default.Button_2;
                }
                else if (buttons[2]) 
                {
                    textBox3.Text = "1";
                    textBox3.BackColor = Color.Gold;
                    b = Properties.Settings.Default.Button_3;
                }
                else if (buttons[3]) 
                {
                    textBox4.Text = "1";
                    textBox4.BackColor = Color.Gold;
                    b = Properties.Settings.Default.Button_4;
                }
                else if (buttons[4]) 
                {
                    textBox5.Text = "1";
                    textBox5.BackColor = Color.Gold;
                    b = Properties.Settings.Default.LS;
                }
                else if (buttons[5]) 
                {
                    textBox6.Text = "1";
                    textBox6.BackColor = Color.Gold;
                    b = Properties.Settings.Default.RS;
                }
                else if (buttons[6]) 
                {
                    textBox7.Text = "1";
                    textBox7.BackColor = Color.Gold;
                    b = Properties.Settings.Default.LT;
                }
                else if (buttons[7]) 
                {
                    textBox8.Text = "1";
                    textBox8.BackColor = Color.Gold;
                    b = Properties.Settings.Default.RT;
                }
                else if (buttons[8]) 
                {
                    textBox9.Text = "1";
                    textBox9.BackColor = Color.Gold;
                    b = Properties.Settings.Default.Select_Button;
                }
                else if (buttons[9]) 
                {
                    textBox10.Text = "1";
                    textBox10.BackColor = Color.Gold;
                    b = Properties.Settings.Default.Start_Button;
                }
                else 
                {
                    textBox1.Text = "0";
                    textBox1.BackColor = Color.WhiteSmoke;
                    textBox2.Text = "0";
                    textBox2.BackColor = Color.WhiteSmoke;
                    textBox3.Text = "0";
                    textBox3.BackColor = Color.WhiteSmoke;
                    textBox4.Text = "0";
                    textBox4.BackColor = Color.WhiteSmoke;
                    textBox5.Text = "0";
                    textBox5.BackColor = Color.WhiteSmoke;
                    textBox6.Text = "0";
                    textBox6.BackColor = Color.WhiteSmoke;
                    textBox7.Text = "0";
                    textBox7.BackColor = Color.WhiteSmoke;
                    textBox8.Text = "0";
                    textBox8.BackColor = Color.WhiteSmoke;
                    textBox9.Text = "0";
                    textBox9.BackColor = Color.WhiteSmoke;
                    textBox10.Text = "0";
                    textBox10.BackColor = Color.WhiteSmoke;
                    b = 0;
                }
            }
            textBox14.Text = Convert.ToString(xVal)+","+Convert.ToString(yVal)+","+Convert.ToString(zVal)+","+Convert.ToString(b)+",";
            if (k == 1)
            {
                try { myPort.Write(textBox14.Text); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < mySticks.Length; i++)
            {
                StickHandle(mySticks[i], i);

            }
            if (Properties.Settings.Default.DataRangeStarts != rangeStart || Properties.Settings.Default.DataRangeEnds != rangeEnd) 
            {
                GetSticks();
                mySticks = GetSticks();
            }
            if (Properties.Settings.Default.TimerInterval != timerInterval)
            {
                timer1.Interval = Properties.Settings.Default.TimerInterval;
                timerInterval = Properties.Settings.Default.TimerInterval;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Joystick[] joystick = GetSticks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            AvailablePorts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (myPort.IsOpen == false)
            {
                try
                {
                    myPort.PortName = comboBox1.Text;
                    myPort.BaudRate = Convert.ToInt32(comboBox2.Text);
                    myPort.Open();
                    k = 1;
                    MessageBox.Show("You have successfully opened " + comboBox1.Text + " port");
                    button2.Text = "Close " + comboBox1.Text + " Port";
                    label20.Text = "Connected";
                    panel2.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (myPort.IsOpen == true)
            {
                myPort.Close();
                k = 0;
                MessageBox.Show("You closed " + comboBox1.Text + " port");
                button2.Text = "Open";
                label20.Text = "Not Connected";
                panel2.Enabled = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 mySecondForm = new Form2();
            mySecondForm.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 mySecondForm = new Form2();
            mySecondForm.Show();
        }
    }
}
