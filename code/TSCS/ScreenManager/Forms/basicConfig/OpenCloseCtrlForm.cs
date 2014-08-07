using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenManager.Service;
using ScreenManager.Util;
namespace ScreenManager.Forms.basicConfig
{
    public partial class OpenCloseCtrlForm : Form
    {
        public OpenCloseCtrlForm()
        {
            InitializeComponent();
        }
        bool open;

        private void OpenCloseCtrlForm_Load(object sender, EventArgs e)
        {
            //Get Screen Status
            bool result = ServiceContext.getInstance().getScreenControl().getScreenOpenStatus();
            open = result;
            if (result)
            {
                this.rdbOpen.Checked = true;
                this.rdbClose.Checked = false;
            }
            else
            {
                this.rdbOpen.Checked = false;
                this.rdbClose.Checked = true;
            }         
        }


        private void CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbOpen.Checked == true)
            {
                SetCmdThread setCmd = new SetCmdThread();
                setCmd.setCmd(CmdConstants.OPEN_SCREEN);
            }
            else if (this.rdbClose.Checked == true)
            {
                SetCmdThread setCmd = new SetCmdThread();
                setCmd.setCmd(CmdConstants.CLOSE_SCREEN);
            }
        }
    }
}
