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
using ScreenManager.Dao;
using ScreenManager.Util;
using ScreenManager.Forms;
using ScreenManager.Forms.basicConfig;
namespace ScreenManager.Forms
{
    public partial class ScreenEditForm : System.Windows.Forms.Form
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 

        private ScreenModel screenModel;
        private RoadListView roadListView= new RoadListView();
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

            this.cmbRdClr.Items.AddRange(Model.Constant.Constants.colorArray);
            this.cmbRdClr2.Items.AddRange(Model.Constant.Constants.colorArray);
            this.refreshRoadInfo();
        }


        public void refreshRoadInfo()
        {


            List<String> roadNameList = new List<String>();
            List<RoadView> viewList = new List<RoadView>();


            if (this.ScreenModel != null)
            {

                //init ViewList
                this.paintPanel.Controls.Clear();
                for (int i = 0; i < this.ScreenModel.RoadList.Count; i++)
                {
                    RoadView rv = new RoadView(i);
                    Label lblIndex = new Label();
                    TextBox textRoad = new System.Windows.Forms.TextBox();
                    RoadPanel panelView = new RoadPanel(i);

                    panelView.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);

                    if(!this.ScreenModel.RoadList[i].RoadName.Equals("")){
                    
                    lblIndex.Anchor = System.Windows.Forms.AnchorStyles.None;
                    lblIndex.Location = new System.Drawing.Point(41, 23);
                    lblIndex.Text = "";
                    lblIndex.Size = new System.Drawing.Size(56, 21);
                    lblIndex.TabIndex = 0;


                    // 
                    // textRoad
                    // 

                    textRoad.Anchor = System.Windows.Forms.AnchorStyles.None;
                    textRoad.Location = new System.Drawing.Point(41, 23);
                    textRoad.Name = this.screenModel.RoadList[i].RoadName;
                    textRoad.Size = new System.Drawing.Size(56, 21);
                    textRoad.Text = this.screenModel.RoadList[i].RoadName;
                    textRoad.TabIndex = 0;
                    textRoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                    //   textRoad.TextChanged += new System.EventHandler(this.roadNameChanged);

                    roadNameList.Add(textRoad.Text);
                    // 
                    // panelView
                    // 

                    panelView.Dock = System.Windows.Forms.DockStyle.Fill;
                    panelView.Location = new System.Drawing.Point(105, 25);
                    panelView.Margin = new System.Windows.Forms.Padding(5, 25, 5, 25);
                    panelView.Name = "panelView" + i;
                    panelView.Size = new System.Drawing.Size(427, 17);
                    panelView.TabIndex = 2;
                    panelView.screenLength = this.screenModel.ScreenLong;
                    //panelView.Paint += new System.Windows.Forms.PaintEventHandler(this.roadPanel_Paint);
                    panelView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
                    panelView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
                    panelView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
                    panelView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClick);
                    rv.LblIndex = lblIndex;
                    rv.PanelView = panelView;
                    rv.TextRoad = textRoad;

                    this.paintPanel.Controls.Add(lblIndex, 0, i);
                    this.paintPanel.Controls.Add(textRoad, 1, i);
                    this.paintPanel.Controls.Add(panelView, 2, i);
                    }
                    viewList.Add(rv);
                }

                roadListView = new RoadListView(viewList);
                this.cmbRoad.Items.Clear();
                this.cmbRoad.Items.AddRange(roadNameList.ToArray());
 
            }


            }
           

        public void refreshRoadNameList()
        {
            this.cmbRoad.Items.Clear();
            List<String> roadNameList = new List<String>();
            for (int i = 0; i < this.ScreenModel.RoadList.Count; i++)
            {

                if (!this.ScreenModel.RoadList[i].RoadName.Equals(""))
                {
                     roadNameList.Add(this.ScreenModel.RoadList[i].RoadName);
                }

                
            }
            this.cmbRoad.Items.AddRange(roadNameList.ToArray());
        }



        public void loadScreen(ScreenModel m)
        {
            screenModel = m;
           
            cancelSelectedItem(null);
            this.SelcetedItem = null;

            this.refreshRoadInfo();
          
            refreshScrn();
          
            refreshStatusBar();
         
        }
        public void refreshStatusBar()
        {
            lblStatusScreenName.Text = screenModel.ScreenName;
            lblScreenViewName.Text = screenModel.ScreenName;
            lblStatusScreenIP.Text = screenModel.ScreenIP;
           
            lblStatusScreenOpen.Text = ScreenManager.Model.Constant.Constants.getStatusStr(screenModel.BasicInfo.ScreenStatus);
        }


        /*
         Screen refrash function
         */
        public void refreshScrn() {
         
            refreshView();
            refreshSgmtList();
            refreshSgmtInfo();
            refreshStatusBar();

        }
        public void refreshSelectedItem(){

            if (this.SelcetedItem!= null)
            {
                this.lstVwSgmt.Items[this.SelcetedItem.Index].SubItems[4].Text = ScreenManager.Model.Constant.Constants.colorArray[this.ScreenModel.getSegmentList()[this.SelcetedItem.Index].SegmentColor];
                this.lstVwSgmt.Items[this.SelcetedItem.Index].SubItems[3].Text = this.ScreenModel.getSegmentList()[this.SelcetedItem.Index].Address.End.ToString();
                this.lstVwSgmt.Items[this.SelcetedItem.Index].SubItems[2].Text = this.ScreenModel.getSegmentList()[this.SelcetedItem.Index].Address.Start.ToString();
                this.lstVwSgmt.Items[this.SelcetedItem.Index].SubItems[1].Text = this.ScreenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadID+":"+this.ScreenModel.getRoadModelBySegmentId(this.SelcetedItem.Index).RoadName;
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
 
        public void refreshView()
        {
            for (int i = 0; i < roadListView.list.Count; i++)
            {
               
                    roadListView.list[i].LblIndex.Text = screenModel.RoadList[i].RoadName;
                    //roadListView.list[i].TextRoad.Text = screenModel.RoadList[i].RoadName;
                    roadListView.list[i].PanelView.Road = screenModel.RoadList[i];
                    roadListView.list[i].PanelView.repaint();
               
             
            }
        }
        public void refreshSgmtList() {

            int selectedID=-1;
            if (this.selcetedItem != null)
            {
                selectedID=this.selcetedItem.Index;
                this.SelcetedItem = null;
            }
            

            this.lstVwSgmt.Items.Clear();
            for (int i = 0; i < screenModel.getSegmentList().Count; i++)
            {
              
                    String[] itemString = new String[5];
                    itemString[0]= screenModel.getSegmentList()[i].SegmentID.ToString();
                    itemString[1] = screenModel.getRoadModelBySegmentId(screenModel.getSegmentList()[i].SegmentID).RoadID+":"+screenModel.getRoadModelBySegmentId(screenModel.getSegmentList()[i].SegmentID).RoadName;
                    itemString[2] = screenModel.getSegmentList()[i].Address.Start.ToString();
                    itemString[3] = screenModel.getSegmentList()[i].Address.End.ToString();
                    itemString[4]= ScreenManager.Model.Constant.Constants.colorArray[screenModel.getSegmentList()[i].SegmentColor];

                    System.Windows.Forms.ListViewItem item= new System.Windows.Forms.ListViewItem(itemString);

                    this.lstVwSgmt.Items.Add(item);
           
            }


            if (selectedID >= this.lstVwSgmt.Items.Count)
            {
                selectedID = this.lstVwSgmt.Items.Count - 1;
            }    

            if (selectedID >= 0)
                {
                    selectItem(this.lstVwSgmt.Items[selectedID]);
                }
        
            }
   
        public void refreshSgmtInfo(){


           loadSelectedSegmentInfo(this.SelcetedItem);
           if (null==this.ScreenModel.getFirstExistRoad())
           {
               this.btnAddSgmt.Enabled = false;
           }
           else
           {
               this.btnAddSgmt.Enabled = true;
           }
        }



      
        private void btnAddSgmt_Click(object sender, EventArgs e)
        {
            int index =this.ScreenModel.createSegment();
           
            refreshSgmtList();
            refreshView();
            refreshSgmtInfo();


         
            // selected Other

            cancelSelectedItem(this.selcetedItem);
            this.lstVwSgmt.SelectedItems.Clear();
            selectItem(this.lstVwSgmt.Items[index]);
            this.refreshSelectedItem();
            this.refreshView();

         
          
        }
        private void btnDltSgmt_Click(object sender, EventArgs e)
        {

            if (this.selcetedItem != null)
            {

                this.ScreenModel.deleteByIndex(this.selcetedItem.Index);
                cancelSelectedItem(this.selcetedItem);
                refreshSgmtList();
                refreshView();
                refreshSgmtInfo();

            }
            else
            {
                ;
            }

        }
 
        private void btnSet_Click(object sender, EventArgs e)
        {
            this.btnSet.Enabled = false;
            this.cancelSelectedItem(this.SelcetedItem);

            bool result = ScreenManager.Service.ServiceContext.getInstance().getScreenControl().setScreenSegmentInfo(this.ScreenModel);
            if (!result)
            {
                MessageBox.Show("操作失败");
                //log
            }
            else
            {
                //dailog
                //log
                MessageBox.Show("操作成功");
            }
            this.btnSet.Enabled = true;
        }
        /*
         Component Change Action
       废弃
        /// <summary>
        /// edit road name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roadNameChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            int index = roadListView.getIndexByTextBox(txt);
            screenModel.RoadList[index].RoadName = txt.Text;
            initRoadCmb();
            refrashSgmtList();
            refrashSgmtInfo();
        }
  */
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
                    refreshSgmtList();

                    cancelSelectedItem(this.selcetedItem);
                    this.lstVwSgmt.SelectedItems.Clear();
                    selectItem( this.lstVwSgmt.Items[sgmtModel.SegmentID]);

                    refreshSgmtList();
                 
                    refreshView();
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
                refreshSelectedItem();
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
                refreshSelectedItem();
            }
            else
            {

            }
        }

        private void cmbRdClr_SelectedIndexChangedAndSend(object sender, EventArgs e)
        {

            ComboBox combBox = (ComboBox)sender;

            if (this.selcetedItem != null)
            {
                SegmentModel segMengt = this.ScreenModel.getSegmentList()[selcetedItem.Index];

                bool result = ServiceContext.getInstance().getScreenControl().setScreenSegmentColor(segMengt.SegmentID, combBox.SelectedIndex);
                if (result)
                {
                    MessageBox.Show("修改路段颜色成功");
                    segMengt.SegmentColor = combBox.SelectedIndex;
                }
                else
                {
                    MessageBox.Show("修改路段颜色失败");
                }
         
                refreshSgmtList();
                refreshView();
                refreshSgmtInfo();

            }
            else
            {
                ;
            }
        }


        private void cmbRdClr_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox combBox = (ComboBox)sender;

            if (this.selcetedItem != null)
            {
                SegmentModel segMengt = this.ScreenModel.getSegmentList()[selcetedItem.Index];

              
                segMengt.SegmentColor = combBox.SelectedIndex;
             

                refreshSgmtList();
                refreshView();
                refreshSgmtInfo();

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
                    this.refreshSgmtInfo();
                    this.refreshSelectedItem();
                  
                }
                else if (this.selcetedItem.Equals(lv.SelectedItems[lv.SelectedItems.Count-1]))
                {
                    // cancel
                    cancelSelectedItem(item);
                    this.refreshSelectedItem();
                    lv.SelectedItems.Clear();
                    this.SelcetedItem = null;
                    
                }
                else 
                {
                    // selected Other
                    cancelSelectedItem(this.selcetedItem);
                    lv.SelectedItems.Clear();
                    selectItem(item);
                    this.refreshSelectedItem();
                    this.refreshView();
                }
             
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




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitMntm_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        
        
        private void initScrnMntm_Click(object sender, EventArgs e)
        {
            bool result = ServiceContext.getInstance().getScreenControl().initScreen();

            ScreenModel screenModel = new ScreenModel();
            try
            {
                 screenModel = ServiceContext.getInstance().getScreenControl().getScreenInfo(this.ScreenModel.BasicInfo.ScreenIP);

            }
            catch(SystemException ex)
            {
                log.Error("get screen information failed", ex);
                result = false;

            }
            if (result)
            {

                MessageBox.Show("操作成功");


                loadScreen(screenModel);
            }
            else
            {
                MessageBox.Show("操作失败");
            } 
        }
        private void saveScrnMntm_Click(object sender, EventArgs e)
        {
            bool result = ServiceContext.getInstance().getScreenControl().saveScreen();
            if (result)
            {
                MessageBox.Show("操作成功");
            }
            else
            {
                MessageBox.Show("操作失败");
            } 
        }
 


        /// <summary>
        /// 菜单 - 修改IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditIPMntm_Click(object sender, EventArgs e)
        {

            ScreenManager.Forms.PasswordForm pf = new ScreenManager.Forms.PasswordForm();
            ScreenManager.Forms.ipMacForm ipMacForm = new ScreenManager.Forms.ipMacForm(this.screenModel);

            if (pf.ShowDialog() == DialogResult.OK)
            {
                ipMacForm.ShowDialog();
            }
            else
            {
                ;
            }

        }

        /// <summary>
        /// 菜单-屏幕信息设置
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrnBasicInfoSetupMntm_Click(object sender, EventArgs e)
        {
            ScreenManager.Forms.PasswordForm pf = new ScreenManager.Forms.PasswordForm();
            ScreenManager.Forms.ScreenBasicInfoForm sf = new ScreenManager.Forms.ScreenBasicInfoForm(this);

           
            if (pf.ShowDialog() == DialogResult.OK)
            {
 
                sf.ShowDialog();
           
            }
            else
            {
                ;
            }
        }

        /// <summary>
        /// 菜单-文件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openMntm_Click(object sender, EventArgs e)
        {
            RoadDaoModel roadDaoModel = null ;
                ScreenManager.Dao.RoadDao roadDao = new ScreenManager.Dao.RoadDao();
                 bool check=true;
             
                 try
                 {

                     roadDaoModel = roadDao.loadByFile();
                 } catch (System.Exception ex)
                 {
                     log.Error("Can not open file.",ex);
                     MessageBox.Show("打开文件错误");

                 }
               

                 if (roadDaoModel != null)
                 {

                     if (roadDaoModel.ScreenLength <=this.ScreenModel.BasicInfo.ScreenLength || !roadDaoModel.ScreenName.Equals(this.ScreenModel.BasicInfo.ScreenName))
                     {

                         for (int i = 0; i < roadDaoModel.RoadList.Count; i++)
                         {

                             if (roadDaoModel.RoadList[i].RoadLenght > this.ScreenModel.RoadList[i].RoadLenght)
                             {
                                 check = false;
                             }
                         }
                         if (check == true)
                         {
                             this.SelcetedItem = null;
                             roadDaoModel.read(this.ScreenModel);
                             this.refreshRoadInfo();
                             this.refreshScrn();
                         }
                         else
                         {
                             MessageBox.Show("路段长度不匹配");
                         }
                     }
                     else
                     {

                         MessageBox.Show("屏幕名称或长度不匹配。");
                     }
                 }  
                 else
                 {
                     MessageBox.Show("打开文件错误");
                 }

        }

        /// <summary>
        /// 菜单-保存文件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveMntm_Click(object sender, EventArgs e)
        {
            ScreenManager.Dao.RoadDao roadDao = new ScreenManager.Dao.RoadDao();
            if (!roadDao.saveAsFile(this.ScreenModel))
            {
               MessageBox.Show("保存文件错误");
            }
        }



        private void btnReadScreenInfo_Click(object sender, EventArgs e)
        {
            

            if (ServiceContext.getInstance().getScreenControl().getScreenSegmentInfo(this.ScreenModel.RoadList))
            {
               
            }
            else
            {
                MessageBox.Show("操作失败");
            }
            this.cancelSelectedItem(this.SelcetedItem);
            this.SelcetedItem = null;
            this.refreshScrn();
            
        }

        /// <summary>
        /// 菜单-关于软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutMntm_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        /// <summary>
        /// 菜单-颜色控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorCtrlMntm_Click(object sender, EventArgs e)
        {
            ColorCtrlForm ccf = new ColorCtrlForm(this);
            ccf.ShowDialog();        
            ccf.Close();


        }
        /// <summary>
        /// 菜单-颜色亮度控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lightCtrlMntm_Click(object sender, EventArgs e)
        {
            LightCtrlForm lcf = new LightCtrlForm(this.ScreenModel);

            lcf.ShowDialog();

            this.refreshScrn();
            lcf.Close();
        }

        /// <summary>
        /// 菜单-屏幕开关设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openCloseScreenMntm_Click(object sender, EventArgs e)
        {
            OpenCloseCtrlForm occf = new OpenCloseCtrlForm(this.screenModel);           
            occf.ShowDialog();
            this.refreshStatusBar();
            occf.Close();
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
        private void mouseClick(object sender, MouseEventArgs e)
        {


            
            ScreenManager.Model.UI.RoadPanel panel = (ScreenManager.Model.UI.RoadPanel)sender;

            if (panel.DragSelected == false)
            {

                int clickValue;
                int length = panel.Width;
                int roadLength = panel.Road.RoadLenght;
                double clickPoint;
                clickPoint = (double)e.X / (double)length;
                clickValue = (int)(clickPoint * (double)roadLength);

                int index = panel.Road.getSegmentModelByPositon(clickValue);

                ListView lv = this.lstVwSgmt;
                if (index != -1)
                {
                    ListViewItem item = this.lstVwSgmt.Items[index];
                    if (this.selcetedItem == null)
                    {
                        selectItem(item);
                        this.refreshSgmtInfo();
                        this.refreshSelectedItem();

                    }
                    else if (this.selcetedItem.Equals(item))
                    {
                        // cancel
                        cancelSelectedItem(item);
                        this.refreshSelectedItem();
                        lv.SelectedItems.Clear();
                        this.SelcetedItem = null;

                    }
                    else
                    {
                        // selected Other
                        cancelSelectedItem(this.selcetedItem);
                        lv.SelectedItems.Clear();
                        selectItem(item);
                        this.refreshSelectedItem();
                        this.refreshView();
                    }
                }
                else
                {
                }
                System.Console.WriteLine("点击的地点：" + clickValue);
            }
            else
            {

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
                       // System.Console.WriteLine("游标位置：" + panel.StartMarkPosition + "," + panel.EndMarkPosition + "鼠标位置" + e.Location.X);
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
        public  void cancelSelectedItem(ListViewItem item)
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

                this.lblSegmentName.Text = "";
                this.cmbRoad.Text = "";
                this.txtStart.Value = 0;
                this.txtEnd.Value = 0;
                this.txtStart.Maximum = 512;
                this.txtEnd.Maximum = 512;

                this.cmbRdClr.Text = "";
                this.cmbRdClr2.Text = "";


            }
            else
            {



                this.lblSegmentName.Text = item.SubItems[0].Text;
                this.cmbRoad.SelectedIndex = this.ScreenModel.getRoadModelBySegmentId(System.Convert.ToInt16(item.SubItems[0].Text)).RoadID;
             
                this.txtStart.Maximum = this.ScreenModel.getRoadModelBySegmentId(System.Convert.ToInt16(item.SubItems[0].Text)).RoadLenght;
                this.txtEnd.Maximum = this.ScreenModel.getRoadModelBySegmentId(System.Convert.ToInt16(item.SubItems[0].Text)).RoadLenght;

                this.txtStart.Value = System.Convert.ToInt16(item.SubItems[2].Text);
                this.txtEnd.Value = System.Convert.ToInt16(item.SubItems[3].Text);


                this.cmbRdClr.SelectedIndex = this.ScreenModel.getSegmentList()[System.Convert.ToInt16(item.SubItems[0].Text)].SegmentColor;
                this.cmbRdClr2.SelectedIndex = this.ScreenModel.getSegmentList()[System.Convert.ToInt16(item.SubItems[0].Text)].SegmentColor;
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
            if (Math.Abs(roadOffset) >= 1)
            {
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

       
            this.refreshSelectedItem();
            this.refreshSgmtInfo();
            }
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
            System.Console.WriteLine("触发鼠标事件");
            if (Math.Abs(roadOffset) >= 1)
            {
                System.Console.WriteLine("触发画图事件");
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
         
            

          
            this.refreshSelectedItem();
            this.refreshSgmtInfo();
            }

        }
        private void initRoadCmb()
        {

            List<String> roadNameList = new List<String>();

            this.cmbRoad.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                roadNameList.Add(i.ToString() + ":" + ScreenModel.RoadList[i].RoadName);
            }
            this.cmbRoad.Items.AddRange(roadNameList.ToArray());

        }
       
        private void sgmtInfoActivation(Boolean b)
        {
            cmbRoad.Enabled = b;
            txtStart.Enabled = b;
            txtEnd.Enabled = b;
            cmbRdClr.Enabled = b;
            cmbRdClr2.Enabled = b;
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

        private void ScreenEditForm_Load(object sender, EventArgs e)
        {

        }

        private void ScreenEditForm_Paint(object sender, PaintEventArgs e)
        {
           this.refreshScrn();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            RoadPanel rp = (RoadPanel)sender;
            rp.repaint();
        }

       

 

  


     





    }
}
