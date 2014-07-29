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
            return connectScreen(ipAddr);
        }

        [DllImport("ScreenController.dll", EntryPoint = "getScreenName")]
        private static extern IntPtr getScreenName();
        public static string getScreenNameByDll()
        {

            IntPtr name =getScreenName();

            string str = Marshal.PtrToStringAnsi(name);

            return str;
        }

 

        [DllImport("ScreenController.dll", EntryPoint = "getRoadInfo")]
        private static extern bool getRoadInfo(IntPtr roadInfo, int length);
        public static List<RoadModel> getRoadInfoByDll()
        {
            int roadNum = 10;

            ROAD_INFO[] infos = new ROAD_INFO[roadNum];
            for (int i = 0; i < roadNum; i++)
            {
                infos[i] = new ROAD_INFO();
            }

            IntPtr[] ptArr = new IntPtr[1];
            ptArr[0] = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ROAD_INFO)) * roadNum); //分配包含两个元素的数组   
            IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ROAD_INFO)));
            Marshal.Copy(ptArr, 0, pt, 1); //拷贝指针数组  


            getRoadInfo(pt, roadNum);

            List<RoadModel> roadList = new List<RoadModel>();
            for (int i = 0; i < roadNum; i++)
            {
                infos[i] = (ROAD_INFO)Marshal.PtrToStructure((IntPtr)(pt.ToInt32() + i * Marshal.SizeOf(typeof(ROAD_INFO))), typeof(ROAD_INFO));
                RoadModel road = new RoadModel();
                road.RoadID = infos[i].roadNum;
                road.RoadName = infos[i].roadName;
                roadList.Add(road);
            }  

           

            return roadList;
        }

        [DllImport("ScreenController.dll", EntryPoint = "setRoadInfo")]
        private static extern bool setRoadInfo(IntPtr roadInfo, int length);
        [DllImport("ScreenController.dll", EntryPoint = "setScreenDisp")]
        private static extern bool setScreenDisp(IntPtr segmentInfo, int length);
        public static bool setRoadInfoByDll(ScreenModel screen)
        {
            bool result = setRoadNameList(screen);


            if (!result)
            {
                log.Error("set road name failed");
            }
            // set segment list
            result = setSegmentList(screen);


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

            bool result = setScreenDisp(segPt, segmentNum);

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


           SCREEN_LIGHT_INFO    screenLight = new SCREEN_LIGHT_INFO();

           
           screenLight.lightCtr = screenBaiscInfo.LightCtrl;
           screenLight.lightA = screenBaiscInfo.LightLevelA;
           screenLight.lightB = screenBaiscInfo.LightLevelB;


           bool result = setScreenLight(ref screenLight);

           result = setScreenName(screenBaiscInfo.ScreenName);

           result = setScreenColor(screenBaiscInfo.ScreenColor);

           return result;
        }

        [DllImport("ScreenController.dll", EntryPoint = "getScreenLight")]
        private static extern bool getScreenLight(ref SCREEN_LIGHT_INFO lightInfo);
        [DllImport("ScreenController.dll", EntryPoint = "getScreenColor")]
        private static extern int getScreenColor();
        public static ScreenBasicInfoModel getScreenBasicInfoByDll()
        {

            SCREEN_LIGHT_INFO screenLight = new SCREEN_LIGHT_INFO();
 

            bool result = getScreenLight(ref screenLight);
 
            ScreenBasicInfoModel screenBaiscInfo = new ScreenBasicInfoModel();
            screenBaiscInfo.LightCtrl = screenLight.lightCtr;
            screenBaiscInfo.LightLevelA = screenLight.lightA;
            screenBaiscInfo.LightLevelB = screenLight.lightB;

            screenBaiscInfo.ScreenName = getScreenNameByDll();
            screenBaiscInfo.ScreenColor = getScreenColor();

            return screenBaiscInfo;
        }
                
        [DllImport("ScreenController.dll", EntryPoint = "setScreenOff")]
        private static extern bool setScreenOff();
        public static bool setScreenOffByDll()
        {
            return setScreenOff();
        }

        [DllImport("ScreenController.dll", EntryPoint = "setScreenOn")]
        private static extern bool setScreenOn();
        public static bool setScreenOnByDll()
        {
            return setScreenOn();
        }

        [DllImport("ScreenController.dll", EntryPoint = "saveScreen")]
        private static extern bool saveScreen();
        public static bool saveScreenByDll()
        {
            return saveScreen();
        }

        [DllImport("ScreenController.dll", EntryPoint = "closeConnect")]
        private static extern bool closeConnect();
        public static bool closeConnectByDll()
        {
            return closeConnect();
        }
    }
}
