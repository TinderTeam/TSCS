using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ScreenManager.Forms;
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
            ScreenEditForm screenEditForm = new ScreenEditForm();

            Application.Run(screenEditForm);
           
            
        }
    }
}
