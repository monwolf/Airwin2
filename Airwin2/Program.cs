using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AirWin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.OperatingSystem OS_info = System.Environment.OSVersion;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if( OS_info.Version.Major>=6)
            Application.Run(new MainForm()); // Windows Vista o Superior
            else 
            Application.Run(new AirWin.AdvertenciaWinXP()); // Inferior a vista



        }
    }
}
