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

namespace ScreenManager.Forms
{
    public partial class ScreenBasicInfoForm : System.Windows.Forms.Form
    {

        private ScreenModel screenModel;
        public List<ScreenBasicRoadView> screenBasicRoadView = new List<ScreenBasicRoadView>();

        public ScreenBasicInfoForm(ScreenModel screen)
        {
 
            InitializeComponent();
            this.screenModel = screen;
            this.screenLength.Value = screen.ScreenLong;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {

            bool result = ScreenManager.Service.ServiceContext.getInstance().getScreenControl().setScreenLength(System.Convert.ToInt16(this.screenLength.Value));
            if (result)
            {
                this.screenModel.ScreenLong = System.Convert.ToInt16(this.screenLength.Value);
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
            this.screenLength.Value = screenModel.ScreenLong;
            this.screenName.Text = screenModel.ScreenName;

            for (int i = 0; i < screenModel.RoadList.Count; i++)
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
                roadColor.Text =ScreenManager.Model.Constant.Constants.colorArray[screenModel.RoadList[i].BaseColor];
                roadColor.Items.AddRange(Model.Constant.Constants.colorArray);

                roadLength.Anchor = System.Windows.Forms.AnchorStyles.None;
                roadLength.Location = new System.Drawing.Point(442, 20);              
                roadLength.Size = new System.Drawing.Size(120, 21);
                roadLength.TabIndex = 4;
                roadLength.Maximum = screenModel.ScreenLong;
                roadLength.Value = screenModel.RoadList[i].RoadLenght;


                roadName.Anchor = System.Windows.Forms.AnchorStyles.None;
                roadName.Location = new System.Drawing.Point(40, 20);
                roadName.Text = screenModel.RoadList[i].RoadName;
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
            bool result = ScreenManager.Service.ServiceContext.getInstance().getScreenControl().setScreenAndRoadNameInfo(screenModel);

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

        
        
        
    }
}
