using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ScreenManager.Forms
{
    public partial class PasswordForm : System.Windows.Forms.Form
    {
      
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("../../Resources/config.xml");
            //指定一个节点
            XmlNode sysNode = xml.SelectSingleNode("/root/sys");
            string pswd = sysNode.Attributes["pswd"].Value;
            if (pswd.Equals(this.txtBox.Text))
            {
                this.DialogResult = DialogResult.OK;
            }else{
                 MessageBox.Show("密码错误");
             
            }
          
        }
    }
}
