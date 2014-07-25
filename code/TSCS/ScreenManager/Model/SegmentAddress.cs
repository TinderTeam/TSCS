using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenManager.Model
{
    public class SegmentAddress
    {
        int start=0;
        int end=150;

        public int End
        {
            get { return end; }
            set { end = value; }
        }

        public int Start
        {
            get { return start; }
            set { start = value; }
        }
        
    }
}
