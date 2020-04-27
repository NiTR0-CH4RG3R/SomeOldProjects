using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdClickBot2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(Properties.Settings.Default.IntervalOFForm1Timer);
            textBox2.Text = Convert.ToString(Properties.Settings.Default.IntervalOfForm2Timer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.IntervalOFForm1Timer = int.Parse(textBox1.Text);
                Properties.Settings.Default.IntervalOfForm2Timer = int.Parse(textBox2.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IntervalOFForm1Timer = 12000;
            Properties.Settings.Default.IntervalOfForm2Timer = 1000;
            Properties.Settings.Default.Save();
            textBox1.Text = Convert.ToString(Properties.Settings.Default.IntervalOFForm1Timer);
            textBox2.Text = Convert.ToString(Properties.Settings.Default.IntervalOfForm2Timer);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
