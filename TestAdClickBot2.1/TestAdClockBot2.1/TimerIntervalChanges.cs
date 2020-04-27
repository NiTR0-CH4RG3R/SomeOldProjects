using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestAdClockBot2._1
{
    public partial class TimerIntervalChanges : Form
    {
        public TimerIntervalChanges()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.MainMenu_TimerInterval.ToString();
            textBox2.Text = Properties.Settings.Default.WebBrowser_TimerInterval.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.MainMenu_TimerInterval = int.Parse(textBox1.Text);
                Properties.Settings.Default.WebBrowser_TimerInterval = int.Parse(textBox2.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainMenu_TimerInterval = 2000;
            Properties.Settings.Default.WebBrowser_TimerInterval = 12000;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
