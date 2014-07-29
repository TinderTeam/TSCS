using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Service;

namespace ScreenManager.Service
{
    public class ServiceContext
    {

  
        private static ServiceContext instance;
        private ScreenControlInterface screenControl;
        private ServiceContext()
        {

        }
        public static ServiceContext getInstance()
        {
            if (null == instance)
            {
                instance = new ServiceContext();
            }
            return instance;
        }
        public ScreenControlInterface getScreenControl()
        {
            if(null == screenControl)
            {
                screenControl = new ScreenControlImpl();
            }
            return screenControl;

        }
    }
}
