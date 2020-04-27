using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TestAdClockBot2._1
{
    static class Program
    {
        static string pathnew = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBox.Show("Please be sure about the syntax of the URL list and the proxy list.\nAnd also remember this application won't work for Dial up connections and VPN connections.\nVery IMPORTANTLY Do NOT Rename this file or this won't work perfectly.");
            try
            {
                Registry.SetValue(pathnew, "TestAdClockBot2.1.exe", 11001);
                Registry.SetValue(pathnew, "TestAdClockBot2.1.vshost.exe", 11001);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
