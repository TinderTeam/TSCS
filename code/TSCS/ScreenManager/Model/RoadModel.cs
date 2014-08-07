using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model.Constant;
namespace ScreenManager.Model
{
   public  class RoadModel
    {
        private  int baseColor=0;
        private String rodeName;
        private int roadID;
        private int roadLenght = 150;

        private List<SegmentModel> segmentList = new List<SegmentModel>();


       public int getSegmentModelByPositon(int clickValue){
            for(int i=0;i<segmentList.Count;i++){
                if (clickValue < segmentList[i].Address.End && clickValue > segmentList[i].Address.Start)
                {
                    return segmentList[i].SegmentID;
                }
            }
            return -1;
     
       }



        public void deleteByIndex(String index)
        {
            segmentList.RemoveAt(Convert.ToInt16(index));
        }

        public void loadRoadModel(RoadModel rm)
        {
            this.RoadID = rm.RoadID;
            this.BaseColor = rm.BaseColor;
            this.RoadName = rm.RoadName;
            this.RoadLenght = rm.RoadLenght;
            SegmentList.Clear();
            for(int i=0;i< rm.SegmentList.Count;i++){
                SegmentModel segModel = new SegmentModel();
                segModel.SegmentID = rm.SegmentList[i].SegmentID;
                segModel.SegmentColor = rm.SegmentList[i].SegmentColor;
                segModel.Address = rm.SegmentList[i].Address;
                segModel.SegmentName = rm.SegmentList[i].SegmentName;
                SegmentList.Add(segModel);
            }
        }

        public SegmentModel getSegmentModelByID(int  id)
        {
            for (int i = 0; i < this.SegmentList.Count; i++)
            {
                if (this.SegmentList[i].SegmentID == id)
                {
                    return this.SegmentList[i];
                }
            }
            return null;
        }

        public int RoadLenght
        {
            get { return roadLenght; }
            set { roadLenght = value; }
        }

        public List<SegmentModel> SegmentList
        {
            get { return segmentList; }
            set { segmentList = value; }
        }

        public int BaseColor
        {
            get { return baseColor; }
            set { baseColor = value; }
        }

        public int RoadID
        {
            get { return roadID; }
            set { roadID = value; }
        }

        public String RoadName
        {
            get { return rodeName; }
            set { rodeName = value; }
        }




    }
}
