using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model;
namespace ScreenManager.Service
{
    public interface ScreenControlInterface
    {
        /// <summary>
        /// get connected screen by ip segments;
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
       ScreenListModel searchByIP(string start, string end);

        /// <summary
        /// modify screen ip address
        /// </summary>
        /// <param name="oldIpAddr"></param>
        /// <param name="newIPAddr"></param>
        /// <returns></returns>
       Boolean modifyScreenIP(string oldIPAddr, string newIPAddr);

        /// <summary>
        /// set screen infomation
        /// 
        /// </summary>
        /// <param name="screenModel"></param>
        /// <returns></returns>
       Boolean setScreenBasicInfo(ScreenBasicInfoModel basicInfo);


       /// <summary>
       /// set screen segment list;
       /// 
       /// </summary>
       /// <param name="screenModel"></param>
       /// <returns></returns>
       Boolean setScreenRoadInfo(ScreenModel screenModel);

        /// <summary>
        /// 
        /// close Screen
        /// </summary>
        /// <returns></returns>
       Boolean closeScreen();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       Boolean saveScreen();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       Boolean openScreen();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
       Boolean setScreenLength(int length);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
       ScreenModel getScreenInfo(String ip);


    }
}
