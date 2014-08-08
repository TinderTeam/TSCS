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
using ScreenManager.Forms;

namespace ScreenManager.Forms
{
    public partial class ScreenBasicInfoForm : System.Windows.Forms.Form
    {

        private ScreenEditForm form;
        public List<ScreenBasicRoadView> screenBasicRoadView = new List<ScreenBasicRoadView>();

        public ScreenBasicInfoForm(ScreenEditForm f)
        {
 
            InitializeComponent();
            form = f;
            this.screenLength.Value = form.ScreenModel.ScreenLong;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {

            bool result = ScreenManager.Service.ServiceContext.getInstance().getScreenControl().setScreenLength(System.Convert.ToInt16(this.screenLength.Value));
            if (result)
            {
                this.form.ScreenModel.ScreenLong = System.Convert.ToInt16(this.screenLength.Value);
                MessageBox.Show("操作成功");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("操作失败");
            }
         

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ScreenBasicInfoForm_Load(object sender, EventArgs e)
        {


          
            this.screenLength.Maximum = 512;
            this.screenLength.Value = this.form.ScreenModel.ScreenLong;
            this.screenName.Text = this.form.ScreenModel.ScreenName;

            for (int i = 0; i < this.form.ScreenModel.RoadList.Count; i++)
            {
                ScreenBasicRoadView sv = new ScreenBasicRoadView();

                System.Windows.Forms.ComboBox roadColor;
                System.Windows.Forms.NumericUpDown roadLength;
                System.Windows.Forms.TextBox roadName;

                roadColor = new System.Windows.Forms.ComboBox();
                roadLength = new System.Windows.Forms.NumericUpDown();
                roadName = new System.Windows.Forms.TextBox();
     

                roadColor.Anchor = System.Windows.Forms.AnchorStyles.None;
                roadColor.FormattingEnabled = true;
                roadColor.Location = new System.Drawing.Point(240, 21);             
                roadColor.Size = new System.Drawing.Size(121, 20);
                roadColor.TabIndex = 3;
                roadColor.Text =ScreenManager.Model.Constant.Constants.colorArray[form.ScreenModel.RoadList[i].BaseColor];
                roadColor.Items.AddRange(Model.Constant.Constants.colorArray);

                    roadLength.Anchor = System.Windows.Forms.AnchorStyles.None;
                    roadLength.Location = new System.Drawing.Point(442, 20);
                    roadLength.Size = new System.Drawing.Size(120, 21);
                    roadLength.TabIndex = 4;
                    roadLength.Maximum = form.ScreenModel.ScreenLong;
                    roadLength.Value = form.ScreenModel.RoadList[i].RoadLenght;


                    roadName.Anchor = System.Windows.Forms.AnchorStyles.None;
                    roadName.Location = new System.Drawing.Point(40, 20);
                    roadName.Text = form.ScreenModel.RoadList[i].RoadName;
                    roadName.Size = new System.Drawing.Size(120, 21);
                    roadName.TabIndex = 5;

                sv.RoadColor = roadColor;
                sv.RoadLength = roadLength;
                sv.RoadName = roadName;

                this.screenBasicRoadView.Add(sv);

                this.tableLayoutPanel3.Controls.Add(roadColor, 1, i+1);
                this.tableLayoutPanel3.Controls.Add(roadLength, 2, i + 1);
                this.tableLayoutPanel3.Controls.Add(roadName, 0, i + 1);

            }
          
        }

        private void btnSet_Click(object sender, EventArgs e)
        {



            this.btnSet.Enabled = false;
           
            DailogForm df = new DailogForm();

            if (df.ShowDialog() == DialogResult.OK)
            {

                ScreenModel m = new ScreenModel();
                m.BasicInfo.ScreenName = this.screenName.Text;
                m.BasicInfo.ScreenLength = System.Convert.ToInt16(this.screenLength.Value);



                for (int i = 0; i < this.screenBasicRoadView.Count; i++)
                {
                    m.RoadList[i].RoadName = this.screenBasicRoadView[i].RoadName.Text;
                    m.RoadList[i].RoadLenght = System.Convert.ToInt16(this.screenBasicRoadView[i].RoadLength.Value);

                }
                m.ScreenColor = this.form.ScreenModel.ScreenColor;


                bool result = ScreenManager.Service.ServiceContext.getInstance().getScreenControl().setScreenAndRoadNameInfo(m);

                if (!result)
                {
                    MessageBox.Show("操作失败");
                    //log
                }
                else
                {
                    //dailog
                    ScreenManager.Service.ServiceContext.getInstance().getScreenControl().initScreen();                                      
                    MessageBox.Show("操作成功");
                    this.form.ScreenModel.BasicInfo.ScreenName = this.screenName.Text;
                    this.form.ScreenModel.BasicInfo.ScreenLength = System.Convert.ToInt16(this.screenLength.Value);

                    for (int i = 0; i < this.screenBasicRoadView.Count; i++)
                    {

                        this.form.ScreenModel.RoadList[i].RoadName = this.screenBasicRoadView[i].RoadName.Text;
                        this.form.ScreenModel.RoadList[i].RoadLenght = System.Convert.ToInt16(this.screenBasicRoadView[i].RoadLength.Value);

                    }
                    this.form.ScreenModel.ScreenColor = this.form.ScreenModel.ScreenColor;
                    this.form.cancelSelectedItem(this.form.SelcetedItem);
                    this.form.SelcetedItem = null;
                    this.form.ScreenModel.cleanSegment();
                    this.form.refreshRoadInfo();
                    this.form.refrashSgmtInfo();
                    this.form.refrashScrn();
                  
                }
                this.form.refrashScrn();
            }
            else
            {

            }
            



        }

        private void screenLength_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < screenBasicRoadView.Count; i++)
            {
                screenBasicRoadView[i].RoadLength.Maximum = System.Convert.ToInt16(this.screenLength.Value);
                screenBasicRoadView[i].RoadLength.Value = System.Convert.ToInt16(this.screenLength.Value);
            }
        }

        
        
        
    }
}
