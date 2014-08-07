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
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //下发接口

        }
    }
}
