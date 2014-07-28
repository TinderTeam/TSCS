using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model.Constant;
namespace ScreenManager.Model
{
   public  class RoadModel
    {
        String baseColor=Constants.DEFAULT_COLOR;
        String rodeName;
        int roadID;
        int roadLenght=150;

        List<SegmentModel> segmentList = new List<SegmentModel>();

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

        internal List<SegmentModel> SegmentList
        {
            get { return segmentList; }
            set { segmentList = value; }
        }

        public String BaseColor
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
