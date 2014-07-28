using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenManager.Model
{
    public class SegmentModel
    {

        int segmentID;
        int segmentColor = 0;
        String segmentName="未命名";

        SegmentAddress address = new SegmentAddress();


        public SegmentModel(int id)
        {
            this.SegmentID = id;
        }

        public SegmentModel()
        {
            new SegmentModel(0);
        }


        public SegmentAddress Address
        {
            get { return address; }
            set { address = value; }
        }

        public int SegmentColor
        {
            get { return segmentColor; }
            set { segmentColor = value; }
        }
        
        public int SegmentID
        {
            get { return segmentID; }
            set { segmentID = value; }
        }

        public String SegmentName
        {
            get { return segmentName; }
            set { segmentName = value; }
        }
    }
}
