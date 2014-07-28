using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenManager.Model
{
    class ScreenBasicInfoModel
    {
        private String screenIP;
        private String macAddr;

        private String screenName = "未命名";
        private int lightLeverA = 0;
        private int lightLeverB = 0;
        private String screenColor = Constant.Constants.DEFAULT_COLOR;
        private int screenLength = 150;
    }
}
