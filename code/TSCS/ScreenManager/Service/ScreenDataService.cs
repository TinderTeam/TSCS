using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model;
namespace ScreenManager.Service
{
    public class ScreenDataService
    {


        public ScreenListModel searchByIP(string start,string end)
        {

            //TODO:
            /* 通过IP段查询屏幕列表
             * 
             */
            ScreenListModel slm = new ScreenListModel();
            slm.List = Stub.Stub.getScreenStub();
            return slm;
        }

        
    }
}
