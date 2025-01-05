using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FileInfo
{
    static class Program
    {
        /// <summary>
        /// Display and log information about files.
        /// Author: Dennis Lang 2009
        /// https://landenlabs.com/
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
