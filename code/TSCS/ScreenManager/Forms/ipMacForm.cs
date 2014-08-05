﻿using System;
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
            bool result = Service.ServiceContext.getInstance().getScreenControl().modifyScreenIP(this.textBox1.Text,this.textBox2.Text);
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((this.textBox2.Text.Length % 3) ==2){
                this.textBox2.Text=this.textBox2.Text+"-";
            }
        }
       


    }
}
