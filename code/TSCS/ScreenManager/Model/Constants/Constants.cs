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

       
        public static String AUTO ="自动";
        public static String MANUL  ="手动";

        public static String[] lightCtrlArray = { AUTO, MANUL };


        public static String DEFAULT_COLOR ="无色";
        public static String RED_COLOR ="红色";
        public static String GREEN_COLOR ="绿色";
        public static String YELLOW_COLOR = "黄色";
        public static String ALL_COLOR = "全亮";
        public static String RESERVED_5 = "保留";
        public static String RESERVED_6 = "保留";
        public static String RESERVED_7 = "保留";
        public static String RESERVED_8 = "保留";
        public static String RESERVED_9 = "保留";
        public static String RESERVED_10 = "保留";
        public static String RESERVED_11 = "保留";
        public static String RESERVED_12 = "保留";
        public static String RESERVED_13 = "保留";
        public static String RESERVED_14 = "保留";
        public static String RESERVED_15 = "保留";

        public static int getIndexByStr(string str)
        {
            for (int i = 0; i < colorArray.Length; i++) { 
                if(str.Equals(colorArray[i])){
                return i;
                }

            }
            return -1;
        }



        public static String[] colorArray = { 
                                                DEFAULT_COLOR,
                                                RED_COLOR,
                                                YELLOW_COLOR, 
                                                GREEN_COLOR,
                                                ALL_COLOR,
                                                RESERVED_5,
                                                RESERVED_6,
                                                RESERVED_7,
                                                RESERVED_8,
                                                RESERVED_9,
                                                RESERVED_10,
                                                RESERVED_11,
                                                RESERVED_12,
                                                RESERVED_13,
                                                RESERVED_14,
                                                RESERVED_15
                                            };

       


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
