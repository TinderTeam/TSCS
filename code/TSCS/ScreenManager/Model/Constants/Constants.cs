using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ScreenManager.Model;
using ScreenManager.Model.UI;
namespace ScreenManager.Model.Constant
{
    public static class Constants
    {
        public static String DEFAULT_COLOR ="无";
        public static String RED_COLOR ="红色";
        public static String GREEN_COLOR ="绿色";
        public static String YELLOW_COLOR = "黄色";
        public static String ALL_COLOR = "全亮";

        public static String[] colorArray ={RED_COLOR,YELLOW_COLOR,GREEN_COLOR,DEFAULT_COLOR,ALL_COLOR};

     


        public static  Color getColorByName(String str)
        {
            if (str.Equals(DEFAULT_COLOR))
            {
                return Color.WhiteSmoke;
            }else if (str.Equals(RED_COLOR))
            {
                 return Color.Red;
            }else if (str.Equals(GREEN_COLOR))
            {
                 return Color.Green;
            }
            else if (str.Equals(YELLOW_COLOR))
            {
                return Color.Yellow;
            }
            else if (str.Equals(ALL_COLOR)) 
            {
                return Color.LightBlue ;
            }
            else
            {
                return Color.Black;
            }
          
        }
    }

    
}
