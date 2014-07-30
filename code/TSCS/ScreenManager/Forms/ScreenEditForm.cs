using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ScreenManager.Model;
using ScreenManager.Model.UI;
using ScreenManager.Service;

namespace ScreenManager.Form
{
    public partial class ScreenEditForm : System.Windows.Forms.Form
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 

        private ScreenModel screenModel;
        private RoadListView roadListView;
        private ListViewItem selcetedItem;



        public ScreenEditForm()
        {         
            InitializeComponent();         
            initComponentsContent();
            loadScreen(new ScreenModel());
        }

        /// <summary>
        /// Init the component content
        /// init combobox items;
        /// init the viewList
        /// </summary>
        public void initComponentsContent()
        {

            this.cmbLightCtrl.Items.Clear();
            this.cmbScrnClr.Items.AddRange(Model.Constant.Constants.colorArray);
            this.cmbLightCtrl.Items.AddRange(Model.Constant.Constants.lightCtrlArray);
            this.cmbRdClr.Items.AddRange(Model.Constant.Constants.colorArray);


            List<String> roadNameList = new List<String>();
            List<RoadView> viewList = new List<RoadView>();


            //init ViewList
            this.paintPanel.Controls.Clear();
            for (int i = 0; i < 10; i++)
            {
                RoadView rv = new RoadView(i);

                Label lblIndex = new Label();
                lblIndex.Anchor = System.Windows.Forms.AnchorStyles.None;
                lblIndex.Location = new System.Drawing.Point(41, 23);
                lblIndex.Name = "lblRoadIndex_"+i;
                lblIndex.Text = i.ToString();
                lblIndex.Size = new System.Drawing.Size(56, 21);
                lblIndex.TabIndex = 0;


                // 
                // textRoad
                // 
                TextBox textRoad = new System.Windows.Forms.TextBox();
                textRoad.Anchor = System.Windows.Forms.AnchorStyles.None;
                textRoad.Location = new System.Drawing.Point(41, 23);
                textRoad.Name = "textRoad" + i;
                textRoad.Size = new System.Drawing.Size(56, 21);
                textRoad.Text = "textRoad" + i;
                textRoad.TabIndex = 0;
                textRoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                textRoad.TextChanged += new System.EventHandler(this.roadNameChanged);

                roadNameList.Add(textRoad.Text);
                // 
                // panelView
                // 
                RoadPanel panelView = new RoadPanel(i);
                panelView.Dock = System.Windows.Forms.DockStyle.Fill;
                panelView.Location = new System.Drawing.Point(105, 25);
                panelView.Margin = new System.Windows.Forms.Padding(5, 25, 5, 25);
                panelView.Name = "panelView"+i;
                panelView.Size = new System.Drawing.Size(427, 17);
                panelView.TabIndex = 2;
                //panelView.Paint += new System.Windows.Forms.PaintEventHandler(this.roadPanel_Paint);
                panelView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
                panelView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
                panelView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
                rv.LblIndex = lblIndex;
                rv.PanelView = panelView;
                rv.TextRoad = textRoad;


                viewList.Add(rv);

                this.paintPanel.Controls.Add(lblIndex, 0, i);
                this.paintPanel.Controls.Add(textRoad, 1, i);
                this.paintPanel.Controls.Add(panelView, 2, i);
            }

            roadListView = new RoadListView(viewList);
            this.cmbRoad.Items.AddRange(roadNameList.ToArray());

           
        }


        public void loadScreen(ScreenModel m)
        {
            screenModel = m;
            cancelSelectedItem(null);
            this.SelcetedItem = null;
            refrashScrn();
        }


        /*
         Screen refrash function
         */
        public void refrashScrn() {
            refrashScrnInfo();
            refrashView();
            refrashSgmtList();
            refrashSgmtInfo();
        }
        public void refrashSelectedItem(){

            if (this.SelcetedItem!= null)
            {
                this.lstVwSgmt.Items[this.SelcetedItem.Index].SubItems[4].Text = ScreenManager.Model.Constant.Constants.colorArray[this.ScreenModel.getSegmentList()[this.SelcetedItem.Index].SegmentColor];
                this.lstVwSgmt.Items[this.SelcetedItem.Index].SubItems[3].Text = this.ScreenModel.getSegmentList()[this.SelcetedItem.Index].Address.End.ToString();
                this.lstVwSgmt.Items[this.SelcetedItem.Index].SubItems[2].Text = this.ScreenModel.getSegmentList()[this.SelcetedItem.Index].Address.Start.ToString();
                this.lstVwSgmt.Items[this.SelcetedItem.Index].SubItems[1].Text = this.ScreenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadName;
                this.lstVwSgmt.Items[this.SelcetedItem.Index].SubItems[0].Text = this.SelcetedItem.Index.ToString();
                if (this.screenModel.getRoadModelBySegmentId(this.SelcetedItem.Index) != null)
                {
                    this.roadListView.list[this.screenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadID].PanelView.repaint();
                }
            }
            else
            {
            }
      
            
        }
        public void refrashScrnInfo() {
            this.txtIPAdrs.Text = screenModel.ScreenIP;
            this.txtScrnName.Text = screenModel.ScreenName;
            this.cmbScrnClr.Text = ScreenManager.Model.Constant.Constants.colorArray[screenModel.ScreenColor];
            this.txtNumA.Value = screenModel.LightLevelA;
            this.txtNumB.Value = screenModel.LightLevelB;
            this.cmbLightCtrl.Text = ScreenManager.Model.Constant.Constants.lightCtrlArray[screenModel.ScreenLightCtrl];
        }
        public void refrashView()
        {
            for (int i = 0; i < roadListView.list.Count; i++)
            {
                roadListView.list[i].LblIndex.Text = i.ToString();
                roadListView.list[i].TextRoad.Text = screenModel.roadList[i].RoadName;
                roadListView.list[i].PanelView.Road = screenModel.roadList[i];
                roadListView.list[i].PanelView.repaint();
            }
        }
        public void refrashSgmtList() {

            int selectedID=-1;
            if (this.selcetedItem != null) {
                selectedID=this.selcetedItem.Index;
            }
            

            this.lstVwSgmt.Items.Clear();
            for (int i = 0; i < screenModel.getSegmentList().Count; i++)
            {
              
                    String[] itemString = new String[5];
                    itemString[0]= screenModel.getSegmentList()[i].SegmentID.ToString();
                    itemString[1] = screenModel.getRoadModelBySegmentId(screenModel.getSegmentList()[i].SegmentID).RoadName;
                    itemString[2] = screenModel.getSegmentList()[i].Address.Start.ToString();
                    itemString[3] = screenModel.getSegmentList()[i].Address.End.ToString();
                    itemString[4]= ScreenManager.Model.Constant.Constants.colorArray[screenModel.getSegmentList()[i].SegmentColor];

                    System.Windows.Forms.ListViewItem item= new System.Windows.Forms.ListViewItem(itemString);

                    this.lstVwSgmt.Items.Add(item);
           
            }


            if (selectedID !=-1)
            {
                selectItem(this.lstVwSgmt.Items[selectedID]);
            }
          
        }
        public void refrashSgmtInfo(){

           loadSelectedSegmentInfo(this.SelcetedItem);
        }


       
        /*
         Button Action
         */
        private void btnScrnEdit_Click(object sender, EventArgs e)
        {
            if (this.btnScrnEdit.Text.Equals("修改"))
            {
                scrnInfoActivation(true);
                this.btnScrnEdit.Text= "取消";
                this.btnScrnSet.Enabled = true;
            }
            else {

                txtNumA.Value= this.ScreenModel.LightLevelA;
                txtNumB.Value = this.ScreenModel.LightLevelB;
                cmbScrnClr.Text = ScreenManager.Model.Constant.Constants.colorArray[this.ScreenModel.ScreenColor];
               txtScrnName.Text= this.screenModel.ScreenName ;
               cmbLightCtrl.Text = ScreenManager.Model.Constant.Constants.lightCtrlArray[this.screenModel.ScreenLightCtrl];   

                scrnInfoActivation(false);
                this.btnScrnEdit.Text = "修改";
                this.btnScrnSet.Enabled = false;
            }
           

        }
        private void btnScrnSet_Click(object sender, EventArgs e)
        {
            log.Info("Set screen model. ");

            this.ScreenModel.LightLevelA = System.Convert.ToInt16(txtNumA.Value);
            this.ScreenModel.LightLevelB = System.Convert.ToInt16(txtNumB.Value);
            this.ScreenModel.ScreenColor = ScreenManager.Model.Constant.Constants.getIndexByStr(cmbScrnClr.Text);
            this.screenModel.ScreenName = txtScrnName.Text;
            this.screenModel.ScreenLightCtrl = cmbScrnClr.SelectedIndex;

          

            ScreenManager.Service.ScreenControlInterface service = new ScreenManager.Service.ScreenControlImpl();
            bool result= service.setScreenInfo(this.screenModel.BasicInfo);
            if (!result)
            {
                //dailog
                //log
            }
            else
            {
                //dailog
                //log
                scrnInfoActivation(false);
                this.btnScrnEdit.Text = "修改";
                this.btnScrnSet.Enabled = false;
            }
           
        }
        private void btnAddSgmt_Click(object sender, EventArgs e)
        {
            this.ScreenModel.createSegment();

            refrashSgmtList();
            refrashView();
            refrashSgmtInfo();
        }
        private void btnDltSgmt_Click(object sender, EventArgs e)
        {

            if (this.selcetedItem != null)
            {

                this.ScreenModel.deleteByIndex(this.selcetedItem.Index);
                cancelSelectedItem(this.selcetedItem);
                refrashSgmtList();
                refrashView();
                refrashSgmtInfo();

            }
            else
            {
                ;
            }

        }
        private void btnDefault_Click(object sender, EventArgs e)
        {
            this.SelcetedItem = null;
            this.ScreenModel.initRoadList();
            this.refrashSgmtInfo();
            this.refrashSgmtList();
            this.refrashView();

        }
        private void btnSet_Click(object sender, EventArgs e)
        {
            ScreenManager.Service.ScreenControlInterface service = new ScreenManager.Service.ScreenControlImpl();
            service.setScreenSegment(this.ScreenModel);

        }

        /*
         Component Change Action
         */
        /// <summary>
        /// edit road name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roadNameChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            int index = roadListView.getIndexByTextBox(txt);
            screenModel.roadList[index].RoadName = txt.Text;
            refrashSgmtList();
            refrashSgmtInfo();
        }
        private void cmbRoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selcetedItem != null)
            {
                ComboBox cmb = (ComboBox)sender;

                if (this.ScreenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadID != cmb.SelectedIndex)
                {
                    this.roadListView.list[this.ScreenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadID].PanelView.Segment = null;
                    SegmentModel sgmtModel=this.ScreenModel.changeRoad(this.SelcetedItem.Index, cmb.SelectedIndex);                
                    this.roadListView.list[this.ScreenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadID].PanelView.Segment = this.ScreenModel.getSegmentList()[this.SelcetedItem.Index];
                    this.cmbRoad.Text = this.ScreenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadID + ":" + this.ScreenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadName;


                    cancelSelectedItem(this.selcetedItem);
                    this.lstVwSgmt.SelectedItems.Clear();
                    selectItem( this.lstVwSgmt.Items[sgmtModel.SegmentID]);

                    refrashSgmtList();
                 
                    refrashView();
                }
               
            }
            else
            {

            }
        }
        private void numStart_ValueChanged(object sender, EventArgs e)
        {
            if (this.selcetedItem != null)
            {
                System.Windows.Forms.NumericUpDown num = (System.Windows.Forms.NumericUpDown)sender;
                this.ScreenModel.getSegmentList()[selcetedItem.Index].Address.Start = System.Convert.ToInt16(num.Value);       
                refrashSelectedItem();
            }
            else
            { 

            }
        }
        private void numEnd_ValueChanged(object sender, EventArgs e)
        {
            if (this.selcetedItem != null)
            {
                System.Windows.Forms.NumericUpDown num = (System.Windows.Forms.NumericUpDown)sender;
                this.ScreenModel.getSegmentList()[selcetedItem.Index].Address.End = System.Convert.ToInt16(num.Value);            
                refrashSelectedItem();
            }
            else
            {

            }
        }
        private void cmbRdClr_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox combBox = (ComboBox)sender;

            if (this.selcetedItem != null)
            {

                this.ScreenModel.getSegmentList()[selcetedItem.Index].SegmentColor = combBox.SelectedIndex;
         
                refrashSgmtList();
                refrashView();
                refrashSgmtInfo();

            }
            else
            {
                ;
            }
        }
        private void lstVwSgmt_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
           
            if (lv.SelectedItems.Count>0) {
                ListViewItem item = lv.SelectedItems[lv.SelectedItems.Count - 1];
                if (this.selcetedItem == null)
                {
                    selectItem(item);
                    this.refrashSgmtInfo();
                    this.refrashSelectedItem();
                  
                }
                else if (this.selcetedItem.Equals(lv.SelectedItems[lv.SelectedItems.Count-1]))
                {
                    // cancel
                    cancelSelectedItem(item);
                    this.refrashSelectedItem();
                    lv.SelectedItems.Clear();
                    this.SelcetedItem = null;
                    
                }
                else 
                {
                    // selected Other
                    cancelSelectedItem(this.selcetedItem);
                    lv.SelectedItems.Clear();
                    selectItem(item);
                    this.refrashSelectedItem();
                    this.refrashView();
                }
                /*
                this.refrashSgmtInfo();
                this.refrashSgmtList();
                this.refrashView();
                */
            }

        }
        private void numStart_KeyUp(object sender, KeyEventArgs e)
        {
            numStart_ValueChanged(sender, e);
        }
        private void numEnd_KeyUp(object sender, KeyEventArgs e)
        {
            numEnd_ValueChanged(sender, e);
        }

        /*
         MenuItem
         */
        /// <summary>
        /// search screen by ip segment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchScrnMntm_Click(object sender, EventArgs e)
        {
            ScreenSearchForm screenSearchForm = new ScreenSearchForm(this);
            screenSearchForm.Show();
        }
        private void newMntm_Click(object sender, EventArgs e)
        {

            this.loadScreen(new ScreenModel());
        }
        private void exitMntm_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void openScrnMntm_Click(object sender, EventArgs e)
        {

            bool result = ServiceContext.getInstance().getScreenControl().openScreen();
            if (!result)
            {
                MessageBox.Show("打开屏幕失败");
                //log
            }
            else
            {
                MessageBox.Show("打开屏幕成功");
                //log
            }
        }
        private void initScrnMntm_Click(object sender, EventArgs e)
        {
            bool result = ServiceContext.getInstance().getScreenControl().initScreen();
            if (!result)
            {
                MessageBox.Show("初始化屏幕失败");
                //log
            }
            else
            {
                MessageBox.Show("初始化屏幕成功");
                //log
            }
        }
        private void saveScrnMntm_Click(object sender, EventArgs e)
        {
            bool result = ServiceContext.getInstance().getScreenControl().saveScreen();


            if (!result)
            {
                MessageBox.Show("保存屏幕失败");
                //log
            }
            else
            {
                MessageBox.Show("保存屏幕成功");
                //log
            }
        }
        private void closeScrnMntm_Click(object sender, EventArgs e)
        {
            bool result = ServiceContext.getInstance().getScreenControl().closeScreen();
            if (!result)
            {
                //dailog

                MessageBox.Show("关闭屏幕失败");
            }
            else
            {
                MessageBox.Show("关闭屏幕成功");
                //log
            }
        }
        private void EditIPMntm_Click(object sender, EventArgs e)
        {

            ScreenManager.Forms.PasswordForm pf = new ScreenManager.Forms.PasswordForm();
            ScreenManager.Forms.ipMacForm ipMacForm = new ScreenManager.Forms.ipMacForm(this.screenModel.ScreenIP);

            if (pf.ShowDialog() == DialogResult.OK)
            {
                ipMacForm.ShowDialog();
            }
            else
            {
                ;
            }

        }
        private void scrnLengthMntm_Click(object sender, EventArgs e)
        {
            ScreenManager.Forms.PasswordForm pf = new ScreenManager.Forms.PasswordForm();
            ScreenManager.Forms.ScreenLengthForm sf = new ScreenManager.Forms.ScreenLengthForm(this.ScreenModel.ScreenIP);

            if (pf.ShowDialog() == DialogResult.OK)
            {
                sf.ShowDialog();
            }
            else
            {
                ;
            }
        }
        private void openMntm_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "C://";

            fileDialog.Filter = "TrafficScreen files(*.ts)|All files (*.*)";

            fileDialog.FilterIndex = 1;

            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)

            {

               System.Console.WriteLine(fileDialog.FileName);

            }

        }
        private void saveMntm_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "C://";

            fileDialog.Filter = "TrafficScreen files(*.ts)|All files (*.*)";

            fileDialog.FilterIndex = 1;

            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                XmlSerializer serializer = new XmlSerializer(typeof(int));          
                Stream writer = new FileStream(fileDialog.FileName, FileMode.Create);
                // Serialize the object, and close the TextWriter
                serializer.Serialize(writer, this.ScreenModel);
                writer.Close();

                System.Console.WriteLine();

            }
        }


       
        /*
         MouseAcrtion
         */
        private void mouseDown(object sender, MouseEventArgs e)
        {
            ScreenManager.Model.UI.RoadPanel panel = (ScreenManager.Model.UI.RoadPanel)sender;
            //判断是否是响应的组件
            //鼠标按下事件
            if (this.SelcetedItem != null)
            {
                if (e.Location.X >= panel.StartMarkPosition && e.Location.X <= (panel.StartMarkPosition + 4))
                {
                    panel.DragSelected = true;
                    panel.MarkDrag = "start";
                    panel.Cursor = Cursors.SizeWE;
                }
                else if (e.Location.X >= panel.EndMarkPosition - 4 && e.Location.X <= (panel.EndMarkPosition))
                {
                    panel.DragSelected = true;
                    panel.MarkDrag = "end";
                    panel.Cursor = Cursors.SizeWE;
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
        private void mouseUp(object sender, MouseEventArgs e)
        {

            ScreenManager.Model.UI.RoadPanel panel = (ScreenManager.Model.UI.RoadPanel)sender;
           
            //鼠标抬起
            if (panel.Segment != null)
            {
                panel.DragSelected= false;
                panel.MarkDrag= null;
                panel.Cursor = Cursors.Arrow;
        
            }
            else
            {
                ;
            }
        }
        private void mouseMove(object sender, MouseEventArgs e)
        {
            ScreenManager.Model.UI.RoadPanel panel = (ScreenManager.Model.UI.RoadPanel)sender;
            //判断是否是响应的组件

            if (this.SelcetedItem != null)
            {
                if (panel.Equals(this.roadListView.list[this.screenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadID].PanelView))
                {


                    //System.Console.WriteLine("鼠标事件触发; 1.拖拽状态: " + panel.DragSelected + "游标状态:" + panel.MarkDrag);

                    if (panel.DragSelected == true)
                    {
                        if (panel.MarkDrag.Equals("start"))
                        {
                            startMarkMove(e, panel);
                        }
                        else if (panel.MarkDrag.Equals("end"))
                        {
                            endMarkMove(e, panel);
                        };


                    }
                    else
                    {
                        System.Console.WriteLine("游标位置：" + panel.StartMarkPosition + "," + panel.EndMarkPosition + "鼠标位置" + e.Location.X);
                        //undrag
                        if (e.Location.X >= panel.StartMarkPosition && e.Location.X <= (panel.StartMarkPosition + 4))
                        {


                            if (panel.Cursor != Cursors.Hand)
                            {
                          
                                panel.Cursor = Cursors.Hand;

                            }
                        }
                        else if (e.Location.X >= panel.EndMarkPosition - 4 && e.Location.X <= panel.EndMarkPosition)
                        {

                            if (panel.Cursor != Cursors.Hand)
                            {
                               
                                panel.Cursor = Cursors.Hand;

                            }
                        }
                        else
                        {


                            if (panel.Cursor != Cursors.Arrow)
                            {
                              
                                this.paintPanel.Cursor = Cursors.Arrow;

                            }
                        }

                    }



                }
                else
                {
                    //unselected
                }
            }
            else
            {
                if (panel.Cursor != Cursors.Arrow)
                {
                    
                    this.paintPanel.Cursor = Cursors.Arrow;

                }
            }


                   
        }

      
        /*
         Operate Function 
         */
        private void selectItem(ListViewItem item)
        {
            item.BackColor = Color.Blue;
            item.ForeColor = Color.White;
            sgmtInfoActivation(true);
            loadSelectedSegmentInfo(item);

            RoadModel road = this.ScreenModel.getRoadModelBySegmentId(item.Index);
            if (road == null)
            {

            }
            else
            {
                this.roadListView.list[this.ScreenModel.getRoadModelBySegmentId(item.Index).RoadID].PanelView.Segment = this.ScreenModel.getSegmentList()[item.Index];

            }


            this.SelcetedItem = item;

        }
        private void cancelSelectedItem(ListViewItem item)
        {
            if (item != null)
            {
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
            }
          
            sgmtInfoActivation(false);
            this.roadListView.cleanSelected();
            loadSelectedSegmentInfo(null);
        }
        private void loadSelectedSegmentInfo(ListViewItem item)
        {

            ListViewItem l = this.SelcetedItem;
            this.SelcetedItem = null;

            //initRoadCmb();


            if (item == null)
            {

                this.txtSgmtName.Text = "";
                this.cmbRoad.Text = "";
                this.numStart.Value = 0;
                this.numEnd.Value = 0;
                this.cmbRdClr.Text = "";
            }
            else
            {



                this.txtSgmtName.Text = item.SubItems[0].Text;
                this.cmbRoad.Text = item.SubItems[1].Text;
                this.numStart.Value = System.Convert.ToInt16(item.SubItems[2].Text);
                this.numEnd.Value = System.Convert.ToInt16(item.SubItems[3].Text);
                this.cmbRdClr.Text = item.SubItems[4].Text;
            }
            this.SelcetedItem = l;

        }
        private void endMarkMove(MouseEventArgs e, ScreenManager.Model.UI.RoadPanel panel)
        {
            int offset;
            int length = panel.Width;
            int roadLength = panel.Road.RoadLenght;
            double offsetP;
            SegmentAddress adrs = this.screenModel.getSegmentList()[this.SelcetedItem.Index].Address;
            int roadOffset;
            //endMove;

            offset = e.X - panel.EndMarkPosition;

            offsetP = (double)offset / (double)length;

            roadOffset = (int)(offsetP * (double)roadLength);

            if (adrs.End + roadOffset < adrs.Start)
            {
                adrs.Start = adrs.End;
                panel.MarkDrag = "start";
            }
            else if (adrs.End + roadOffset > roadLength)
            {
                adrs.End = roadLength;
            }
            else
            {
                adrs.End = adrs.End + roadOffset;
            }

            panel.Refresh();
            this.refrashSelectedItem();
            this.refrashSgmtInfo();

        }
        private void startMarkMove(MouseEventArgs e, ScreenManager.Model.UI.RoadPanel panel)
        {

            int offset;
            int length = panel.Width;
            int roadLength = panel.Road.RoadLenght;
            double offsetP;
            SegmentAddress adrs = this.screenModel.getSegmentList()[this.SelcetedItem.Index].Address;
            int roadOffset;
            //startMove;
            offset = e.X - panel.StartMarkPosition;
            offsetP = (double)offset / (double)length;
            roadOffset = (int)(offsetP * (double)roadLength);

            //设置起始值拖拽结果


            if (adrs.Start + roadOffset < 0)
            {
                //最小

                adrs.Start = 0;
            }
            else if (adrs.Start + roadOffset > adrs.End)
            {
                adrs.End = adrs.Start;
                panel.MarkDrag = "end";
            }
            else
            {
                adrs.Start = adrs.Start + roadOffset;
            }

            panel.Refresh();
            this.refrashSelectedItem();
            this.refrashSgmtInfo();


        }
        private void initRoadCmb()
        {

            List<String> roadNameList = new List<String>();

            this.cmbRoad.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                roadNameList.Add(i.ToString() + ":" + ScreenModel.roadList[i].RoadName);
            }
            this.cmbRoad.Items.AddRange(roadNameList.ToArray());

        }
        private void scrnInfoActivation(Boolean b)
        {
            txtNumA.Enabled = b;
            txtNumB.Enabled = b;
            cmbScrnClr.Enabled = b;
            txtScrnName.Enabled = b;
            cmbScrnClr.Enabled = b;
            cmbLightCtrl.Enabled = b;
        }
        private void sgmtInfoActivation(Boolean b)
        {
            cmbRoad.Enabled = b;
            numStart.Enabled = b;
            numEnd.Enabled = b;
            cmbRdClr.Enabled = b;
            btnDltSgmt.Enabled = b;


        }

        /*
         Get and set 
         */
        public ScreenModel ScreenModel
        {
            get { return screenModel; }
            set { screenModel = value; }
        }
        public ListViewItem SelcetedItem
        {
            get { return selcetedItem; }
            set { selcetedItem = value; }
        }






    }
}
