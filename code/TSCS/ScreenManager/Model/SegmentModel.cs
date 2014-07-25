using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenManager.Model
{
    public class SegmentModel
    {

        public SegmentModel(String id)
        {
            this.SegmentID = id;
        }

        public SegmentModel()
        {
            new SegmentModel("");
        }

        String segmentID;
        String segmentColor = Constant.Constants.DEFAULT_COLOR;
        String segmentName="未命名";
        SegmentAddress address = new SegmentAddress();


        public SegmentAddress Address
        {
            get { return address; }
            set { address = value; }
        }

        public String SegmentColor
        {
            get { return segmentColor; }
            set { segmentColor = value; }
        }
        
        public String SegmentID
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
