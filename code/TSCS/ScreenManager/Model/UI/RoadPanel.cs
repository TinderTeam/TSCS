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

        private RoadModel road ;
        private SegmentModel segment = null;    
        private Boolean dragSelected = false;
        private string  markDrag;
        private int startMarkPosition = 0;
        private int endMarkPosition = 0;
        public  int screenLength = 150;

          




        public int EndMarkPosition
        {
            get { return endMarkPosition; }
            set { endMarkPosition = value; }
        }


        public SegmentModel Segment
        {
            get { return segment; }
            set {
                segment = value; 
                
            }
        }      
        

        public RoadPanel(RoadModel r,int l)
        {
            road = r;
         
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            this.SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲 
            screenLength = l;
        }



        public int StartMarkPosition
        {
            get { return startMarkPosition; }
            set { startMarkPosition = value; }
        }
        public string MarkDrag
        {
            get { return markDrag; }
            set { markDrag = value; }
        }

        public RoadPanel(int id)
        {
            road  =new RoadModel();
            road.RoadID = id ;
          
      
        }

        public Boolean DragSelected
        {
            get { return dragSelected; }
            set { dragSelected = value; }
        }


        public void repaint()
        {

            Bitmap bufferimage = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(bufferimage);

            g.Clear(this.BackColor);
            //draw background painting

            drawBackground(g);
           
           

            if (segment!=null)
            {
                //draw all segment
                drawAllSeg(g);

                ///draw selected segment
                ///  show baseSegment
                //drawChangedSegment();

                drawSelectedSegment(g);
                
                //draw cursor
                drawCursor(g);
            }
            else
            {
                //draw all segment
                drawAllSeg(g);
            }

            using (Graphics tg = CreateGraphics())
            {
                tg.DrawImage(bufferimage, 0, 0);　　//把画布贴到画面上
            }

        }




        private void drawChangedSegment(Graphics gr)
        {
            //画路段图
            for (int i = 0; i < road.SegmentList.Count; i++)
            {
                if (isOverlap(road.SegmentList[i]))
                {
                    ;
                }
                else
                {
                    drawSegment(road.SegmentList[i], gr);
                }
                
            }

        }
        

        /// <summary>
        /// 检查路段是否被完整覆盖
        /// 
        /// </summary>
        /// <param name="sm"></param>
        /// <returns></returns>
        private bool isOverlap(SegmentModel sm)
        {
            if (sm.Address.Start >= segment.Address.Start && sm.Address.End < segment.Address.End)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        private void drawCursor(Graphics gr)
        {




        
            int length = this.Width;
            int roadLength = this.screenLength;
            double startMarkP = (double)segment.Address.Start / (double)roadLength;
            int startMark = (int)(startMarkP * (double)length);

            double endMarkP = (double)segment.Address.End / (double)roadLength;
            int endMark = (int)(endMarkP * (double)length);

      
            startMarkPosition = startMark;
            endMarkPosition = endMark;




            drawTriangle(gr, startMark);
            drawTriangle(gr, endMark);

        }


        public void drawTriangle(Graphics gr,int mark)
        {

            SolidBrush brush = new SolidBrush(Color.Black);
            Pen p = new Pen(brush, 1);

            Point a = new Point(mark, this.Height / 2);
            Point b = new Point(mark - 4, this.Height);
            Point c = new Point(mark + 4, this.Height);
            Point[] pointArray = { a, b, c };


            gr.DrawPolygon(p, pointArray);
            gr.FillPolygon(brush, pointArray);
        }



        private void drawBackground(Graphics gr)
        {

            int length = this.Width;
            int roadLength = road.RoadLenght;
            double backGroundLength = (double)roadLength / (double)this.screenLength;



            int bLength = (int)(backGroundLength * (double)length);

            //draw Background
            Graphics g = gr;
            Rectangle r = new Rectangle(0, 0, bLength, bLength);
            SolidBrush b = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(ScreenManager.Model.Constant.Constants.colorArray[road.BaseColor]));
            g.FillRectangle(b, r);
        }

        private void drawSelectedSegment(Graphics gr)
        {
            Graphics g = gr;

            int length = this.Width;
            int roadLength = road.RoadLenght;
            double startPoint = (double)segment.Address.Start / (double)this.screenLength;
            double endPoint = (double)segment.Address.End / (double)this.screenLength;

            int startInt = (int)(startPoint * (double)length);
            int endInt = (int)(endPoint * (double)length);

            SolidBrush brush = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(ScreenManager.Model.Constant.Constants.colorArray[segment.SegmentColor]));

            Rectangle rectangel = new Rectangle(startInt, 0, endInt - startInt, this.Height-1 );
            SolidBrush brush1 = new SolidBrush(Color.Gray);
            Pen p = new Pen(brush1,1);
            g.FillRectangle(brush, rectangel);
            g.DrawRectangle(p, rectangel);
            //写数字

            Font ff = new Font("微软雅黑", 8, FontStyle.Regular);
            SolidBrush b = new SolidBrush(Color.Black);

            String start = segment.Address.Start.ToString();
            String end = segment.Address.End.ToString();

            SizeF sizeF = g.MeasureString(end, ff);
         

            g.DrawString(start, ff, b, new PointF(startInt, 0));
            g.DrawString(end, ff, b, new PointF(endInt - sizeF.Width, 0));

        }

        private void drawAllSeg(Graphics gr)
        {      
            //画路段图
            for (int i = 0; i < road.SegmentList.Count; i++)
            {
                drawSegment( road.SegmentList[i],gr);
            }
        }

        public RoadModel Road
        {
            get { return road; }
            set { road = value; }
        }


        private void drawSegment(SegmentModel segment, Graphics gr)
        {
            Graphics g = gr;

            int length = this.Width;
            int roadLength = road.RoadLenght;
            double startPoint = (double)segment.Address.Start / (double)this.screenLength;
            double endPoint = (double)segment.Address.End / (double)this.screenLength;
            int startInt = (int)(startPoint * (double)length);
            int endInt = (int)(endPoint * (double)length);
            Rectangle rectangel = new Rectangle(startInt, 0, endInt - startInt, this.Height );
            SolidBrush brush = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(ScreenManager.Model.Constant.Constants.colorArray[segment.SegmentColor]));
            g.FillRectangle(brush, rectangel);

            //写数字
           
            Font ff = new Font("微软雅黑",8, FontStyle.Regular);
            SolidBrush b =new SolidBrush( Color.Black);
         
         
            String start = segment.Address.Start.ToString();
            String end = segment.Address.End.ToString();
            SizeF sizeF = g.MeasureString(end, ff);
            g.DrawString(start, ff, b, new PointF(startInt , 0));
            g.DrawString(end, ff, b, new PointF(endInt - sizeF.Width, 0));
        }
    }

}
