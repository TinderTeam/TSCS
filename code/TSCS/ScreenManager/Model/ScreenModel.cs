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

            initRoadList();
           
        }


        public void changeRoad(int segmentIndex, int roadIndex)
        {
            RoadModel roadModel = getRoadModelBySegmentId(segmentIndex);

            SegmentModel sm = new SegmentModel(segmentIndex);
            sm.SegmentName = this.getSegmentList()[segmentIndex].SegmentName;
            sm.SegmentColor = this.getSegmentList()[segmentIndex].SegmentColor;
            sm.Address = new SegmentAddress();
            sm.Address.Start = this.getSegmentList()[segmentIndex].Address.Start;
            sm.Address.End = this.getSegmentList()[segmentIndex].Address.End;
       
            //add
            roadList[roadIndex].SegmentList.Add( sm );
            

            //remove
            roadModel.SegmentList.Remove(roadModel.getSegmentModelByID(segmentIndex));
            this.getSegmentList();
            
        }



        public RoadModel getRoadModelBySegmentId(int id)
        { 
            for (int i = 0; i < roadList.Count; i++)
            {
                for (int j = 0; j < roadList[i].SegmentList.Count; j++)
                {
                    if (roadList[i].SegmentList[j].SegmentID == id) {
                        return roadList[i];
                    }
                }
            }
            return null;
        }
        public void initRoadList()
        {
            roadList.Clear();
            for (int i = 0; i < 10; i++)
            {
                RoadModel rm = new RoadModel();
                rm.RoadID = i;
                rm.BaseColor = Constant.Constants.DEFAULT_COLOR;
                rm.RoadLenght = this.basicInfo.ScreenLength;
                rm.RoadName = "";
                roadList.Add(rm);
            }
        }

        public void createSegment()
        {
            SegmentModel sm = new SegmentModel(getSegmentList().Count-1);
            roadList[roadList.Count - 1].SegmentList.Add(sm);

        }

        public void deleteByIndex(int id)
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                for (int j = 0; j < roadList[i].SegmentList.Count; j++)
                {
                    if (roadList[i].SegmentList[j].SegmentID == id)
                    {
                        roadList[i].SegmentList.RemoveAt(j);


                        break;
                    }                
                }
            }

            getSegmentList();
        }



        public List<SegmentModel> getSegmentList()
        {
            int k=0;
            List<SegmentModel> semgnetList = new List<SegmentModel>();
            for (int i = 0; i < roadList.Count; i++)
            {
                for (int j = 0; j < roadList[i].SegmentList.Count; j++)
                {
                    roadList[i].SegmentList[j].SegmentID = k++;
                    semgnetList.Add(roadList[i].SegmentList[j]);

                }
            }
            return  semgnetList;
        }

        public void setRoadNameWithId(int roadID,String roadName)
        {

            for (int i = 0; i < roadList.Count; i++)
            {
                if (roadList[i].RoadID==roadID)
                {
                    roadList[i].RoadName = roadName;
                }
            }
        }

        public RoadModel getRoadById(int id)
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                if (roadList[i].RoadID==id)
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


        public int ScreenColor
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


        public int ScreenLightCtrl
        {
            get { return this.basicInfo.LightCtrl; }
            set { this.basicInfo.LightCtrl = value; }
        }
    }
}
