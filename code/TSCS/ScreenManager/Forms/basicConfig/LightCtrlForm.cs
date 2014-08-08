using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenManager.Model;

namespace ScreenManager.Forms.basicConfig
{
    public partial class LightCtrlForm : Form
    {

        ScreenModel screenModel;
        public LightCtrlForm(ScreenModel sm)
        {
            InitializeComponent();
            screenModel = sm;
        }

        private void LightCtrlForm_Load(object sender, EventArgs e)
        {
            this.numA.Value = screenModel.BasicInfo.LightLevelA;
            this.numB.Value = screenModel.BasicInfo.LightLevelB;
            this.cmbCtrl.Items.AddRange(ScreenManager.Model.Constant.Constants.lightCtrlArray);
            this.cmbCtrl.SelectedIndex = screenModel.BasicInfo.LightCtrl;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {

            ScreenBasicInfoModel s = new ScreenBasicInfoModel();

            s.LightLevelA = System.Convert.ToInt16(this.numA.Value);
            s.LightLevelB = System.Convert.ToInt16(this.numB.Value);
            s.LightCtrl = this.cmbCtrl.SelectedIndex;
            if (Service.ServiceContext.getInstance().getScreenControl().setcreenLight(s))
           {
               screenModel.BasicInfo.LightLevelA = System.Convert.ToInt16(this.numA.Value);
               screenModel.BasicInfo.LightLevelB = System.Convert.ToInt16(this.numB.Value);
               screenModel.BasicInfo.LightCtrl = this.cmbCtrl.SelectedIndex;              
           }
        }
    }
}
