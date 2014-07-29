using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model;


namespace ScreenManager.Stub
{
    static class Stub
    {
        public static List<ScreenModel> getScreenStub()
        {
            List<ScreenModel> list = new List<ScreenModel>();

            for(int i=0;i<10;i++){
                ScreenModel m = new ScreenModel();
               
                m.ScreenIP = "192.168.1." + i.ToString();
                m.ScreenName = "Screen_" + i.ToString();
                m.ScreenColor = i;
                m.LightLevelA = i;
                m.LightLevelB = i+1;
                for (int j = 0; j < 10; j++)
                {
                    m.roadList[j] = getRoadStub(j.ToString());
                        
                }
                list.Add(m);
            }
            return list;
        }

        public static RoadModel getRoadStub(string id)
        {

            String[] rolorArr = { ScreenManager.Model.Constant.Constants.RED_COLOR, ScreenManager.Model.Constant.Constants.GREEN_COLOR, ScreenManager.Model.Constant.Constants.YELLOW_COLOR };

            RoadModel roadModel = new RoadModel();
            roadModel.BaseColor = ScreenManager.Model.Constant.Constants.DEFAULT_COLOR;
            roadModel.RoadID = System.Convert.ToInt16(id);
            roadModel.RoadName = "RoadStub" + id;
            List<SegmentModel> sl = new List<SegmentModel>();



            int k = 0;

            for(int i=0;i<10;i++){
                SegmentModel sm = new SegmentModel();
                sm.SegmentColor =i%3;
                sm.Address.Start = k;
                sm.Address.End = k+15;
                sm.SegmentID =i;
                sm.SegmentName = id + "-" + i;
                k = k + 15;
                sl.Add(sm);
            }
            
           
            roadModel.SegmentList = sl;
            return roadModel;
        }
    }
}
