using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace ScreenManager.Model.UI
{
   public  class RoadView
    {
       private Label lblIndex = new Label();
       private TextBox textRoad = new System.Windows.Forms.TextBox();
       private RoadPanel panelView = new RoadPanel(0);
       
       
       ///
       public IDButton btn = new IDButton("");
       public System.Windows.Forms.Label name = new System.Windows.Forms.Label();
       ///
       
       
       public RoadView()
       {
           new RoadView(0);
       }
      
     public RoadView(int i){
                
           lblIndex.Name = "lblRoadIndex_" + i;

           // 
           // textRoad
           // 
        
           textRoad.Name = "textRoad" + i;     

           // 
           // panelView
           //         
           panelView.Name = "panelView" + i;         
       }

     





       public Label LblIndex
       {
           get { return lblIndex; }
           set { lblIndex = value; }
       }

       public TextBox TextRoad
       {
           get { return textRoad; }
           set { textRoad = value; }
       }
       public RoadPanel PanelView
       {
           get { return panelView; }
           set { panelView = value; }
       }

    
    }
}
