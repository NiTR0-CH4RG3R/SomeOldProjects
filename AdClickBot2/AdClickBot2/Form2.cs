using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace AdClickBot2
{
    public partial class Form2 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        PictureBox pb = new PictureBox();
        int countsClicked = 0;
        public Form2()
        {
            InitializeComponent();
            timer1.Interval = Properties.Settings.Default.IntervalOfForm2Timer;
        }

        private bool findbitmap2(Bitmap bmpNeedle, Bitmap bmpHaystack, out Point location)
        {
            for (int outerX = 0; outerX < bmpHaystack.Width - bmpNeedle.Width; outerX++)
            {
                for (int outerY = 0; outerY < bmpHaystack.Height - bmpNeedle.Height; outerY++)
                {
                    for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                    {
                        for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                        {
                            Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                            Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);

                            if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                            {
                                goto NotFound;
                            }
                        }
                    }
                    location = new Point(outerX, outerY);
                    return true;

                NotFound:
                    continue;
                }
            }
            Point sp = Cursor.Position;
            location = sp;
            return false;
        }

        private Bitmap screenshot()
        {
            Bitmap bmpscreesnhot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmpscreesnhot);
            g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            return bmpscreesnhot;
        }

        private void mouseclick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ob = new OpenFileDialog();
            ob.Title = "Open BMP";
            ob.Filter = "BMP Files (*.bmp)|*.bmp";
            if (ob.ShowDialog() == DialogResult.OK)
            {
                pb.Image = Image.FromFile(ob.FileName.ToString());
                button1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Point location1;
                Bitmap screenShot = screenshot();
                bool abc = findbitmap2(new Bitmap(pb.Image), screenShot, out location1);
                if (abc == true)
                {
                    Cursor.Position = location1;
                    mouseclick();
                    Thread.Sleep(1000);
                    countsClicked = countsClicked + 1;
                    label2.Text = countsClicked.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void OpeneingForm1()
        {
            Application.Run(new Form1());
        }
        Thread t;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = Properties.Settings.Default.IntervalOfForm2Timer;
                //timer1.Interval = 1000;
                timer1.Start();
                t = new Thread(OpeneingForm1);
                t.Start();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                //button3.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form3 myForm = new Form3();
            myForm.Show();
        }
    }
}
