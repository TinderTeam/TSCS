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
    public partial class ScreenLengthForm : System.Windows.Forms.Form
    {

        private ScreenModel screen;
        String  ip;
        public ScreenLengthForm(ScreenModel screen)
        {
 
            InitializeComponent();
            this.screen = screen;
            this.numericUpDown1.Value = screen.ScreenLong;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {

            bool result = ScreenManager.Service.ServiceContext.getInstance().getScreenControl().setScreenLength(System.Convert.ToInt16(this.numericUpDown1.Value));
            if (result)
            {
                screen.ScreenLong = System.Convert.ToInt16(this.numericUpDown1.Value);
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
