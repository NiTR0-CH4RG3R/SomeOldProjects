using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace TestAdClockBot2._1
{
    public partial class WebBrowser : Form
    {
        string[] proxyList;
        string[] urlList;
        int currentProxy = 0;
        string proxyRegistryPath = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";

        public WebBrowser()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            OpenFileDialog openProxies = new OpenFileDialog();
            openProxies.Title = "Open Proxies";
            openProxies.Filter = "Text Files (*.txt)|*.txt";
            comeHere:
            if (openProxies.ShowDialog() == DialogResult.OK)
            {
                IEnumerable<string> proxies = File.ReadLines(openProxies.FileName);
                proxyList = proxies.ToArray();
                OpenFileDialog openURLs = new OpenFileDialog();
                openURLs.Title = "Open URLs";
                openURLs.Filter = "Text Files (*.txt)|*.txt";
            comeHere1:
                if (openURLs.ShowDialog() == DialogResult.OK)
                {
                    IEnumerable<string> urls = File.ReadLines(openURLs.FileName);
                    urlList = urls.ToArray();
                    Registry.SetValue(proxyRegistryPath, "ProxyEnable", 1);
                    timer1.Interval = Properties.Settings.Default.WebBrowser_TimerInterval;
                    timer1.Start();
                }
                else
                {
                    goto comeHere1;
                    //meeka oona wenne na..
                    //Application.Exit();
                }
            }
            else 
            {
                goto comeHere;
                //meeka oona wenne na..
                //Application.Exit(); 

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currentProxy <= proxyList.GetLength(0))
            {
                Registry.SetValue(proxyRegistryPath, "ProxyServer", proxyList[currentProxy]);
                Random rnd = new Random();
                webBrowser1.Navigate(urlList[rnd.Next(urlList.GetLength(0))]);
                currentProxy = currentProxy + 1;
            }
            else
            {
                Registry.SetValue(proxyRegistryPath, "ProxyEnable", 0);
                Registry.SetValue(proxyRegistryPath, "ProxyServer", "");
                MessageBox.Show("All the proxies has been used.\nPlease reinsert a new proxy List an start earning money\nNumber of proxies used : "+currentProxy);
                Application.Exit();
            }
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
