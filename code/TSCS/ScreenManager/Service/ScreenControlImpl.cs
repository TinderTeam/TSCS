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
                    String screenName = ScreenControlDllOperate.getScreenNameByDll();

                    ScreenModel screen = new ScreenModel();
                    screen.ScreenIP = ipList[i];
                    screen.ScreenName = screenName;
                    screenList.List.Add(screen);
                    ScreenControlDllOperate.closeConnectByDll();
                }
                else
                {
                    ScreenControlDllOperate.closeConnectByDll();
                    log.Error("can not find the screen with ip address ." + ipList[i]);
                }
                bar.Value += 20 * (i + 1) / ipList.Count;

            }

            bar.Value = 0;
            return screenList;
        }
        public Boolean setScreenLength(int length)
        {
            Boolean result = ScreenControlDllOperate.setScreenLengthByDll(length);
            if (!result)
            {
                log.Warn("set failed try again");
                result = ScreenControlDllOperate.connectScreenByDLL(this.connectedIP);
                if (result)
                {
                    result = ScreenControlDllOperate.setScreenLengthByDll(length);
                }
            }
            return result;
        }
        public ScreenModel getScreenInfo(String ip)
        {
            ScreenModel screen = new ScreenModel();
            if (!IPAddrHandleUtil.isValid(ip))
            {
                log.Error("the ip address is invalid.the ip address is "+ip);
                return screen;
            }
            bool result = ScreenControlDllOperate.connectScreenByDLL(ip);

            if (!result)
            {
                log.Error("can not connect to ip address.the ip address is" + ip);
                return screen;
            }
           
            this.connectedIP = ip;
         
            ScreenBasicInfoModel screenBasic = ScreenControlDllOperate.getScreenBasicInfoByDll();

            if (null != screenBasic)
            {
                screen.ScreenIP = ip;
                screen.ScreenName = screenBasic.ScreenName;
                screen.ScreenColor = screenBasic.ScreenColor;
                screen.ScreenLightCtrl = screenBasic.LightCtrl;
                screen.LightLevelA = screenBasic.LightLevelA;
                screen.LightLevelB = screenBasic.LightLevelB;
                screen.BasicInfo.ScreenLength = screenBasic.ScreenLength;

                List<RoadModel> roadList = ScreenControlDllOperate.getRoadInfoByDll();
                for (int i = 0; i < roadList.Count; i++)
                {
                    screen.setRoadNameWithId(roadList[i].RoadID, roadList[i].RoadName);
                }
            
            }


            return screen;
        }

        public Boolean modifyScreenIP(string ipAddr,string macAddr)
        {
            if (!IPAddrHandleUtil.isValid(ipAddr))
            {
                log.Error("the ip address is invalid.the ip is " + ipAddr);
                return false;
            }
            Boolean result = ScreenControlDllOperate.setScreenIpAddrByDLL(ipAddr, macAddr);
            if (!result)
            {
                log.Warn("set failed try again");
                result = ScreenControlDllOperate.connectScreenByDLL(this.connectedIP);
                if (result)
                {
                    result = ScreenControlDllOperate.setScreenIpAddrByDLL(ipAddr, macAddr);
                }
            }
            return result;
        }
  
        public Boolean setScreenBasicInfo(ScreenBasicInfoModel basicInfo)
        {
 
            Boolean result = ScreenControlDllOperate.setScreenInfoByDll(basicInfo);
            if (!result)
            {
                log.Warn("set failed try again");
                result = ScreenControlDllOperate.connectScreenByDLL(this.connectedIP);
                if (result)
                {
                    result = ScreenControlDllOperate.setScreenInfoByDll(basicInfo);
                }
            }
            return result;
        }
        public Boolean setScreenRoadInfo(ScreenModel screenModel)
        {
            Boolean result = ScreenControlDllOperate.setRoadInfoByDll(screenModel);
            if (!result)
            {
                log.Warn("set failed try again");
                result = ScreenControlDllOperate.connectScreenByDLL(this.connectedIP);
                if (result)
                {
                    result = ScreenControlDllOperate.setRoadInfoByDll(screenModel);
                }
            }
            return result;
        }
        public Boolean closeScreen()
        {
            Boolean result = ScreenControlDllOperate.setScreenOffByDll();
            if (!result)
            {
                log.Warn("set failed try again");
                result = ScreenControlDllOperate.connectScreenByDLL(this.connectedIP);
                if (result)
                {
                    result = ScreenControlDllOperate.setScreenOffByDll();
                }
            }
            return result;
        }
        public Boolean saveScreen() 
        {
            Boolean result = ScreenControlDllOperate.saveScreenByDll();
            if (!result)
            {
                result = ScreenControlDllOperate.connectScreenByDLL(this.connectedIP);
                if (result)
                {
                    result = ScreenControlDllOperate.saveScreenByDll();
                }
            }
            return result;
        }
        public Boolean openScreen()
        {
            Boolean result =  ScreenControlDllOperate.setScreenOnByDll();
            if (!result)
            {
                log.Warn("set failed try again");
                result = ScreenControlDllOperate.connectScreenByDLL(this.connectedIP);
                if (result)
                {
                    result = ScreenControlDllOperate.setScreenOnByDll();
                }
            }
            return result;
        }
        public Boolean initScreen()
        {
            Boolean result = ScreenControlDllOperate.initScreenByDll();
            if (!result)
            {
                log.Warn("set failed try again");
                result = ScreenControlDllOperate.connectScreenByDLL(this.connectedIP);
                if (result)
                {
                    result = ScreenControlDllOperate.initScreenByDll();
                }
            }
            return result;
        }
    }
}
