using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model;
using ScreenManager.Service.util;
using log4net; 

namespace ScreenManager.Service
{
    public class ScreenControlImpl : ScreenControlInterface
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 

        public ScreenListModel searchByIP(string start, string end)
        {
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

            }
            return screenList;
        }
        public Boolean setScreenLength(int length)
        {
            return true;
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

            //
            ScreenBasicInfoModel screenBasic = ScreenControlDllOperate.getScreenBasicInfoByDll();
            screen.ScreenName = screenBasic.ScreenName;
            screen.ScreenColor = screenBasic.ScreenColor;
            screen.ScreenLightCtrl = screenBasic.LightCtrl;
            screen.LightLevelA = screenBasic.LightLevelA;
            screen.LightLevelB = screenBasic.LightLevelB;

            List<RoadModel> roadList =  ScreenControlDllOperate.getRoadInfoByDll();
            for (int i = 0; i<roadList.Count; i++)
            {
                screen.setRoadNameWithId(roadList[i].RoadID, roadList[i].RoadName);
            }
            

            return screen;
        }

        public Boolean modifyScreenIP(string oldIPAddr, string newIPAddr)
        {
            return true;
        }
        public Boolean setScreenInfo(ScreenBasicInfoModel basicInfo)
        {
            ScreenControlDllOperate.setScreenInfoByDll(basicInfo);
            return true;
        }
        public Boolean setScreenSegment(ScreenModel screenModel)
        {
            return true;
        }
        public Boolean closeScreen()
        {
            return ScreenControlDllOperate.setScreenOffByDll();
        }
        public Boolean saveScreen() 
        {
            return ScreenControlDllOperate.saveScreenByDll();
        }
        public Boolean openScreen()
        {
            return ScreenControlDllOperate.setScreenOnByDll();
        }
        public Boolean initScreen()
        {
            return ScreenControlDllOperate.setScreenOnByDll();
        }
    }
}
