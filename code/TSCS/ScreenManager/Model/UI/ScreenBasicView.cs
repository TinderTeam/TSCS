using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenManager.Model.UI
{
   public  class ScreenBasicRoadView
    {
        private System.Windows.Forms.ComboBox roadColor;

       
       private System.Windows.Forms.NumericUpDown roadLength;
       private System.Windows.Forms.TextBox roadName;


       public System.Windows.Forms.ComboBox RoadColor
       {
           get { return roadColor; }
           set { roadColor = value; }
       }

       public System.Windows.Forms.NumericUpDown RoadLength
       {
           get { return roadLength; }
           set { roadLength = value; }
       }

       public System.Windows.Forms.TextBox RoadName
       {
           get { return roadName; }
           set { roadName = value; }
       }
    }
}
