using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;


namespace AdClickBot1._1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        ChromiumWebBrowser webBrowser;
        PictureBox pictureBox = new PictureBox();
        string[] proxyListArray;
        string[] urlListArray;
        string proxyPath = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        int proxy = 0;
        int countsClicked = 0;
        public Form1()
        {
            InitializeComponent();
            Cef.Initialize(new CefSettings());
            webBrowser = new ChromiumWebBrowser("http://activeterium.com/tfZ");
            panel1.Controls.Add(webBrowser);
            webBrowser.Dock = DockStyle.Fill;
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

        private void OpeningPicture()
        {
            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.Title = "Open Picture";
            openPicture.Filter = "Bitmap Files (*.bmp)|*.bmp";
            if (openPicture.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(openPicture.FileName.ToString());
                button2.Enabled = true;
            }
        }

        private void OpeningProxies()
        {
            OpenFileDialog openProxy = new OpenFileDialog();
            openProxy.Title = "Open ProxyList";
            openProxy.Filter = "Text Files (*.txt)|*.txt";
            if (openProxy.ShowDialog() == DialogResult.OK)
            {
                IEnumerable<string> proxyList = File.ReadLines(openProxy.FileName);
                proxyListArray = proxyList.ToArray();
                button3.Enabled = true;
            }
        }

        private void OpeningURLs()
        {
            OpenFileDialog openURL = new OpenFileDialog();
            openURL.Title = "Open URLlist";
            openURL.Filter = "Text Files (*.txt)|*.txt";
            if (openURL.ShowDialog() == DialogResult.OK)
            {
                IEnumerable<string> urlList = File.ReadLines(openURL.FileName);
                urlListArray = urlList.ToArray();
                button4.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpeningPicture();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpeningProxies();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpeningURLs();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registry.SetValue(proxyPath, "ProxyEnable", 1);
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Registry.SetValue(proxyPath, "ProxyEnable", 0);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try 
            {
                if (proxy <= proxyListArray.GetLength(0))
                {
                    try
                    {
                        Registry.SetValue(proxyPath, "ProxyServer", proxyListArray[proxy]);
                        label4.Text = proxyListArray[proxy];
                        Random rnd = new Random();
                        int rndurl = rnd.Next(urlListArray.GetLength(0));
                        webBrowser.Load(urlListArray[rndurl]);
                        label6.Text = urlListArray[rndurl];
                        Thread.Sleep(15000);
                        proxy = proxy + 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                //comehere: 
                    Point location1;
                    Bitmap screenShot = screenshot();
                    bool abc = findbitmap2(new Bitmap(pictureBox.Image), screenShot, out location1);
                    if (abc == true)
                    {
                        Cursor.Position = location1;
                        mouseclick();
                        Thread.Sleep(1000);
                        countsClicked = countsClicked + 1;
                        label3.Text = countsClicked.ToString();
                    }
                    else
                    {
                        //goto comehere;
                    }
                }
                else
                {
                    timer1.Stop();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
