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

namespace ScreenManager.Form
{
    public partial class ScreenEditForm : System.Windows.Forms.Form
    {


        private ScreenModel screenModel;
        private RoadListView roadListView; 
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
            this.cmbRoad.Items.AddRange(Model.Constant.Constants.colorArray);


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
            this.txtNumA.Value = screenModel.LightLeverA;
            this.txtNumB.Value = screenModel.LightLeverB;
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
            this.lstVwSgmt.Items.Clear();
            List<System.Windows.Forms.ListViewItem> listView = new List<System.Windows.Forms.ListViewItem>() ;
            int k=0;
            for (int i = 0; i < screenModel.roadList.Count; i++)
            {
                for (int j = 0; j < screenModel.roadList[i].SegmentList.Count; j++)
                {
                    String[] itemString = new String[5];
                    itemString[0]=k.ToString();
                    itemString[1]= screenModel.roadList[i].RoadName;
                    itemString[2]= screenModel.roadList[i].SegmentList[j].Address.Start.ToString();
                    itemString[3]= screenModel.roadList[i].SegmentList[j].Address.End.ToString();
                    itemString[4]= screenModel.roadList[i].SegmentList[j].SegmentColor;

                    System.Windows.Forms.ListViewItem item= new System.Windows.Forms.ListViewItem(itemString);
                    listView.Add(item);
                    k++;
                }
            }

            this.lstVwSgmt.Items.AddRange(listView.ToArray());
          
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

        }

        private void btnScrnSet_Click(object sender, EventArgs e)
        {

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

        }

        private void numEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbRdClr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddSgmt_Click(object sender, EventArgs e)
        {

        }

        private void btnDltSgmt_Click(object sender, EventArgs e)
        {

        }

        private void btnDefault_Click(object sender, EventArgs e)
        {

        }

        private void btnSet_Click(object sender, EventArgs e)
        {

        }

        private void lstVwSgmt_MouseClick(object sender, MouseEventArgs e)
        {

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

     




    }
}
