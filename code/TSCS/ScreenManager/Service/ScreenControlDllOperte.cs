using System;
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

        private const char SCREEN_ROAD_FLAG = ';';
        private const char ROAD_INFO_FLAG = ',';


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

        [DllImport("ScreenController.dll", EntryPoint = "getScreenCS")]
        private static extern IntPtr getScreenCS();
        public static ScreenModel getScreenNameInfoByDll()
        {
            IntPtr cs;
            string str = "";
            bool result = true;

            try
            {
                SCREEN_LIGHT_INFO screenLight = new SCREEN_LIGHT_INFO();
                result = getScreenLight(ref screenLight);
 
                if(!result)
                {
                    log.Error("the screen can not connect success");
                    throw new SystemException("不能连接屏幕");
                }
                cs = getScreenCS();
                str = Marshal.PtrToStringAnsi(cs);
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
                throw new SystemException("不能连接屏幕");
            }

            log.Info("get screen name is " + str);
 

            String[] csInfoArry = str.Split(SCREEN_ROAD_FLAG);

            ScreenModel screen = new ScreenModel();
            if (csInfoArry.Length>1)
            {
                screen.ScreenName = csInfoArry[0];
                for (int i = 0; i < screen.RoadList.Count;i++ )
                {
                    if((i+1) < csInfoArry.Length)
                    {
                      String[] nameAndLength = csInfoArry[i+1].Split(ROAD_INFO_FLAG);

                      screen.RoadList[i].RoadLenght = i;

                      if (nameAndLength.Length > 0)
                      {
                          screen.RoadList[i].RoadName = nameAndLength[0];
                      }
                      if(nameAndLength.Length > 1)
                      {
                          screen.RoadList[i].RoadLenght = Convert.ToInt32(nameAndLength[1]);
                      }
                        
                    }
                }
            }
 
            return screen;
        }

        [DllImport("ScreenController.dll", EntryPoint = "setScreenCS")]
        private static extern bool setScreenCS(string cs);
        public static bool setScreenNameInfoByDll(ScreenModel screen)
        {
            
            String str = "";
            str += screen.ScreenName;
            str += SCREEN_ROAD_FLAG;

            for (int i = 0; i < screen.RoadList.Count; i++)
            {
                str += screen.RoadList[i].RoadName;
                str += ROAD_INFO_FLAG;
                str += screen.RoadList[i].RoadLenght;
                str += SCREEN_ROAD_FLAG;
            }
            bool result  = false ;
            if (str.Length>512)
            {
                throw new SystemException("名称长度太长");
            }
           
            try
            {
                result = setScreenCS(str);

                if (!result)
                {
                    log.Error("set screen cs  failed");
                }

                result = setScreenLength(screen.ScreenLong);
            }
            catch (System.Exception ex)
            {
                log.Error("set screen cs failed");
            }

            

            return result;
        }



        [DllImport("ScreenController.dll", EntryPoint = "getScreenDisp")]
        private static extern bool getScreenDisp(IntPtr roadInfo, int length);
        public static  bool getSegmentInfoByDll(List<RoadModel> roadList)
        {
            int segNum = 150;

            SEGMENT_INFO[] segInfoList = new SEGMENT_INFO[segNum];
            bool result = false;
            try
            {

                for (int i = 0; i < segNum; i++)
                {
                    segInfoList[i] = new SEGMENT_INFO();
                    segInfoList[i].segNum = -1;
                    segInfoList[i].roadNum = -1;
                }

                IntPtr roadPt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SEGMENT_INFO)) * segNum);
                long longSegPt = roadPt.ToInt64();

                for (int i = 0; i < segInfoList.Length; i++)
                {
                    IntPtr RectPtr = new IntPtr(longSegPt);
                    Marshal.StructureToPtr(segInfoList[i], RectPtr, false); // You do not need to erase struct in this case
                    longSegPt += Marshal.SizeOf(typeof(SEGMENT_INFO));
                }

                result = getScreenDisp(roadPt, segNum);

                for (int i = 0; i < segNum; i++)
                {
                    segInfoList[i] = (SEGMENT_INFO)Marshal.PtrToStructure((IntPtr)(roadPt.ToInt32() + i * Marshal.SizeOf(typeof(SEGMENT_INFO))), typeof(SEGMENT_INFO));
                }

                Marshal.FreeHGlobal(roadPt);

            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }

            for (int i = 0; i < roadList.Count; i++)
            {
                roadList[i].SegmentList.Clear();
            }

             
            for (int i = 0; i < segInfoList.Count(); i++)
            {


                    RoadModel roadModel = getRoadByRoadID(segInfoList[i].roadNum, roadList);
  
                    int roadID = segInfoList[i].roadNum;

                    if (segNum != -1)
                    {
                        if (null != roadModel)
                        {
                            SegmentModel segment = new SegmentModel();
                            segment.SegmentID = segInfoList[i].segNum;
                            segment.SegmentColor = segInfoList[i].color;
 
                            if (segInfoList[i].startAddr < 0 || segInfoList[i].startAddr > roadModel.RoadLenght)
                            {
                                segment.Address.Start = 0;
                                log.Warn("the start addr is not in the right range.start address is " + segInfoList[i].startAddr);
                            }
                            else
                            {
                                segment.Address.Start = segInfoList[i].startAddr;
                            }

                            if (segInfoList[i].endAddr < 0 || segInfoList[i].endAddr > roadModel.RoadLenght)
                            {
                                segment.Address.End = roadModel.RoadLenght;
                                log.Warn("the end addr is not in the right range.end address is " + segInfoList[i].endAddr);
                            }
                            else
                            {
                                  segment.Address.End = segInfoList[i].endAddr;
                            }
                            log.Info("the segment information is " + segment.ToString());
                            roadModel.SegmentList.Add(segment);
                        }
                        else
                        {
                            log.Error("the road id is not exist " + segInfoList[i].roadNum);
                        }

                    }

            }
            return result;
        }

        private static RoadModel getRoadByRoadID(int roadID,List<RoadModel> roadList)
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                if (roadID == roadList[i].RoadID)
                {
                    return roadList[i];
                }
            }
            return null;
        }

        [DllImport("ScreenController.dll", EntryPoint = "setSegmentColor")]
        private static extern bool setSegmentColor(int segmentID, int color);
        public static bool setSegmentColorByDll(int segmentID,int color)
        {

            log.Info("set segment color. the segment id is  " + segmentID + ", the color is " + color);
            bool result = false;
            try
            {

                // set segment list
                result = setSegmentColor(  segmentID,   color);

            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }


            return result;
        }
 
        [DllImport("ScreenController.dll", EntryPoint = "setScreenDisp")]
        private static extern bool setScreenDisp(IntPtr segmentInfo, int length,int screenColor);
        public static bool setSegmentByDll(ScreenModel screen)
        {
            log.Info("set road information." + screen);
            bool result = false;
            try
            {
 
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

     
       
        [DllImport("ScreenController.dll", EntryPoint = "setScreenLight")]
        private static extern bool setScreenLight(ref SCREEN_LIGHT_INFO lightInfo);
        [DllImport("ScreenController.dll", EntryPoint = "setScreenName")]
        private static extern bool setScreenName(string name);

        public static bool setScreenLightByDll(ScreenBasicInfoModel screenBaiscInfo)
        {
             bool result = false;
            try
            {
 
                SCREEN_LIGHT_INFO screenLight = new SCREEN_LIGHT_INFO();


                screenLight.lightCtr = screenBaiscInfo.LightCtrl;
                screenLight.lightA = screenBaiscInfo.LightLevelA;
                screenLight.lightB = screenBaiscInfo.LightLevelB;


                result = setScreenLight(ref screenLight);
                
            }
            catch (System.Exception ex)
            {
                log.Error("call dll exception", ex);
            }

           return result;
        }
        [DllImport("ScreenController.dll", EntryPoint = "setScreenColor")]
        private static extern bool setScreenColor(int color);
        public static bool setScreenColorByDll(int color)
        {
            bool result = false;
            try
            {
                result = setScreenColor(color);
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
        [DllImport("ScreenController.dll", EntryPoint = "getScreenOnOff")]
        private static extern int getScreenOnOff();
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

  

                screenBaiscInfo.ScreenLength = getScreenLength();

                screenBaiscInfo.ScreenStatus = getScreenOnOff();
               
 
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
