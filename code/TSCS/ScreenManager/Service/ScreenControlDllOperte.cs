﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using ScreenManager.Model;

namespace ScreenManager.Service
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SCREEN_INFO
    {
        public int roadNum;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string roadName;
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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string roadName;
    } 

    public class ScreenControlDllOperate
    {
  

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
 
            IntPtr intPtr = getScreenName();

            string str = Marshal.PtrToStringAnsi(intPtr);
 
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
                road.RoadID = infos[i].roadNum.ToString();
                road.RoadID = infos[i].roadName;
                roadList.Add(road);
            }  

           

            return roadList;
        }

        [DllImport("ScreenController.dll", EntryPoint = "setRoadInfo")]
        private static extern bool setRoadInfo(IntPtr roadInfo, int length);
        public static bool setRoadInfoByDll(List<RoadModel> roadList)
        {
            int roadNum = roadList.Count;

            ROAD_INFO[] infos = new ROAD_INFO[roadNum];
            for (int i = 0; i < roadNum; i++)
            {
                infos[i] = new ROAD_INFO();
            }

            IntPtr[] ptArr = new IntPtr[1];
            ptArr[0] = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ROAD_INFO)) * roadNum); //分配包含两个元素的数组   
            IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ROAD_INFO)));
            Marshal.Copy(ptArr, 0, pt, 1); //拷贝指针数组  


            bool result = getRoadInfo(pt, roadNum);


            return result;
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
    }
}
