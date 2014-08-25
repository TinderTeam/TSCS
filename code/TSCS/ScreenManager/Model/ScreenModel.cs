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

        private List<RoadModel> roadList = new List<RoadModel>();

      


        public ScreenModel()
        {

            initRoadList();
           
        }



      public void  cleanSegment()
      {
          for (int i = 0; i < RoadList.Count; i++)
          {
              RoadList[i].SegmentList.Clear();
          }
          
       }


        public SegmentModel changeRoad(int segmentIndex, int roadIndex)
        {
            RoadModel roadModel = getRoadModelBySegmentId(segmentIndex);

            SegmentModel sm = new SegmentModel(segmentIndex);
            sm.SegmentName = this.getSegmentList()[segmentIndex].SegmentName;
            sm.SegmentColor = this.getSegmentList()[segmentIndex].SegmentColor;
            sm.Address = new SegmentAddress();


            if (this.getSegmentList()[segmentIndex].Address.Start > roadList[roadIndex].RoadLenght)
            {
                sm.Address.Start = roadList[roadIndex].RoadLenght;
            }
            else if (this.getSegmentList()[segmentIndex].Address.End > roadList[roadIndex].RoadLenght)
            {
                sm.Address.End = roadList[roadIndex].RoadLenght;
            }
            else
            {
                sm.Address.Start = this.getSegmentList()[segmentIndex].Address.Start;
                sm.Address.End = this.getSegmentList()[segmentIndex].Address.End;
            }
           
       
            //add
            roadList[roadIndex].SegmentList.Add( sm );
            

            //remove
            roadModel.SegmentList.Remove(roadModel.getSegmentModelByID(segmentIndex));
            this.getSegmentList();
            return sm;
            
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
                rm.BaseColor = this.ScreenColor;
                rm.RoadLenght = this.basicInfo.ScreenLength;
                rm.RoadName = "";
                roadList.Add(rm);
            }
        }

        public int  createSegment()
        {
            SegmentModel sm = new SegmentModel(getSegmentList().Count-1);

            RoadModel r = getFirstExistRoad();
            if (r != null)
            {
                sm.Address.End = r.RoadLenght;
                r.SegmentList.Add(sm);
            }        

           
            getSegmentList();
            return sm.SegmentID;
            
        }

        public int createSegment(int index)
        {
            SegmentModel selectSgmt=getSegmentList()[index];
            SegmentModel sm = new SegmentModel();
            sm.Address.End = selectSgmt.Address.End;
            sm.Address.Start = selectSgmt.Address.Start;
            sm.SegmentColor = selectSgmt.SegmentColor;
            sm.SegmentName = selectSgmt.SegmentName;
            sm.SegmentID = selectSgmt.SegmentID;
            RoadModel r = getRoadModelBySegmentId(index);
            if (r != null)
            {
                r.SegmentList.Add(sm);
            }
            getSegmentList();
            return sm.SegmentID;

        }

        public RoadModel getFirstExistRoad()
        {
        
            for (int i = 0; i < this.RoadList.Count;i++ )
            {
                if (!this.RoadList[i].RoadName.Equals(""))
                {
                    return RoadList[i];
                }
            }
            return null;
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
            set {
                this.basicInfo.ScreenColor = value; 
                for(int i=0;i<this.roadList.Count;i++){
                    this.RoadList[i].BaseColor = value;
                }              
            }
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


        public string getRoadNameString()
        {
            String str="";
            for (int i = 0; i < this.roadList.Count; i++)
            {
                if (i == 0)
                {
                    str = this.roadList[i].RoadName;
                }
                else
                {
                    str = str + ";" + this.roadList[i].RoadName;
                }
             
            }
            return str;
        }

        public List<RoadModel> RoadList
        {
            get { return roadList; }
            set 
            { 
              
                roadList = value;
                roadLengthCheck();
            }
        }

       private void  roadLengthCheck(){
           for (int i = 0; i < this.RoadList.Count; i++)
           {
               if (RoadList[i].RoadLenght>this.ScreenLong)
               {
                   RoadList[i].RoadLenght = this.ScreenLong;
               }
           }
       }

    }
}
