using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace ScreenManager.Model.UI
{
    public class RoadPanel : System.Windows.Forms.Panel
    {
        public String roadID;
       public  RoadPanel(String str)
        {
            roadID = str;
            new Panel();
        }
    }
}
