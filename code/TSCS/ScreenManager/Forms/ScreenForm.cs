using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenManager.Model;
using ScreenManager.Model.UI;
namespace ScreenManager
{
    public partial class ScreenForm :System.Windows.Forms.Form
    {

        private ScreenModel model;
        private RoadListView roadList;

        public ScreenForm()
        {
            InitializeComponent();
        }

        /*
         * 加载屏幕
         */
        public void loadScreen(ScreenModel screenModel)
        {
            model = screenModel;
            this.Text = model.ScreenName + "-" + model.ScreenIP;
            this.IpTextBox.Text = model.ScreenIP;
            this.lightLeverA.Value = model.LightLeverA;
            this.lightLeverA.Value = model.LightLeverB;

            this.comStreenColor.Text= model.ScreenColor;
            this.textScreenName.Text = model.ScreenName;
            this.roadLong.Value = model.ScreenLong;
            
        }


        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 关闭软屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///Stub
            
            ScreenManager.Form.ScreenEditForm sef = new ScreenManager.Form.ScreenEditForm();
            sef.loadScreen(Stub.Stub.getScreenStub().Last());
            sef.Show();
        }

        private void 搜索屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(this);
            mainForm.Show();
        }

        private void IPEdit_Click(object sender, EventArgs e)
        {

           ScreenModel model = InitModel();
           if(this.IpTextBox.Enabled == true){
            //Cancel
                this.IpTextBox.Enabled = false;
                this.IPEdit.Text="修改";
                this.IPModify.Enabled = false;
                
                this.IpTextBox.Text = model.ScreenIP;
       
              
           }else{
                this.IpTextBox.Enabled = true;
                this.IPEdit.Text = "取消";
                this.IPModify.Enabled = true;
           }
            
        }

        private ScreenModel InitModel()
        {
            if (model == null)
            {
                model = new ScreenModel();
            }
            return model;
        }

        private RoadListView InitRoadList()
        {
            if (this.roadList == null)
            {
                this.roadList = new RoadListView(new List<RoadView>());
            }
            return roadList;
        }

        private void IPModify_Click(object sender, EventArgs e)
        {
            //修改IP
            ScreenModel model = InitModel();
           

    
            if(
                //TODO: 修改操作
                true
                //
                ){
                model.ScreenIP = this.IpTextBox.Text;
                this.IpTextBox.Enabled = false;
                this.IPEdit.Text = "修改";
                this.IPModify.Enabled = false;
            }else{
                ;
            }
            
            
        }

        private void EditInfo_Click(object sender, EventArgs e)
        {
            ScreenModel model = InitModel();
            if (this.InfoModify.Enabled == true)
            {
                //Cancel
                this.InfoModify.Enabled = false;
                this.EditInfo.Text = "修改";

                this.textScreenName.Text = model.ScreenName;
                this.comStreenColor.Text = model.ScreenColor;
                this.lightLeverA.Value = model.LightLeverA;
                this.lightLeverB.Value = model.LightLeverB;
                this.roadLong.Value = model.ScreenLong;

                this.InfoModify.Enabled = false;
                this.textScreenName.Enabled = false;
                this.comStreenColor.Enabled = false;
                this.lightLeverA.Enabled = false;
                this.roadLong.Enabled = false;
                this.lightLeverB.Enabled = false;   

            }
            else
            {
                this.InfoModify.Enabled = true;
                this.textScreenName.Enabled = true;
                this.comStreenColor.Enabled = true;
                this.lightLeverA.Enabled = true;
                this.lightLeverB.Enabled = true;
                this.roadLong.Enabled = true;
                this.EditInfo.Text = "取消";              
            }
        }

        private void InfoModify_Click(object sender, EventArgs e)
        {
            //修改
            ScreenModel model = InitModel();



            if (
                //TODO: 修改操作
                true
                //
                )
            {
                model.ScreenName=this.textScreenName.Text;
                model.ScreenColor = this.comStreenColor.Text;
                model.LightLeverA = System.Convert.ToInt32( this.lightLeverA.Value);
                model.LightLeverB = System.Convert.ToInt32(this.lightLeverB.Value);
                model.ScreenLong = System.Convert.ToInt32(this.roadLong.Value);


                this.InfoModify.Enabled = false;
                this.textScreenName.Enabled = false;
                this.comStreenColor.Enabled = false;
                this.lightLeverA.Enabled = false;
                this.lightLeverB.Enabled = false;
                this.roadLong.Enabled = false;
                this.InfoModify.Enabled = false;
                this.EditInfo.Text = "修改";

            }
            else
            {
                ;
            }
        }



        private void defaltSet_Click_1(object sender, EventArgs e)
        {
            model = new ScreenModel();
            this.textScreenName.Text = model.ScreenName;
            this.comStreenColor.Text = model.ScreenColor;
            this.lightLeverA.Value = model.LightLeverA;
            this.lightLeverB.Value = model.LightLeverB;
            this.roadLong.Value = model.ScreenLong;
        }

        private void roadPanel_Paint(object sender, PaintEventArgs e)
        {
            ScreenModel screenModel = InitModel();
            ScreenManager.Model.UI.RoadPanel panel = (ScreenManager.Model.UI.RoadPanel)sender;
            RoadModel roadModel = screenModel.getRoadById(panel.Road.RoadID.ToString());    
            roadModel.RoadLenght = screenModel.ScreenLong;

            Graphics g = e.Graphics;
            //画背景

            Rectangle r = new Rectangle(0, 0, panel.Width-1, panel.Height-1);
            SolidBrush b = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(roadModel.BaseColor));
            g.FillRectangle(b, r);

            int length = panel.Width ;
            int roadLength = roadModel.RoadLenght;

            //画路段图
            for (int i = 0; i < roadModel.SegmentList.Count; i++)
            {
                SegmentModel segment=roadModel.SegmentList[i];

                double startPoint = (double)segment.Address.Start / (double)roadLength;
                double endPoint = (double)segment.Address.End / (double)roadLength;

                int startInt = (int)(startPoint * (double)length);
                int endInt = (int)(endPoint * (double)length);            
                Rectangle rectangel = new Rectangle(startInt, 0, endInt - startInt, panel.Height - 1);
                SolidBrush brush = new SolidBrush(ScreenManager.Model.Constant.Constants.getColorByName(segment.SegmentColor));
                g.FillRectangle(brush, rectangel);
                
            }


        }
        private void roadEdit(object sender, EventArgs e)
        {
            System.Console.WriteLine("编辑路段");
            IDButton idb = (IDButton)sender;
            RoadModel rm =model.getRoadById(idb.id);
            ScreenManager.Form.EditRoadForm form = new ScreenManager.Form.EditRoadForm(rm,this);
            form.Show();
        }

       


    }
}
