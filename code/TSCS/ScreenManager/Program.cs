using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ScreenManager.Service;

namespace ScreenManager
{
    static class Program
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           bool connected =  ScreenControlDllOperate.connectScreenByDLL("218.244.133.177");

           log.Info("connect to ip " + connected);

           string screenName = ScreenControlDllOperate.getScreenNameByDll();

           log.Info("connect to ip " + screenName);

           // Console.WriteLine("test");
           // Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
           // ScreenForm screenForm = new ScreenForm();
          
          //  Application.Run(screenForm);
           
            
        }
    }
}
