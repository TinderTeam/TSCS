using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScreenManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("test");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ScreenForm screenForm = new ScreenForm();
          
            Application.Run(screenForm);
           
            
        }
    }
}
