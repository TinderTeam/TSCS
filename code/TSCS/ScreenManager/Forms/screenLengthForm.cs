using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenManager.Forms
{
    public partial class ScreenLengthForm : System.Windows.Forms.Form
    {


        String  ip;
        public ScreenLengthForm(String str)
        {
            ip = str;

            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {

            bool result= ScreenManager.Service.ServiceContext.getInstance().getScreenControl().setScreenLength(System.Convert.ToInt16(this.numericUpDown1.Value));
            if (result)
            {
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
    }
}
