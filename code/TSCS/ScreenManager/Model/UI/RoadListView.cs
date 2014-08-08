using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace ScreenManager.Model.UI
{
   public class RoadListView
    {
        public List<RoadView> list;

        public RoadListView()
        {
            list = new List<RoadView>();
        }

        public RoadListView(List<RoadView> l)
        {
            list = l;
        }

        public int getIndexByTextBox(TextBox t)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].TextRoad.Equals(t))
                {
                    return i;

                }

            }
            return -1;
        }

        public void cleanSelected()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].PanelView.Segment = null;
            }
        }

    }
}
