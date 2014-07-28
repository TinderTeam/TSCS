using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace ScreenManager.Model.UI
{
    public class RoadPanel : System.Windows.Forms.Panel
    {
        private RoadModel road = new RoadModel();
        private Boolean sgmtSelected = false;
        private int sgmtSelectedIndex =0;
      

        public RoadPanel(RoadModel r)
        {
            road = r;
            
        
        }

        public RoadPanel(int id)
        {
            road  =new RoadModel();
            road.RoadID = id ;
          
      
        }

        public void repaint()
        {


            //draw background painting
            drawBackground();

            if (sgmtSelected)
            {
                //draw all segment
                drawAllSeg();

                ///draw selected segment
                ///  show baseSegment
                
                //drawSelectedSegment();
                
                //draw cursor
                drawCursor();
            }
            else
            {
                //draw all segment
                drawAllSeg();
            }


        }
        private void drawCursor()
        {
            Graphics g = CreateGraphics();

            int length = this.Width;
            int roadLength = road.RoadLenght;

            SegmentModel segment = road.SegmentList[sgmtSelectedIndex];

            double startMarkP = (double)segment.Address.Start / (double)roadLength;
            int startMark = (int)(startMarkP * (double)length);

            double endMarkP = (double)segment.Address.End / (double)roadLength;
            int endMark = (int)(endMarkP * (double)length);



            //画起始点
            SolidBrush brush = new SolidBrush(Color.Black);
            Rectangle rectangelStart = new Rectangle(startMark, 0, 4, this.Height - 1);  
            g.FillRectangle(brush, rectangelStart);

            //画结束点
            Rectangle rectangelEnd = new Rectangle(endMark - 4, 0, 4, this.Height - 1);
            g.FillRectangle(brush, rectangelEnd);

        }   

        private void drawBackground()
        {
            //draw Background
            Graphics g = CreateGraphics();

            Rectangle r = new Rectangle(0, 0, this.Width , this.Height - 1);
            SolidBrush b = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(road.BaseColor));
            g.FillRectangle(b, r);
        }

        private void drawSelectedSegment()
        {
            drawSegment(road.SegmentList[sgmtSelectedIndex]);
        }

        private void drawAllSeg() {
         

            //画路段图
            for (int i = 0; i < road.SegmentList.Count; i++)
            {
                drawSegment( road.SegmentList[i]);
            }
        }

        public RoadModel Road
        {
            get { return road; }
            set { road = value; }
        }


        private void drawSegment(SegmentModel segment)
        {
            Graphics g = CreateGraphics();

            int length = this.Width;
            int roadLength = road.RoadLenght;
            double startPoint = (double)segment.Address.Start / (double)roadLength;
            double endPoint = (double)segment.Address.End / (double)roadLength;

            int startInt = (int)(startPoint * (double)length);
            int endInt = (int)(endPoint * (double)length);
            Rectangle rectangel = new Rectangle(startInt, 0, endInt - startInt, this.Height - 1);
            SolidBrush brush = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(ScreenManager.Model.Constant.Constants.colorArray[segment.SegmentColor]));
            g.FillRectangle(brush, rectangel);

        }
    }
}
