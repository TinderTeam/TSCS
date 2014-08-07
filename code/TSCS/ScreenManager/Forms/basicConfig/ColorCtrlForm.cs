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
    public partial class ColorCtrlForm : Form
    {
       public  ScreenModel screenModel;
        public ColorCtrlForm(ScreenModel sm)
        {
            InitializeComponent();
            screenModel = sm;
        }

        private void ColorCtrlForm_Load(object sender, EventArgs e)
        {
            this.colorBox.Items.AddRange(Model.Constant.Constants.colorArray);

            if (screenModel.BasicInfo.ScreenColor < 0)
            {
                this.colorBox.Text = "无颜色";
            }
            else
            {
                this.colorBox.SelectedIndex = screenModel.BasicInfo.ScreenColor;
            }          
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //颜色接口
            if (Service.ServiceContext.getInstance().getScreenControl().setScreenColor(this.colorBox.SelectedIndex))
            {
                screenModel.BasicInfo.ScreenColor = this.colorBox.SelectedIndex;
            }
           
          
        }

    }
}
