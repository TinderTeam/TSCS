using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenManager.Model;

namespace ScreenManager.Forms
{
    public partial class ipMacForm : System.Windows.Forms.Form
    {
 
        private ScreenModel screen;
        public ipMacForm(ScreenModel screen)
        {
 
            InitializeComponent();
            this.screen = screen;
            this.textBox1.Text = this.screen.BasicInfo.ScreenIP;
            this.textBox2.Text = this.screen.BasicInfo.MacAddr;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            bool result = Service.ServiceContext.getInstance().getScreenControl().modifyScreenIP(this.textBox1.Text,this.textBox2.Text);
            if (result)
            {
                this.screen = new ScreenModel();
                MessageBox.Show("操作成功! 请重新搜索屏幕");
                this.DialogResult = DialogResult.OK;
            }else{
                MessageBox.Show("操作失败");
            }
  
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((this.textBox2.Text.Length % 3) ==2){
                this.textBox2.Text=this.textBox2.Text+"-";
            }
        }
       


    }
}
