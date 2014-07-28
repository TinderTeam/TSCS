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
using ScreenManager.Service;
namespace ScreenManager.Form
{
    public partial class ScreenEditForm : System.Windows.Forms.Form
    {


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
            this.cmbScrnClr.Items.AddRange(Model.Constant.Constants.colorArray);
            this.cmbLightCtrl.Items.AddRange(Model.Constant.Constants.colorCtrlArray);
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
                panelView.Paint += new System.Windows.Forms.PaintEventHandler(this.roadPanel_Paint);

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
            refrashScrn();
        }

        ///------------ UI Control
        /// 
        
        /// <summary>
        /// 
        /// </summary>

        public void refrashScrn() {
            refrashScrnInfo();
            refrashView();
            refrashSgmtList();
            refrashSgmtInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        public void refrashScrnInfo() {
            this.txtIPAdrs.Text = screenModel.ScreenIP;
            this.txtScrnName.Text = screenModel.ScreenName;
            this.cmbScrnClr.Text = screenModel.ScreenColor;
            this.txtNumA.Value = screenModel.LightLevelA;
            this.txtNumB.Value = screenModel.LightLevelB;
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

        }

        

        ///-------------Action
        ///


        /// <summary>
        /// edit screen button click action
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScrnEdit_Click(object sender, EventArgs e)
        {
            if (this.btnScrnEdit.Text.Equals("修改"))
            {
                scrnInfoActivation(true);
                this.btnScrnEdit.Text= "取消";
            }
            else {

                txtNumA.Value= this.ScreenModel.LightLevelA;
                txtNumB.Value = this.ScreenModel.LightLevelB; 
                cmbScrnClr.Text= this.ScreenModel.ScreenColor;
               txtScrnName.Text= this.screenModel.ScreenName ;
               cmbScrnClr.SelectedIndex= this.screenModel.ScreenColorCtrl ;
          
                scrnInfoActivation(false);
                this.btnScrnEdit.Text = "修改";
            }
           

        }

        private void btnScrnSet_Click(object sender, EventArgs e)
        {
            this.ScreenModel.LightLevelA = System.Convert.ToInt16(txtNumA.Value);
            this.ScreenModel.LightLevelB = System.Convert.ToInt16(txtNumB.Value);
            this.ScreenModel.ScreenColor = cmbScrnClr.Text;
            this.screenModel.ScreenName = txtScrnName.Text;
            this.screenModel.ScreenColorCtrl = cmbScrnClr.SelectedIndex;
            ScreenManager.Service.ScreenControlInterface service = new ScreenManager.Service.ScreenControlImpl();
            service.setScreenInfo(this.screenModel.BasicInfo);
            scrnInfoActivation(false);
        }




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
         
        }

        private void numStart_ValueChanged(object sender, EventArgs e)
        {
            if (this.selcetedItem != null)
            {
                System.Windows.Forms.NumericUpDown num = (System.Windows.Forms.NumericUpDown)sender;
                this.ScreenModel.getSegmentList()[selcetedItem.Index].Address.Start = System.Convert.ToInt16(num.Value);
                refrashSgmtList();
                refrashView();
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
                refrashSgmtList();
                refrashView();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefault_Click(object sender, EventArgs e)
        {
            this.ScreenModel.initRoadList();
            this.refrashSgmtInfo();
            this.refrashSgmtList();
            this.refrashView();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            ScreenManager.Service.ScreenControlInterface service = new ScreenManager.Service.ScreenControlImpl();
            service.setScreenSegment(this.ScreenModel);
                   
        }

        private void lstVwSgmt_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
           
            if (lv.SelectedItems.Count>0) {
                ListViewItem item = lv.SelectedItems[lv.SelectedItems.Count - 1];
                if (this.selcetedItem == null)
                {
                    selectItem(item);
                }
                else if (this.selcetedItem.Equals(lv.SelectedItems[lv.SelectedItems.Count-1]))
                {
                    // cancel
                    cancelSelectedItem(item);
                    lv.SelectedItems.Clear();
                }
                else 
                {
                    // selected Other
                    cancelSelectedItem(this.selcetedItem);
                    lv.SelectedItems.Clear();
                    selectItem(item);
                }
                
            }
        }


        public ScreenModel ScreenModel
        {
            get { return screenModel; }
            set { screenModel = value; }
        }

        private void roadPanel_Paint(object sender, PaintEventArgs e)
        {
             RoadPanel panelView =  (RoadPanel) sender;
             panelView.repaint();

        }

        /// <summary>
        /// search screen by ip segment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchScrnMntm_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(this);
            mainForm.Show();
        }


        /// <summary>
        /// selcted
        /// </summary>
        /// <param name="item"></param>
        private void selectItem(ListViewItem item)
        {
            item.BackColor = Color.Blue;
            item.ForeColor = Color.White;
            sgmtInfoActivation(true);
            loadSelectedSegmentInfo(item);
            this.SelcetedItem = item;
        }


        private void cancelSelectedItem(ListViewItem item)
        {
            item.BackColor = Color.White;
            item.ForeColor = Color.Black;
            sgmtInfoActivation(false);
            this.SelcetedItem = null;
            loadSelectedSegmentInfo(null);
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void loadSelectedSegmentInfo(ListViewItem item)
        {

           
            if (item== null)
            {

                this.txtSgmtName.Text = "";
                this.cmbRoad.Text = "";
                this.numStart.Value = 0;
                this.numEnd.Value =0;
                this.cmbRdClr.Text  ="";
            }
            else {
                this.txtSgmtName.Text = item.SubItems[0].Text;
                this.cmbRoad.Text = item.SubItems[1].Text;
                this.numStart.Value = System.Convert.ToInt16(item.SubItems[2].Text);
                this.numEnd.Value = System.Convert.ToInt16(item.SubItems[3].Text);
                this.cmbRdClr.Text = item.SubItems[4].Text;
            }

    
        }

     


        private void scrnInfoActivation(Boolean b)
        {
            txtNumA.Enabled=b;
            txtNumB.Enabled=b;
            cmbScrnClr.Enabled=b;
            txtScrnName.Enabled=b;
            cmbScrnClr.Enabled=b;
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

        public ListViewItem SelcetedItem
        {
            get { return selcetedItem; }
            set { selcetedItem = value; }
        }
       

    }
}
