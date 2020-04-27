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

namespace TestAdClockBot2._1
{
    public partial class MainWindow : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        PictureBox pb = new PictureBox();
        int countsClicked = 0;
        Thread webBrowserThread;

        public MainWindow()
        {
            InitializeComponent();
            //label5.Text = Properties.Settings.Default.MainMenu_TimerInterval.ToString();
            // label6.Text = Properties.Settings.Default.WebBrowser_TimerInterval.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPic = new OpenFileDialog();
            openPic.Title = "Open Picture";
            openPic.Filter = "Bitmap (*.bmp)|*.bmp";
            if (openPic.ShowDialog() == DialogResult.OK)
            {
                pb.Image = Image.FromFile(openPic.FileName);
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Here We Go!");
                webBrowserThread = new Thread(() => Application.Run(new WebBrowser()));
                webBrowserThread.SetApartmentState(ApartmentState.STA);
                webBrowserThread.Start();

                timer1.Interval = Properties.Settings.Default.MainMenu_TimerInterval;
                timer1.Start();

                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try 
            {
                Point location1;
                Bitmap screenshot1 = screenshot();
                bool fuckThis = findbitmap2(new Bitmap(pb.Image), screenshot1, out location1);
                if (fuckThis == true)
                {
                    Cursor.Position = location1;
                    mouseclick();
                    Thread.Sleep(2000);
                    countsClicked = countsClicked + 1;
                    label2.Text = countsClicked.ToString();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Closing Web Browser thread from this form is still Experimental.\nSometimes this doesn't work correctly.\nSo you may have to close the browser manualy.");
                timer1.Stop();
                webBrowserThread.Abort();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TimerIntervalChanges tmc = new TimerIntervalChanges();
            tmc.TopMost = true;
            tmc.Show();
        }
    }
}
