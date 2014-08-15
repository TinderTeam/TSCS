using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model;
using ScreenManager.Service.util;
using log4net;
using System.Windows.Forms;
using System.Threading;

namespace ScreenManager.Service
{
    public class ScreenControlImpl : ScreenControlInterface
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string connectedIP = "";
  
        public  ScreenListModel searchByIP(string start, string end,ProgressBar bar)
        {
           
            log.Info("search ip ");
            ScreenListModel screenList = new ScreenListModel();
            if (!IPAddrHandleUtil.isValid(start))
            {
                log.Warn("the start ip address is invalid.the start is " + start);
                return screenList;
            }
            if (!IPAddrHandleUtil.isValid(end))
            {
                log.Warn("the start ip address is invalid.the start is " + end);
                return screenList;
            }
            List<String> ipList = IPAddrHandleUtil.getIPListFromIPSegment(start, end);


            PingThread ping = new PingThread();
            ipList = ping.PingWorker(ipList, bar);

 
            for (int i = 0; i < ipList.Count; i++)
            {
                
                bool result = ScreenControlDllOperate.connectScreenByDLL(ipList[i]);
                if (result)
                {
                  
                    try
                    {
                        ScreenModel screen  = ScreenControlDllOperate.getScreenNameInfoByDll();
                        screen.ScreenIP = ipList[i];
                        screenList.List.Add(screen);
                    }
                    catch(SystemException ex)
                    {
                        log.Error("connect screen success,but can not set name success",ex);
                    }
                }
                else
                {
                    ScreenControlDllOperate.closeConnectByDll();
                    log.Error("can not find the screen with ip address ." + ipList[i]);
                }
                ScreenControlDllOperate.closeConnectByDll();
                bar.Value += 20 / ipList.Count;

            }

            bar.Value = 0;
            return screenList;
        }
        public Boolean setScreenLength(int length)
        {

            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                 result = ScreenControlDllOperate.setScreenLengthByDll(length);
                if (!result)
                {
                    log.Warn("screen operate failed, try again");
                    result = ScreenControlDllOperate.setScreenLengthByDll(length);

                }
            }
            else
            {
                log.Error("connect screen failed");
            }
            ScreenControlDllOperate.closeConnectByDll();
            return result;

 
        }

        public ScreenModel getScreenInfo(String ip)
        {
            ScreenModel screen = new ScreenModel();
            if (!IPAddrHandleUtil.isValid(ip))
            {
                log.Error("the ip address is invalid.the ip address is "+ip);
                throw new SystemException("IP 地址不合法");
            }
            log.Info("set new connect ip address.ip is " + ip);
            this.connectedIP  = ip;
            bool result = ScreenControlDllOperate.connectScreenByDLL(this.connectedIP );
            

            if (!result)
            {
                log.Error("can not connect to ip address.the ip address is" + this.connectedIP );

                ScreenControlDllOperate.closeConnectByDll();
                throw new SystemException("连接屏幕失败");
 
            }

            screen = ScreenControlDllOperate.getScreenNameInfoByDll();
         
            ScreenBasicInfoModel screenBasic = ScreenControlDllOperate.getScreenBasicInfoByDll();

            if (null != screenBasic)
            {
                screen.ScreenIP = this.connectedIP;

                screen.ScreenColor = screenBasic.ScreenColor;
 
                screen.ScreenLightCtrl = screenBasic.LightCtrl;
   
                screen.LightLevelA = screenBasic.LightLevelA;
                screen.LightLevelB = screenBasic.LightLevelB;
                screen.BasicInfo.ScreenLength = screenBasic.ScreenLength;
                screen.BasicInfo.ScreenStatus = screenBasic.ScreenStatus;
 
            
            }
            ScreenControlDllOperate.getSegmentInfoByDll(screen.RoadList);

            ScreenControlDllOperate.closeConnectByDll();
            log.Info(screen);

            return screen;
        }

        public Boolean modifyScreenIP(string ipAddr,string macAddr)
        {
            if (!IPAddrHandleUtil.isValid(ipAddr))
            {
                log.Error("the ip address is invalid.the ip is " + ipAddr);
                return false;
            }
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                 result = ScreenControlDllOperate.setScreenIpAddrByDLL(ipAddr, macAddr);
                if (!result)
                {
                    log.Warn("set failed try again");
                    result = ScreenControlDllOperate.setScreenIpAddrByDLL(ipAddr, macAddr);
                }
            }
            else
            {
                log.Error("connect screen failed when modify ip");
            }
            ScreenControlDllOperate.closeConnectByDll();

            return result;
        }

  
  
        public Boolean setScreenAndRoadNameInfo(ScreenModel screen)
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                try
                {
                    result = ScreenControlDllOperate.setScreenNameInfoByDll(screen);
                    if (!result)
                    {
                        log.Warn("screen operate failed, try again");
                        result = ScreenControlDllOperate.setScreenNameInfoByDll(screen);

                    }
                }
                catch (System.Exception ex)
                {
                    log.Error("set screen name failed");
                    ScreenControlDllOperate.closeConnectByDll();
                    throw ex;
                }

            }
            else
            {
                log.Error("connect screen failed");
            }
            ScreenControlDllOperate.closeConnectByDll();
            return result;

        }
        public Boolean setScreenSegmentInfo(ScreenModel screenModel)
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                 result = ScreenControlDllOperate.setSegmentByDll(screenModel);
                if (!result)
                {
                    log.Warn("set failed try again");
                    result = ScreenControlDllOperate.setSegmentByDll(screenModel);

                }
            }
            else
            {
                log.Error("connect screen failed");

            }

            ScreenControlDllOperate.closeConnectByDll();
            return result;
        }

        public Boolean setScreenSegmentColor(int segmentID,int color)
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                result = ScreenControlDllOperate.setSegmentColorByDll(segmentID, color);
                if (!result)
                {
                    log.Warn("set failed try again");
                    result = ScreenControlDllOperate.setSegmentColorByDll(segmentID,color);

                }
            }
            else
            {
                log.Error("connect screen failed");

            }

            ScreenControlDllOperate.closeConnectByDll();
            return result;
        }


        public bool getScreenSegmentInfo(List<RoadModel> roadList)
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                result = ScreenControlDllOperate.getSegmentInfoByDll(roadList);
                if (!result)
                {
                    log.Warn("get failed try again");
                    result = ScreenControlDllOperate.getSegmentInfoByDll(roadList);

                }
            }
            else
            {
                log.Error("connect screen failed");

            }
            ScreenControlDllOperate.closeConnectByDll();
            return result;
        }

        public Boolean closeScreen()
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                result = ScreenControlDllOperate.setScreenOffByDll();
                if (!result)
                {
                    log.Warn("set failed try again");
                    result = ScreenControlDllOperate.setScreenOffByDll();

                }
            }
            else
            {
                log.Error("connect screen failed");

            }

            ScreenControlDllOperate.closeConnectByDll();
 
            return result;
        }
        public Boolean saveScreen() 
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                result = ScreenControlDllOperate.saveScreenByDll();
                if (!result)
                {
                    log.Warn("set failed try again");
                    result = ScreenControlDllOperate.saveScreenByDll();

                }
            }
            else
            {
                log.Error("connect screen failed");

            }
            ScreenControlDllOperate.closeConnectByDll();
            return result;
           
        }
        public Boolean openScreen()
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                result = ScreenControlDllOperate.setScreenOnByDll();
                if (!result)
                {
                    log.Warn("set failed try again");
                    result = ScreenControlDllOperate.setScreenOnByDll();

                }
            }
            else
            {
                log.Error("connect screen failed");

            }
            ScreenControlDllOperate.closeConnectByDll();
            return result;
 
        }
        public Boolean initScreen()
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                result = ScreenControlDllOperate.initScreenByDll();
                if (!result)
                {
                    log.Warn("set failed try again");
                    result = ScreenControlDllOperate.initScreenByDll();

                }
            }
            else
            {
                log.Error("connect screen failed");

            }
            ScreenControlDllOperate.closeConnectByDll();
            return result;
 
        }
        public int getScreenOpenStatus()
        {

            return 0;
        }

        public Boolean setScreenColor(int color)
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                result = ScreenControlDllOperate.setScreenColorByDll(color);
                if (!result)
                {
                    log.Warn("screen operate failed, try again");
                    result = ScreenControlDllOperate.setScreenColorByDll(color);

                }
            }
            else
            {
                log.Error("connect screen failed");
            }
            ScreenControlDllOperate.closeConnectByDll();
            return result;
        }

        public Boolean setcreenLight(ScreenBasicInfoModel basicInfo)
        {
            bool result = ScreenControlDllOperate.connectScreenByDLL(connectedIP);
            if (result)
            {
                result = ScreenControlDllOperate.setScreenLightByDll(basicInfo);
                if (!result)
                {
                    log.Warn("screen operate failed, try again");
                    result = ScreenControlDllOperate.setScreenLightByDll(basicInfo);

                }
            }
            else
            {
                log.Error("connect screen failed");
            }
            ScreenControlDllOperate.closeConnectByDll();
            return result;
        }
 
    }
}
