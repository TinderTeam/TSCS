using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenManager.Model.UI
{
   public class RoadListView
    {
        public List<RoadView> list;
        public RoadListView(List<RoadView> l)
        {
            list = l;
        }
    }
}
