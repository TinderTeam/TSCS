using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model;

namespace ScreenManager.Dao
{
    public class RoadDaoModel
    {
        private String screenName;   
        private int screenLength;
        private List<RoadModel> roadList;

        public int ScreenLength
        {
            get { return screenLength; }
            set { screenLength = value; }
        }

        public String ScreenName
        {
            get { return screenName; }
            set { screenName = value; }
        }

        public List<RoadModel> RoadList
        {
            get { return roadList; }
            set { roadList = value; }
        }


        public void load(ScreenModel screenModel)
        {
            this.ScreenLength = screenModel.ScreenLong;
            this.ScreenName = screenModel.ScreenName;
            this.RoadList = screenModel.RoadList;
        }


        public void read(ScreenModel screenModel)
        {

            for (int i = 0; i < screenModel.RoadList.Count; i++)
            {
                RoadModel rm =getRoadModelById(screenModel.RoadList[i].RoadID);
                if(rm!=null)
                {
                    screenModel.RoadList[i].SegmentList = rm.SegmentList;
                }              
            }

        }

        private RoadModel getRoadModelById(int id)
        {
            for (int i = 0; i < this.RoadList.Count; i++)
            {
                if (this.RoadList[i].RoadID == id)
                {
                    return this.RoadList[i];
                }
            }
            return null;

        }
    }
}
