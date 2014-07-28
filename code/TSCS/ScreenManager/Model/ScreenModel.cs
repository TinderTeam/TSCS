using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model;
namespace ScreenManager.Model
{
   public class ScreenModel
    {
        private String screenIP;

        private String screenName="未命名";
        private int lightLeverA=0;
        private int lightLeverB=0;
        private String screenColor = Constant.Constants.DEFAULT_COLOR;
        private int screenLong = 150;

        public List<RoadModel> roadList = new List<RoadModel>();


        public ScreenModel()
        {
            for (int i = 0; i < 10; i++)
            {
                RoadModel rm = new RoadModel();
                rm.RoadID = i.ToString();
                rm.BaseColor = Constant.Constants.DEFAULT_COLOR;
                rm.RoadLenght = screenLong;
                rm.RoadName = "";
                roadList.Add(rm);
            }
           
        }

        public void setRoadNameWithId(String roadID,String roadName)
        {

            for (int i = 0; i < roadList.Count; i++)
            {
                if (roadList[i].RoadID.Equals(roadID))
                {
                    roadList[i].RoadName = roadName;
                }
            }
        }

        public RoadModel getRoadById(String id)
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                if (roadList[i].RoadID.Equals(id))
                {
                    return roadList[i];
                }
            }
            return null;
        }




        public int ScreenLong
        {
            get { return screenLong; }
            set { screenLong = value; }
        }


        public String ScreenColor
        {
            get { return screenColor; }
            set { screenColor = value; }
        }




        public int LightLeverB
        {
            get { return lightLeverB; }
            set { lightLeverB = value; }
        }


        public int LightLeverA
        {
            get { return lightLeverA; }
            set { lightLeverA = value; }
        }
       

        public String ScreenIP
        {
            get { return screenIP; }
            set { screenIP = value; }
        }
       

       
        public String ScreenName
        {
            get { return screenName; }
            set { screenName = value; }
        }

       
    }
}
