﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using ScreenManager.Model;

namespace ScreenManager.Service
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SCREEN_LIGHT_INFO
    {
	   public int lightCtr;
       public int lightA;
       public int lightB;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ROAD_INFO
    {
        public int roadNum;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string roadName; 
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SEGMENT_INFO
    {
        public int roadNum;
        public int segNum;
        public int color;
        public int startAddr;
        public int endAddr;   
    } 

    public class ScreenControlDllOperate
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [DllImport("ScreenController.dll", EntryPoint = "connectScreen")]
        private static extern bool connectScreen(string ipAddr);
        public static bool connectScreenByDLL(string ipAddr)
        {
            log.Info("now open the connect");
            bool result = false;
            try
            {
                result = connectScreen(ipAddr);
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception",ex);
            }
            
            return result;
        }

        [DllImport("ScreenController.dll", EntryPoint = "setScreenIpAddr")]
        private static extern bool setScreenIpAddr(string ipAddr, string macAddr);
        public static bool setScreenIpAddrByDLL(string ipAddr,string macAddr)
        {
            bool result = false;
            try
            {
                result = setScreenIpAddr(ipAddr, macAddr);
            }
            catch(System.Exception ex)
            {
                 log.Error("call dll exception",ex);
            }
            return result;
        }

        [DllImport("ScreenController.dll", EntryPoint = "getScreenName")]
        private static extern IntPtr getScreenName();
        public static string getScreenNameByDll()
        {
            IntPtr name;
            string str = "";

            try
            {
                name = getScreenName();
                str = Marshal.PtrToStringAnsi(name);
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }

            log.Info("get screen name is " + str);
 
            return str;
        }

 

        [DllImport("ScreenController.dll", EntryPoint = "getRoadInfo")]
        private static extern bool getRoadInfo(IntPtr roadInfo, int length);
        public static List<RoadModel> getRoadInfoByDll()
        {
            List<RoadModel> roadList = new List<RoadModel>();
            try
            {
                int roadNum = 10;

                ROAD_INFO[] infos = new ROAD_INFO[roadNum];
                for (int i = 0; i < roadNum; i++)
                {
                    infos[i] = new ROAD_INFO();
                }

              /*  IntPtr[] ptArr = new IntPtr[1];
                ptArr[0] = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ROAD_INFO)) * roadNum); //分配包含两个元素的数组   
                IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ROAD_INFO)));
                Marshal.Copy(ptArr, 0, pt, 1); //拷贝指针数组  



                bool result = getRoadInfo(pt, roadNum);

                if (!result)
                {
                    log.Error("get road info failed");
                    return roadList;
                }


                for (int i = 0; i < roadNum; i++)
                {
                    infos[i] = (ROAD_INFO)Marshal.PtrToStructure((IntPtr)(pt.ToInt32() + i * Marshal.SizeOf(typeof(ROAD_INFO))), typeof(ROAD_INFO));
                    RoadModel road = new RoadModel();
                    road.RoadID = infos[i].roadNum;
                    road.RoadName = infos[i].roadName;
                    roadList.Add(road);
                }*/

                IntPtr roadPt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ROAD_INFO)) * roadNum);
                long longSegPt = roadPt.ToInt64();

                for (int i = 0; i < infos.Length; i++)
                {
                    IntPtr RectPtr = new IntPtr(longSegPt);
                    Marshal.StructureToPtr(infos[i], RectPtr, false); // You do not need to erase struct in this case
                    longSegPt += Marshal.SizeOf(typeof(ROAD_INFO));
                }

                bool result = getRoadInfo(roadPt, roadNum);

                for (int i = 0; i < roadNum; i++)
                {
                    infos[i] = (ROAD_INFO)Marshal.PtrToStructure((IntPtr)(roadPt.ToInt32() + i * Marshal.SizeOf(typeof(ROAD_INFO))), typeof(ROAD_INFO));
                    RoadModel road = new RoadModel();
                    road.RoadID = infos[i].roadNum;
                    road.RoadName = infos[i].roadName;
                    roadList.Add(road);
                }

                Marshal.FreeHGlobal(roadPt);

            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }
           
           

            return roadList;
        }

        [DllImport("ScreenController.dll", EntryPoint = "setRoadInfo")]
        private static extern bool setRoadInfo(IntPtr roadInfo, int length);
        [DllImport("ScreenController.dll", EntryPoint = "setScreenDisp")]
        private static extern bool setScreenDisp(IntPtr segmentInfo, int length,int screenColor);
        public static bool setRoadInfoByDll(ScreenModel screen)
        {
            log.Info("set road information." + screen);
            bool result = false;
            try
            {
                result  = setRoadNameList(screen);


                if (!result)
                {
                    log.Error("set road name failed");
                    return result;
                }
                // set segment list
                result = setSegmentList(screen);

            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }


            return result;
        }

        private static bool setSegmentList(ScreenModel screen)
        {
            List<SegmentModel> segmentList = screen.getSegmentList();
            int segmentNum = segmentList.Count;


            SEGMENT_INFO[] segInfoArr = new SEGMENT_INFO[segmentNum];
            for (int i = 0; i < segmentNum; i++)
            {
                segInfoArr[i] = new SEGMENT_INFO();
                segInfoArr[i].roadNum = screen.getRoadModelBySegmentId(segmentList[i].SegmentID).RoadID;
                segInfoArr[i].color = segmentList[i].SegmentColor;
                segInfoArr[i].segNum = segmentList[i].SegmentID;
                segInfoArr[i].startAddr = segmentList[i].Address.Start;
                segInfoArr[i].endAddr = segmentList[i].Address.End;

            }

            //copy the data to the point
            IntPtr segPt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SEGMENT_INFO)) * segmentNum);
            long longSegPt = segPt.ToInt64();

            for (int i = 0; i < segInfoArr.Length; i++)
            {
                IntPtr RectPtr = new IntPtr(longSegPt);
                Marshal.StructureToPtr(segInfoArr[i], RectPtr, false); // You do not need to erase struct in this case
                longSegPt += Marshal.SizeOf(typeof(SEGMENT_INFO));
            }

            bool result = setScreenDisp(segPt, segmentNum,screen.ScreenColor);

            Marshal.FreeHGlobal(segPt);

            return result;
        }
        private static bool setRoadNameList(ScreenModel screen)
        {
            int roadNum = screen.roadList.Count;

            ROAD_INFO[] roadArr = new ROAD_INFO[roadNum];
            for (int i = 0; i < roadNum; i++)
            {
                roadArr[i] = new ROAD_INFO();
                roadArr[i].roadName = screen.roadList[i].RoadName;
                roadArr[i].roadNum = screen.roadList[i].RoadID;
            }

            //copy the data to the point
            IntPtr roadPt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ROAD_INFO)) * roadNum);
            long longRoadPt = roadPt.ToInt64();

            for (int i = 0; i < roadArr.Length; i++)
            {
                IntPtr RectPtr = new IntPtr(longRoadPt);
                Marshal.StructureToPtr(roadArr[i], RectPtr, false); // You do not need to erase struct in this case
                longRoadPt += Marshal.SizeOf(typeof(ROAD_INFO));
            }


            bool result = setRoadInfo(roadPt, roadNum);

            Marshal.FreeHGlobal(roadPt);

            return result;
        }
        [DllImport("ScreenController.dll", EntryPoint = "setScreenLight")]
        private static extern bool setScreenLight(ref SCREEN_LIGHT_INFO lightInfo);
        [DllImport("ScreenController.dll", EntryPoint = "setScreenName")]
        private static extern bool setScreenName(string ipAddr);
        [DllImport("ScreenController.dll", EntryPoint = "setScreenColor")]
        private static extern bool setScreenColor(int color);
        public static bool setScreenInfoByDll(ScreenBasicInfoModel screenBaiscInfo)
        {
             bool result = false;
            try
            {
                result = setScreenName(screenBaiscInfo.ScreenName);

                if (!result)
                {
                    log.Error("set screen name failed");
                    return result;
                }

                SCREEN_LIGHT_INFO screenLight = new SCREEN_LIGHT_INFO();


                screenLight.lightCtr = screenBaiscInfo.LightCtrl;
                screenLight.lightA = screenBaiscInfo.LightLevelA;
                screenLight.lightB = screenBaiscInfo.LightLevelB;


                result = setScreenLight(ref screenLight);
                if (!result)
                {
                    log.Error("set screen light failed");
                    return result;
                }


                result = setScreenColor(screenBaiscInfo.ScreenColor);
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }



           return result;
        }

        [DllImport("ScreenController.dll", EntryPoint = "getScreenLight")]
        private static extern bool getScreenLight(ref SCREEN_LIGHT_INFO lightInfo);
        [DllImport("ScreenController.dll", EntryPoint = "getScreenColor")]
        private static extern int getScreenColor();
        [DllImport("ScreenController.dll", EntryPoint = "getScreenLength")]
        private static extern int getScreenLength();
        public static ScreenBasicInfoModel getScreenBasicInfoByDll()
        {
            ScreenBasicInfoModel screenBaiscInfo = new ScreenBasicInfoModel();
            bool result = false;
            try
            {
                SCREEN_LIGHT_INFO screenLight = new SCREEN_LIGHT_INFO();
               


                result = getScreenLight(ref screenLight);

                if (!result)
                {
                    log.Error("get screen light failed");
                    return screenBaiscInfo;
                }


                screenBaiscInfo.LightCtrl = screenLight.lightCtr;
                screenBaiscInfo.LightLevelA = screenLight.lightA;
                screenBaiscInfo.LightLevelB = screenLight.lightB;




                int color = getScreenColor();
                if (-1 != color)
                {
                    screenBaiscInfo.ScreenColor = color;
                }
                else
                {
                    log.Error("get color failed");
                    return screenBaiscInfo;
                }

                screenBaiscInfo.ScreenName = getScreenNameByDll();

                screenBaiscInfo.ScreenLength = getScreenLength();
               
                return screenBaiscInfo;
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }

            return screenBaiscInfo;
        }

        [DllImport("ScreenController.dll", EntryPoint = "setScreenLength")]
        private static extern bool setScreenLength(int length);
        public static bool setScreenLengthByDll(int length)
        {
            bool result = false;
            try
            {
               result = setScreenLength(length);
            }
            catch (System.Exception ex)
            {
               log.Error("call dll exception", ex);
            }
            return result;
        }
                
        [DllImport("ScreenController.dll", EntryPoint = "setScreenOff")]
        private static extern bool setScreenOff();
        public static bool setScreenOffByDll()
        {
            bool result = false;
            try
            {
               result = setScreenOff();
            }
            catch (System.Exception ex)
            {
               log.Error("call dll exception", ex);
            }
            return result;
        }

        [DllImport("ScreenController.dll", EntryPoint = "setScreenOn")]
        private static extern bool setScreenOn();
        public static bool setScreenOnByDll()
        {
            bool result = false;
            try
            {
                result = setScreenOn();
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }
            return result;
        }

        [DllImport("ScreenController.dll", EntryPoint = "saveScreen")]
        private static extern bool saveScreen();
        public static bool saveScreenByDll()
        {
            bool result = false;
            try
            {
                result =  saveScreen();
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }
            return result;
        }

        [DllImport("ScreenController.dll", EntryPoint = "initScreen")]
        private static extern bool initScreen();
        public static bool initScreenByDll()
        {
            bool result = false;
            try
            {
                result = initScreen();
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }
            return result; 
        }

        [DllImport("ScreenController.dll", EntryPoint = "closeConnect")]
        private static extern bool closeConnect();
        public static bool closeConnectByDll()
        {
            log.Info("now close the connect");
            bool result = false;
            try
            {
                result = closeConnect();
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }
            return result; 
        }
    }
}
