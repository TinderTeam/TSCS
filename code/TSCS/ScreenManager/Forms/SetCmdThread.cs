using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ScreenManager.Util;
using ScreenManager.Service;
using System.Windows.Forms;
namespace ScreenManager.Forms
{
    public class SetCmdThread
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 


        public void setCmd(String cmdCode)
        {

            Thread td = new Thread(new ParameterizedThreadStart(this.openThread));   //需要引入System.Threading命名空间

            td.Start(cmdCode);
        }
 
        private void openThread(Object cmdObj)
        {
            String cmd = (String)cmdObj;
            log.Info("set command code is " + cmd);
            
            switch (cmd)
            {
                case CmdConstants.OPEN_SCREEN:
                    {
                        bool result = ServiceContext.getInstance().getScreenControl().openScreen();
                        msgBox(result);
                        break;
                    }
                    
                   
                case CmdConstants.CLOSE_SCREEN:
                    {
                        bool result = ServiceContext.getInstance().getScreenControl().closeScreen();
                        msgBox(result);
                        break;
                    }
                case CmdConstants.INIT_SCREEN:
                    {
                        bool result = ServiceContext.getInstance().getScreenControl().initScreen();
                        msgBox(result);
                        break;
                    }
                case CmdConstants.SAVE_SCREEN:
                    {
                        bool result = ServiceContext.getInstance().getScreenControl().saveScreen();
                        msgBox(result);
                        break;
                    }
                case CmdConstants.SET_ROAD:
                    {
                     //   bool result = ServiceContext.getInstance().getScreenControl().setScreenRoadInfo();
                      //  msgBox(result);
                        break;
                    }
                case CmdConstants.SET_SCREEN:
                    {
                      //  bool result = ServiceContext.getInstance().getScreenControl().setScreenBasicInfo();
                      //  msgBox(result);
                        break;
                    }
                case CmdConstants.SET_SCREEN_IP:
                    {
                        //bool result = ServiceContext.getInstance().getScreenControl().modifyScreenIP();
                      //  msgBox(result);
                        break;
                    }
                case CmdConstants.SET_SCREEN_LENGTH:
                    {
                      //  bool result = ServiceContext.getInstance().getScreenControl().setScreenLength();
                      //  msgBox(result);
                        break;
                    }


            }

        }

        private static void msgBox(bool result)
        {
            if (!result)
            {
                MessageBox.Show("操作失败");
                //log
            }
            else
            {
                MessageBox.Show("操作成功");
                //log
            }
        }
    }
}
