using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenManager.Model
{
    public class ScreenBasicInfoModel
    {
        private String screenIP;
        private String screenName = "未命名";

        private String macAddr;

        private int lightCtrl = 0;
        private int lightLeverA = 0;
        private int lightLeverB = 0;
        private int screenColor = 0;
        private int screenStatus = 0;
 

        private int screenLength = 150;

        public int ScreenStatus
        {
            get { return screenStatus; }
            set { screenStatus = value; }
        }


        public int LightCtrl
        {
            get { return lightCtrl; }
            set { lightCtrl = value; }
        }


        public int ScreenLength
        {
            get { return screenLength; }
            set { screenLength = value; }
        }


        public int ScreenColor
        {
            get { return screenColor; }
            set { screenColor = value; }
        }


        public int LightLevelB
        {
            get { return lightLeverB; }
            set { lightLeverB = value; }
        }


        public int LightLevelA
        {
            get { return lightLeverA; }
            set { lightLeverA = value; }
        }

        public String ScreenName
        {
            get { return screenName; }
            set { screenName = value; }
        }


        public String MacAddr
        {
            get { return macAddr; }
            set { macAddr = value; }
        }

        public String ScreenIP
        {
            get { return screenIP; }
            set { screenIP = value; }
        }

    }
}
