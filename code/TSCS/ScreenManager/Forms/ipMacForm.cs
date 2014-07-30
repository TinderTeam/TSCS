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
    public partial class ipMacForm : System.Windows.Forms.Form
    {
        String oldIp;
        public ipMacForm(String str)
        {
            oldIp = str;
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            bool result = Service.ServiceContext.getInstance().getScreenControl().modifyScreenIP(oldIp, this.textBox1.Text);
            if (result)
            {
                MessageBox.Show("操作成功");
                this.DialogResult = DialogResult.OK;
            }else{
                MessageBox.Show("操作失败");
            }
  
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
       


    }
}
