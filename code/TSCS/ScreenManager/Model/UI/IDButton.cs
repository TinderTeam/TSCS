using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenManager.Model.UI
{
   public  class IDButton : System.Windows.Forms.Button
    {
        public String id;
        public IDButton(String str)
        {
            id = str;
            new System.Windows.Forms.Button();
        }
    }
}
