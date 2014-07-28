using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model;
namespace ScreenManager.Model
{
   public class ScreenModel
    {


        private ScreenBasicInfoModel basicInfo = new ScreenBasicInfoModel();

       
       public List<RoadModel> roadList = new List<RoadModel>();


        public ScreenModel()
        {
            for (int i = 0; i < 10; i++)
            {
                RoadModel rm = new RoadModel();
                rm.RoadID = i.ToString();
                rm.BaseColor = Constant.Constants.DEFAULT_COLOR;
                rm.RoadLenght = this.basicInfo.ScreenLength;
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


        public ScreenBasicInfoModel BasicInfo
        {
            get { return basicInfo; }
            set { basicInfo = value; }
        }

        public int ScreenLong
        {
            get { return this.basicInfo.ScreenLength; }
            set { this.basicInfo.ScreenLength = value; }
        }


        public String ScreenColor
        {
            get { return this.basicInfo.ScreenColor; }
            set { this.basicInfo.ScreenColor = value; }
        }




        public int LightLevelB
        {
            get { return this.basicInfo.LightLevelB; }
            set { this.basicInfo.LightLevelB = value; }
        }


        public int LightLevelA
        {
            get { return this.basicInfo.LightLevelA; }
            set { this.basicInfo.LightLevelA = value; }
        }
       

        public String ScreenIP
        {
            get { return this.basicInfo.ScreenIP; }
            set { this.basicInfo.ScreenIP = value; }
        }
       

       
        public String ScreenName
        {
            get { return this.basicInfo.ScreenName; }
            set { this.basicInfo.ScreenName = value; }
        }


        public int ScreenColorCtrl
        {
            get { return this.basicInfo.ScreenColorCtrl; }
            set { this.basicInfo.ScreenColorCtrl = value; }
        }
    }
}
