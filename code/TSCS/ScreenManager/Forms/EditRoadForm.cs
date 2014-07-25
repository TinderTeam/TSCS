using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenManager.Model;
namespace ScreenManager.Form
{
    public partial class EditRoadForm : System.Windows.Forms.Form
    {
        public static   Boolean isSelected=false;
        public static   ListViewItem selectedItem = null;
        public static int startMarkPosition ;
        public static int endMarkPosition;
        public static Boolean mouseDrag = false;
        public static String  markDrag = null;
        public static int screenSegmentNum;



        public RoadModel roadModel;
        public RoadModel editedRoadModel;

        public static ScreenModel screenModel;

        ScreenForm sf;

        public EditRoadForm(RoadModel rm, ScreenForm screenFrom)
        {

            roadModel = rm;
            sf = screenFrom;
            editedRoadModel = new RoadModel();
            editedRoadModel.loadRoadModel(rm);
            InitializeComponent();
           
        }


        private void paintPanel_Paint(object sender, PaintEventArgs e)
        {
            //重画屏幕
         

            Graphics g = e.Graphics;
            //画背景
            System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)sender;
            Rectangle r = new Rectangle(0, 0, panel.Width , panel.Height - 1);
            SolidBrush b = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(editedRoadModel.BaseColor));
            g.FillRectangle(b, r);

            //画底层图层

            int length = panel.Width;
            int roadLength = editedRoadModel.RoadLenght;

          


            
            if (selectedItem == null)
            {
                startMarkPosition = 0;
                endMarkPosition = 0;


                //画路段图
                for (int i = 0; i <editedRoadModel.SegmentList.Count; i++)
                {
                    SegmentModel segment = editedRoadModel.SegmentList[i];

                    double startPoint = (double)segment.Address.Start / (double)roadLength;
                    double endPoint = (double)segment.Address.End / (double)roadLength;

                    int startInt = (int)(startPoint * (double)length);
                    int endInt = (int)(endPoint * (double)length);

                    Rectangle rectangel = new Rectangle(startInt, 0, endInt - startInt, panel.Height - 1);
                    SolidBrush brush = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(segment.SegmentColor));
                    g.FillRectangle(brush, rectangel);

                }
            }
            else
            {

                double startMarkP = (double)this.start.Value / (double)roadLength;
                int startMark = (int)(startMarkP * (double)length);

                double endMarkP = (double)this.end.Value / (double)roadLength;
                int endMark = (int)(endMarkP * (double)length);

                startMarkPosition = startMark;
                endMarkPosition = endMark;


                //画选中图层


                //画调整段落


                Rectangle rectangelSeg = new Rectangle(Math.Min(startMark, endMark), 0, Math.Abs(endMark - startMark), panel.Height - 1);
                SolidBrush segmentBrush = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(selectedItem.SubItems[2].Text));
                g.FillRectangle(segmentBrush, rectangelSeg);

                    //画起始点
              
                Rectangle rectangel = new Rectangle(startMark , 0, 4, panel.Height - 1);
                SolidBrush brush = new SolidBrush(Color.Black);
                g.FillRectangle(brush, rectangel);

                    //画结束点
                Rectangle rectangel2 = new Rectangle(endMark-4, 0, 4, panel.Height - 1);
                g.FillRectangle(brush, rectangel2);

            }
          
        }

    
        private void colorBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isSelected == false)
            {
                //因列表选中时触发的事件

            }
            else
            {
                if (selectedItem == null)
                {

                }
                else {
                    selectedItem.SubItems[2].Text = this.colorBox.Text;
                    if (editedRoadModel.getSegmentModelByIndex(selectedItem.Text) != null)
                    {
                        editedRoadModel.getSegmentModelByIndex(selectedItem.Text).SegmentColor = this.colorBox.Text;
                    }
                    else
                    {

                    };
                    this.paintPanel_Paint(this.paintPanel, new PaintEventArgs(this.paintPanel.CreateGraphics(), new Rectangle()));
                }
                
            }
          
        }

        private void segmentListView_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;

            if (isSelected == false)
            {
                //选中
                    this.colorBox.Enabled = true;
                    selectedItem = lv.SelectedItems[0];
                    this.colorBox.Text = selectedItem.SubItems[2].Text;
                    this.segNameText.Enabled = true;
                    this.segNameText.Text = selectedItem.SubItems[1].Text;
                    lv.SelectedItems[0].BackColor = Color.CadetBlue;
                    lv.SelectedItems[0].ForeColor = Color.White;               
                    this.start.Enabled = true;
                    this.end.Enabled = true;
                    this.deleteSeg.Enabled = true;
                    this.start.Value = Convert.ToInt16( selectedItem.SubItems[3].Text);
                    this.end.Value = Convert.ToInt16(selectedItem.SubItems[4].Text);
                    this.paintPanel_Paint(this.paintPanel, new PaintEventArgs(this.paintPanel.CreateGraphics(),new Rectangle()));
                    isSelected = true;
           
            }
            else
            {
             

                if (lv.SelectedItems[0].Equals(selectedItem))
                {
                    //取消
                    selectedItem.BackColor = Color.White;
                    selectedItem.ForeColor = Color.Black;    
                    selectedItem = null;
                    this.colorBox.Enabled = false;
                    isSelected = false;
                    this.segNameText.Text = "未选择路段";
                   
                    this.segNameText.Enabled = false;
                    lv.SelectedItems.Clear();
                    this.end.Enabled = false;
                    this.start.Enabled = false;
                    this.deleteSeg.Enabled = false;
                    this.colorBox.Text = "";
                    this.paintPanel_Paint(this.paintPanel, new PaintEventArgs(this.paintPanel.CreateGraphics(), new Rectangle()));
                }
                else {

                    //存在选中
                    isSelected = false;
                    selectedItem.BackColor = Color.White;
                    selectedItem.ForeColor = Color.Black;
                    this.colorBox.Enabled = true;
                    selectedItem = lv.SelectedItems[0];
                    this.colorBox.Text = selectedItem.SubItems[2].Text;
                    this.segNameText.Text = selectedItem.SubItems[1].Text;
                    lv.SelectedItems[0].BackColor = Color.CadetBlue;
                    lv.SelectedItems[0].ForeColor = Color.White;
             
                    this.start.Enabled = true;
                    this.end.Enabled = true;
                    this.start.Value = Convert.ToInt16(selectedItem.SubItems[3].Text);
                    this.end.Value = Convert.ToInt16(selectedItem.SubItems[4].Text);
                    this.paintPanel_Paint(this.paintPanel, new PaintEventArgs(this.paintPanel.CreateGraphics(), new Rectangle()));
                    isSelected = true;
                }
        
            }
            
        }

        private void paintPanel_MouseMove_1(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)sender;
            if (isSelected == true)
            {
                if (mouseDrag == true)
                {
                    int offset;
                    int length = panel.Width;
                    int roadLength = editedRoadModel.RoadLenght;
                    double offsetP;
                    int roadOffset;
                    if(markDrag.Equals("start")){
                        //startMove;
                        offset = e.X - startMarkPosition;
                        offsetP = (double)offset / (double)length;
                        roadOffset = (int)(offsetP * (double)roadLength);

                        //设置起始值拖拽结果
                        if (this.start.Value + roadOffset < 0)
                        {
                            //最小
                            this.start.Value = 0;
                        }
                        else if (this.start.Value + roadOffset > roadLength)
                        {
                            this.start.Value = roadLength;
                        }
                        else
                        {
                            this.start.Value = this.start.Value + roadOffset;
                        }

                        //写入拖拽结果
                        if (editedRoadModel.getSegmentModelByIndex(selectedItem.Text) != null)
                        {
                            editedRoadModel.getSegmentModelByIndex(selectedItem.Text).Address.Start = Convert.ToInt16(this.start.Value);
                        }
                        else
                        {
                            //Err;
                        };

                    }
                    else if(markDrag.Equals("end")){
                        //endMove;

                        offset = e.X - endMarkPosition;
                        offsetP = (double)offset / (double)length;
                        roadOffset = (int)(offsetP * (double)roadLength);
                        if (this.end.Value + roadOffset < 0)
                        {
                            //最小
                            this.end.Value = 0;
                        }
                        else if (this.end.Value + roadOffset > roadLength)
                        {
                            this.end.Value = roadLength;
                        }
                        else
                        {
                            this.end.Value = this.end.Value + roadOffset;
                        }

                        //写入拖拽结果
                        if (editedRoadModel.getSegmentModelByIndex(selectedItem.Text) != null)
                        {
                            editedRoadModel.getSegmentModelByIndex(selectedItem.Text).Address.End =  Convert.ToInt16(this.end.Value);
                        }
                        else
                        {
                            //Err;
                        };

                        
                    }
                    this.paintPanel_Paint(this.paintPanel, new PaintEventArgs(this.paintPanel.CreateGraphics(), new Rectangle()));
                }
                else
                {


                    if (e.Location.X >= startMarkPosition && e.Location.X <= (startMarkPosition+4))
                    {
                        this.paintPanel.Cursor = Cursors.Hand;
                    }
                    else if (e.Location.X >= endMarkPosition-4 && e.Location.X <= endMarkPosition)
                    {
                        this.paintPanel.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        this.paintPanel.Cursor = Cursors.Arrow;
                    }
                }
                
            }
            else
            {
                
            }
                
                

        }

        private void paintPanel_MouseDown_1(object sender, MouseEventArgs e)
        {
            //鼠标按下事件
            if (isSelected == true)
            {
                if (e.Location.X >= startMarkPosition && e.Location.X <= (startMarkPosition + 4))
                    {
                        mouseDrag = true;
                        markDrag = "start";
                        this.paintPanel.Cursor = Cursors.SizeWE;
                    }
                    else if (e.Location.X >= endMarkPosition-4 && e.Location.X <= (endMarkPosition))
                    {
                        mouseDrag = true;
                        markDrag = "end";
                        this.paintPanel.Cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        ;
                    }
            }
            else
            {
                ;
            }
        }

        private void paintPanel_MouseUp_1(object sender, MouseEventArgs e)
        {
            //鼠标抬起
            if (isSelected == true)
            {
               mouseDrag = false;
               markDrag = null ;
               this.paintPanel.Cursor = Cursors.Arrow;
               selectedItem.SubItems[3].Text=this.start.Value.ToString();
               selectedItem.SubItems[4].Text=this.end.Value.ToString();
            }
            else
            {
                ;
            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            if (isSelected == true)
            {

                //写入拖拽结果
                if (editedRoadModel.getSegmentModelByIndex(selectedItem.Text) != null)
                {
                    editedRoadModel.getSegmentModelByIndex(selectedItem.Text).Address.Start = Convert.ToInt16(this.start.Value);
                    editedRoadModel.getSegmentModelByIndex(selectedItem.Text).Address.End = Convert.ToInt16(this.end.Value);
                }
                else
                {
                    //Err;
                };

                this.paintPanel_Paint(this.paintPanel, new PaintEventArgs(this.paintPanel.CreateGraphics(), new Rectangle()));
                selectedItem.SubItems[3].Text = this.start.Value.ToString();
                selectedItem.SubItems[4].Text = this.end.Value.ToString();
            }
            else
            {
                ;
            }
               
        }

        private void addSeg_Click(object sender, EventArgs e)
        {
          //  SegmentModel 
          SegmentModel sg = new SegmentModel((editedRoadModel.SegmentList.Count+1).ToString());
          editedRoadModel.SegmentList.Add(sg);
          this.paintPanel_Paint(this.paintPanel, new PaintEventArgs(this.paintPanel.CreateGraphics(), new Rectangle()));
          this.loadSegmentListView();
        }

        private void deleteSeg_Click(object sender, EventArgs e)
        {
            if (isSelected == true)
            {
                if (editedRoadModel.getSegmentModelByIndex(selectedItem.Text) != null)
                {
                    editedRoadModel.deleteByIndex(selectedItem.Text);

                    cancelSelected();

                    this.paintPanel_Paint(this.paintPanel, new PaintEventArgs(this.paintPanel.CreateGraphics(), new Rectangle()));
                    this.loadSegmentListView();                          
                }
                else
                {
                    //Err;
                };
            }


        }

        private void submitSeg_Click(object sender, EventArgs e)
        {
            roadModel.loadRoadModel(editedRoadModel);
            sf.loadTable();
            cancelSelected();
            this.Close();
        }

        private void cancelSeg_Click(object sender, EventArgs e)
        {

            cancelSelected();
            this.Close();
        }

        

        private void segNameText_TextChanged(object sender, EventArgs e)
        {
            if (isSelected == true)
            {
                
                isSelected = false;
                    selectedItem.SubItems[1].Text = this.segNameText.Text;
                    
               


                if (editedRoadModel.getSegmentModelByIndex(selectedItem.Text) != null)
                {
                    editedRoadModel.getSegmentModelByIndex(selectedItem.Text).SegmentName = this.segNameText.Text;
                }
                else
                {
                    //Err;
                };
                isSelected = true;
            }
            else
            {
                ;
            }
        }




        public void cancelSelected()
        {   
            selectedItem = null;
            this.colorBox.Enabled = false;
            isSelected = false;
            this.segNameText.Text = "未选择路段";

            this.segNameText.Enabled = false;
            this.end.Enabled = false;
            this.start.Enabled = false;
            this.deleteSeg.Enabled = false;
            this.colorBox.Text = "";
            this.paintPanel_Paint(this.paintPanel, new PaintEventArgs(this.paintPanel.CreateGraphics(), new Rectangle()));
        }



    
    }
}
