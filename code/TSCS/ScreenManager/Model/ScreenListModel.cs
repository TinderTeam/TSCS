using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenManager.Model
{
    public class ScreenListModel
    {


        private List<ScreenModel> list = new List<ScreenModel>();


 

       public ScreenModel getModelByIndex(String id)
       {
      
           return List[Convert.ToInt16(id)];
       }

       public List<ScreenModel> List
       {
           get { return list; }
           set { list = value; }
       }

    }
    
}
