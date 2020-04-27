using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joystick1._1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            GettingReadingsFromProperties();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "")
                {
                    if (Convert.ToInt32(textBox11.Text) < Convert.ToInt32(textBox12.Text))
                    {
                        if (Convert.ToInt32(textBox13.Text) > 0)
                        {
                            Properties.Settings.Default.Button_1 = Convert.ToInt32(textBox1.Text);
                            Properties.Settings.Default.Button_2 = Convert.ToInt32(textBox6.Text);
                            Properties.Settings.Default.Button_3 = Convert.ToInt32(textBox2.Text);
                            Properties.Settings.Default.Button_4 = Convert.ToInt32(textBox7.Text);
                            Properties.Settings.Default.LS = Convert.ToInt32(textBox3.Text);
                            Properties.Settings.Default.RS = Convert.ToInt32(textBox8.Text);
                            Properties.Settings.Default.LT = Convert.ToInt32(textBox4.Text);
                            Properties.Settings.Default.RT = Convert.ToInt32(textBox9.Text);
                            Properties.Settings.Default.Select_Button = Convert.ToInt32(textBox5.Text);
                            Properties.Settings.Default.Start_Button = Convert.ToInt32(textBox10.Text);
                            Properties.Settings.Default.DataRangeStarts = Convert.ToInt32(textBox11.Text);
                            Properties.Settings.Default.DataRangeEnds = Convert.ToInt32(textBox12.Text);
                            Properties.Settings.Default.TimerInterval = Convert.ToInt32(textBox13.Text);

                            try
                            {
                                Properties.Settings.Default.Save();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Timer Interval cannot be 0 or less than 0");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Parameter Passed");
                    }
                }
                else
                {
                    MessageBox.Show("These Settings Cannot be empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void GettingReadingsFromProperties()
        {
            textBox1.Text = Convert.ToString(Properties.Settings.Default.Button_1);
            textBox6.Text = Convert.ToString(Properties.Settings.Default.Button_2);
            textBox2.Text = Convert.ToString(Properties.Settings.Default.Button_3);
            textBox7.Text = Convert.ToString(Properties.Settings.Default.Button_4);
            textBox3.Text = Convert.ToString(Properties.Settings.Default.LS);
            textBox8.Text = Convert.ToString(Properties.Settings.Default.RS);
            textBox4.Text = Convert.ToString(Properties.Settings.Default.LT);
            textBox9.Text = Convert.ToString(Properties.Settings.Default.RT);
            textBox5.Text = Convert.ToString(Properties.Settings.Default.Select_Button);
            textBox10.Text = Convert.ToString(Properties.Settings.Default.Start_Button);
            textBox11.Text = Convert.ToString(Properties.Settings.Default.DataRangeStarts);
            textBox12.Text = Convert.ToString(Properties.Settings.Default.DataRangeEnds);
            textBox13.Text = Convert.ToString(Properties.Settings.Default.TimerInterval);

        }

        void DefaultSettings()
        {
            Properties.Settings.Default.Button_1 = 1;
            Properties.Settings.Default.Button_2 = 2;
            Properties.Settings.Default.Button_3 = 3;
            Properties.Settings.Default.Button_4 = 4;
            Properties.Settings.Default.LS = 5;
            Properties.Settings.Default.RS = 6;
            Properties.Settings.Default.LT = 7;
            Properties.Settings.Default.RT = 8;
            Properties.Settings.Default.Select_Button = 9;
            Properties.Settings.Default.Start_Button = 10;
            Properties.Settings.Default.DataRangeStarts = 0;
            Properties.Settings.Default.DataRangeEnds = 255;
            Properties.Settings.Default.TimerInterval = 1;

            textBox1.Text = Convert.ToString(Properties.Settings.Default.Button_1);
            textBox6.Text = Convert.ToString(Properties.Settings.Default.Button_2);
            textBox2.Text = Convert.ToString(Properties.Settings.Default.Button_3);
            textBox7.Text = Convert.ToString(Properties.Settings.Default.Button_4);
            textBox3.Text = Convert.ToString(Properties.Settings.Default.LS);
            textBox8.Text = Convert.ToString(Properties.Settings.Default.RS);
            textBox4.Text = Convert.ToString(Properties.Settings.Default.LT);
            textBox9.Text = Convert.ToString(Properties.Settings.Default.RT);
            textBox5.Text = Convert.ToString(Properties.Settings.Default.Select_Button);
            textBox10.Text = Convert.ToString(Properties.Settings.Default.Start_Button);
            textBox11.Text = Convert.ToString(Properties.Settings.Default.DataRangeStarts);
            textBox12.Text = Convert.ToString(Properties.Settings.Default.DataRangeEnds);
            textBox13.Text = Convert.ToString(Properties.Settings.Default.TimerInterval);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DefaultSettings();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Close();
        }
    }
}
