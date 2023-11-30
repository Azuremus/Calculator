/////////////////////////////////////////////////////////////////////////////
// Ryan Enyeart-Youngblood
// TINFO-200A - C# Programming
// 2023-01-09
//////////////////////////////////////////////////////////////////
// Simple Calculator Program
// A simple calculator that can take a user's button input and 
// do basic math calulations.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
