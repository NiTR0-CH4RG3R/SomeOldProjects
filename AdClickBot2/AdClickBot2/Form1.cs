using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetBrowser;
using DotNetBrowser.WinForms;
using System.IO;
using Microsoft.Win32;

namespace AdClickBot2
{
    public partial class Form1 : Form
    {
        string[] urlList;
        string[] proxyList;
        int proxyCount = 0;
        Browser myBrowser;
        string proxyPath = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";


        public Form1()
        {

            InitializeComponent();
            timer1.Interval = Properties.Settings.Default.IntervalOFForm1Timer;
            try
            {
                OpenFileDialog ob = new OpenFileDialog();
                ob.Title = "Open URLs";
                ob.Filter = "Text Files (*.txt)|*.txt";
            gothere:
                if (ob.ShowDialog() == DialogResult.OK)
                {
                    IEnumerable<string> url = File.ReadLines(ob.FileName);
                    urlList = url.ToArray();
                    myBrowser = BrowserFactory.Create();
                    BrowserView myBrowserView = new WinFormsBrowserView(myBrowser);
                    this.Controls.Add((Control)myBrowserView);
                    myBrowser.LoadURL("http://activeterium.com/te3");
                    Registry.SetValue(proxyPath, "ProxyEnable", 1);

                    OpenFileDialog ob1 = new OpenFileDialog();
                    ob1.Title = "Open Proxies";
                    ob1.Filter = "Text Files (*.txt)|*.txt";
                gothere1:
                    if (ob1.ShowDialog() == DialogResult.OK)
                    {
                        IEnumerable<string> proxy = File.ReadLines(ob1.FileName);
                        proxyList = proxy.ToArray();
                        //timer1.Interval = 12000;
                        timer1.Start();
                    }
                    else
                    {
                        goto gothere1;
                        //Close();
                    }
                }
                else
                {
                    goto gothere;
                    //Close();
                }
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
                if (proxyCount <= proxyList.GetLength(0))
                {
                    Registry.SetValue(proxyPath, "ProxyServer", proxyList[proxyCount]);
                    proxyCount = proxyCount + 1;
                }
                else
                {
                    MessageBox.Show(proxyCount + "\nAll proxies has been used");
                    timer1.Stop();
                    this.Close();
                }
                Random rd = new Random();
                int a = rd.Next(urlList.GetLength(0));
                myBrowser.LoadURL(urlList[a]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
